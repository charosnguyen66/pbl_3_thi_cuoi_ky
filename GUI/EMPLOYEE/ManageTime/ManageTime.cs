using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BusinessLayer;
using DataLayer;

namespace GUI.EMPLOYEE.ManageTime
{
    public partial class ManageTime : Form
    {
        private DateTimePicker dtpMonth;
        private Panel pnlChart;
        private Overtime overtimeBusiness = new Overtime();
        private sickOff sickOffBusiness = new sickOff();
        private string employeeID = "NV597"; // Thay thế bằng ID thực tế của nhân viên
        private BusinessLayer.Salary salaryBusiness = new BusinessLayer.Salary();
        string _id;

        public ManageTime(string id)
        {
            InitializeComponent();
            _id = id;
            LoadCBB();
            InitializeControls();
            // Đặt các điều khiển ban đầu là ẩn
            dtpMonth.Visible = false;
            pnlChart.Visible = false;
            grb.Visible = false;
        }

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private string FormatCurrency(decimal amount)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            return String.Format(culture, "{0:C0}", amount);
        }

        public void LoadCBB()
        {
            cbbChon.Items.Clear();
            cbbChon.Items.Add(new ComboBoxItem { Text = "Vui lòng chọn", Value = 0 });
            cbbChon.Items.Add(new ComboBoxItem { Text = "Xem quá trình làm việc", Value = 1 });
            cbbChon.Items.Add(new ComboBoxItem { Text = "Xin nghỉ phép", Value = 2 });
            cbbChon.Items.Add(new ComboBoxItem { Text = "Đăng ký tăng ca", Value = 3 });
            cbbChon.SelectedIndex = 0;
            cbbChon.SelectedIndexChanged += CbbChon_SelectedIndexChanged;
        }

        private void InitializeControls()
        {
            // DateTimePicker
            dtpMonth = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "MM/yyyy",
                ShowUpDown = true,
                Location = new Point(20, 70),
                Visible = false
            };
            dtpMonth.ValueChanged += DtpMonth_ValueChanged;
            this.Controls.Add(dtpMonth);

            // Panel for Chart
            pnlChart = new Panel
            {
                Location = new Point(20, 120),
                Size = new Size(600, 400),
                Visible = false
            };
            this.Controls.Add(pnlChart);
        }

        private void CbbChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValue = (ComboBoxItem)cbbChon.SelectedItem;
            if (selectedValue != null && (int)selectedValue.Value == 1)
            {
                dtpMonth.Visible = true;
                pnlChart.Visible = true;
                grb.Visible = true;
                DisplayChart(dtpMonth.Value, true);
            }
            else if (selectedValue != null && (int)selectedValue.Value == 2)
            {
                dtpMonth.Visible = true;
                pnlChart.Visible = true;
                grb.Visible = false;
                DisplayChart(dtpMonth.Value, false);
            }
            else if (selectedValue != null && (int)selectedValue.Value == 3)
            {
                dtpMonth.Visible = true;
                pnlChart.Visible = true;
                grb.Visible = false;
                RegisterOvertime();
            }
            else
            {
                dtpMonth.Visible = false;
                grb.Visible = false;
                pnlChart.Visible = false;
            }
        }

        private void DtpMonth_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedMonth = dtpMonth.Value;
            DisplayChart(selectedMonth, cbbChon.SelectedIndex == 1);
            if (cbbChon.SelectedIndex == 1)
            {
                DisplaySalary(selectedMonth);
            }
        }

        private void DisplaySalary(DateTime selectedMonth)
        {
            int month = selectedMonth.Month;
            int year = selectedMonth.Year;

            string employeeID = _id; // Thay bằng EmployeeID cần tính lương

            // Lấy lương cơ bản
            var wage = salaryBusiness.getItem(employeeID, month, year);
            decimal basicSalary = (decimal)(wage != null ? wage.Wage : 0);

            // Lấy lương tăng ca
            var overtimes = overtimeBusiness.getList(employeeID)
                                            .Where(x => x.OvertimeDate.Value.Month == month && x.OvertimeDate.Value.Year == year)
                                            .ToList();
            decimal overtimeSalary = (decimal)(overtimes.Sum(x => x.HoursOT * x.coeffSalary));

            // Lấy lương nghỉ ốm
            var sickOffs = sickOffBusiness.getList(employeeID)
                                          .Where(x => x.SickDate.Value.Month == month && x.SickDate.Value.Year == year)
                                          .ToList();
            decimal sickOffSalary = sickOffs.Count * 50; // Giả sử 50 là số tiền cho mỗi ngày nghỉ ốm

            // Hiển thị giá trị lên các textbox
            txtBasicSalary.Text = FormatCurrency(basicSalary);
            txtOvertimeSalary.Text = FormatCurrency(overtimeSalary);
            txtSickOffSalary.Text = FormatCurrency(sickOffSalary);

            // Tính tổng lương
            decimal totalSalary = basicSalary + overtimeSalary + sickOffSalary;
            txtTotalSalary.Text = FormatCurrency(totalSalary);
        }

        private void DisplayChart(DateTime selectedMonth, bool isWorkProcess)
        {
            pnlChart.Controls.Clear();

            var daysInMonth = DateTime.DaysInMonth(selectedMonth.Year, selectedMonth.Month);
            var today = DateTime.Today;

            var overtimes = overtimeBusiness.getList(employeeID)
                                            .Where(x => x.OvertimeDate.Value.Month == selectedMonth.Month && x.OvertimeDate.Value.Year == selectedMonth.Year)
                                            .ToList();

            var sickOffs = sickOffBusiness.getList(employeeID)
                                          .Where(x => x.SickDate.Value.Month == selectedMonth.Month && x.SickDate.Value.Year == selectedMonth.Year)
                                          .ToList();

            for (int day = 1; day <= daysInMonth; day++)
            {
                var currentDay = new DateTime(selectedMonth.Year, selectedMonth.Month, day);
                var lblDay = new Label
                {
                    Size = new Size(40, 40),
                    Text = day.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = (currentDay < today && selectedMonth.Month == today.Month && selectedMonth.Year == today.Year) ? Color.Gray : Color.Yellow
                };

                if (overtimes.Any(x => x.OvertimeDate.Value.Date == currentDay.Date))
                {
                    lblDay.BackColor = Color.SkyBlue;
                }
                else if (sickOffs.Any(x => x.SickDate.Value.Date == currentDay.Date))
                {
                    lblDay.BackColor = Color.Gray; // Các ngày có trong bảng tb_SickOff sẽ có màu nền màu xám
                }

                if (!isWorkProcess && currentDay >= today && lblDay.BackColor != Color.Gray)
                {
                    lblDay.Click += (s, e) => RequestLeave(currentDay);
                }
                else if (isWorkProcess)
                {
                    lblDay.BackColor = currentDay >= today ? Color.Yellow : lblDay.BackColor;
                }

                int row = (day - 1) / 7;
                int col = (day - 1) % 7;
                lblDay.Location = new Point(col * 45, row * 45);
                pnlChart.Controls.Add(lblDay);
            }
        }

        private void RequestLeave(DateTime selectedDay)
        {
            // Lưu ngày nghỉ phép vào bảng tb_SickOff
            var newSickOff = new tb_SickOff
            {
                ID = sickOffBusiness.GetNextID(),
                EmployeeID = _id,
                SickDate = selectedDay
            };

            try
            {
                sickOffBusiness.AddNew(newSickOff);
                MessageBox.Show($"Xin nghỉ phép cho ngày {selectedDay.ToString("dd/MM/yyyy")} đã được lưu.", "Xin nghỉ phép", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show($"Có lỗi xác thực khi lưu ngày nghỉ phép: {ex.Message}", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi lưu ngày nghỉ phép: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterOvertime()
        {
            using (var form = new OvertimeForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var newOvertime = new tb_OverTime
                    {
                        ID = overtimeBusiness.GetNextID(),
                        EmployeeID = _id,
                        OvertimeDate = DateTime.Now,
                        HoursOT = form.HoursOT,
                        coeffSalary = (double) form.CoeffSalary
                    };

                    try
                    {
                        overtimeBusiness.AddNew(newOvertime);
                        MessageBox.Show($"Đăng ký tăng ca cho ngày {newOvertime.OvertimeDate} đã được lưu.", "Đăng ký tăng ca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (DbEntityValidationException ex)
                    {
                        MessageBox.Show($"Có lỗi xác thực khi lưu đăng ký tăng ca: {ex.Message}", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Có lỗi xảy ra khi lưu đăng ký tăng ca: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
