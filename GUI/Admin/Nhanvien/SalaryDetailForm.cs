using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI.Admin.Nhanvien
{
    public partial class SalaryDetailForm : Form
    {
        string _idNV;
        Salary _salary;
        sickOff _sickoff;
        Overtime _overtime;
        Employee _employee;

        public SalaryDetailForm(string id)
        {
            InitializeComponent();
            _salary = new Salary();
            _overtime = new Overtime();
            _sickoff = new sickOff();
            _idNV = id;
            _employee = new Employee();
            // Đăng ký sự kiện ValueChanged cho DateTimePicker
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            LoadDataToView();
        }

        public SalaryDetailForm()
        {
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xem lương tháng/năm đã chọn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoadDataToView();
            }
            else
            {
                // Nếu người dùng chọn "No", thì không làm gì cả
                return;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        public void LoadDataToView()
        {
            int gioNghi = 0, gioTang = 0;
            double luongCoBan = 0, luongTangCa = 0;
            List<tb_Employee> uu = _employee.GetAccountsFromTable("tb_Employee");
            foreach (var i in uu)
            {
                if (i.EmployeeID.Trim() == _idNV.Trim())
                {
                    lblName.Text = i.Name;
                }
            }
            int gioLam = 0;

            // Lấy tháng và năm từ DateTimePicker
            DateTime selectedDate = dateTimePicker1.Value;
            int selectedMonth = selectedDate.Month;
            int selectedYear = selectedDate.Year;

            DateTime currentDate = DateTime.Now;
            int currentMonth = currentDate.Month;
            int currentYear = currentDate.Year;

            // Kiểm tra nếu tháng được chọn nhỏ hơn tháng hiện tại
            if (selectedYear > currentYear || (selectedYear == currentYear && selectedMonth >= currentMonth))
            {
                MessageBox.Show("Chỉ có thể tính lương cho các tháng trước tháng hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<tb_Wage> kk = _salary.GetAccountsFromTable("tb_Wage");
            foreach (var i in kk)
            {
                if (i.EmployeeID.Trim() == _idNV.Trim() && ((DateTime)i.MonthWage).Month == selectedMonth && ((DateTime)i.MonthWage).Year == selectedYear)
                {
                    luongCoBan = Convert.ToDouble(i.Wage.ToString());
                    // Đặt giá trị cho txtWork bằng với Wage từ cơ sở dữ liệu
                    txtWork.Text = i.Wage.ToString();
                }
            }
            List<tb_OverTime> oo = _overtime.GetAccountsFromTable("tb_OverTime");
            foreach (var i in oo)
            {
                if (i.EmployeeID.Trim() == _idNV.Trim() && ((DateTime)i.OvertimeDate).Month == selectedMonth && ((DateTime)i.OvertimeDate).Year == selectedYear)
                {
                    luongTangCa = Convert.ToDouble(i.coeffSalary.ToString());
                    gioTang += Convert.ToInt32(i.HoursOT.ToString());
                }
            }
            List<tb_SickOff> ii = _sickoff.GetAccountsFromTable("tb_SickOff");
            foreach (var i in ii)
            {
                if (i.EmployeeID.Trim() == _idNV.Trim() && ((DateTime)i.SickDate).Month == selectedMonth && ((DateTime)i.SickDate).Year == selectedYear)
                {
                    gioNghi++;
                }
            }
            lblGiatangCa.Text = luongTangCa.ToString();
            lblMatdi.Text = "200.000";
            Overtime over = new Overtime();
            dataGridView1.DataSource = oo.Where(x => ((DateTime)x.OvertimeDate).Month == selectedMonth && ((DateTime)x.OvertimeDate).Year == selectedYear).ToList();
            if (dataGridView1.Columns.Contains("tb_Employee"))
            {
                dataGridView1.Columns["tb_Employee"].Visible = false;
            }
            txtOver.Text = gioTang.ToString();
            txtSick.Text = (gioNghi * 8).ToString();
            double ketQua = luongCoBan - gioNghi * 200000 + gioTang * luongTangCa;

            // Chuyển đổi kết quả thành chuỗi với dấu chấm ngăn cách mỗi 3 chữ số
            string ketQuaFormatted = ketQua.ToString("#,##0");

            // Gán thông điệp cho Text của điều khiển txtTotal
            txtTotal.Text = $" {luongCoBan} - {gioNghi} * 200000 + {gioTang} * {luongTangCa} = {ketQuaFormatted}";

            // Sửa lại phần này để hiển thị dữ liệu đúng của SickOff
            dataGridView2.DataSource = ii.Where(x => ((DateTime)x.SickDate).Month == selectedMonth && ((DateTime)x.SickDate).Year == selectedYear).ToList();
            if (dataGridView2.Columns.Contains("tb_Employee"))
            {
                dataGridView2.Columns["tb_Employee"].Visible = false;
            }
        }


        private void SalaryDetailForm_Load(object sender, EventArgs e)
        {
        }

        private void SalaryDetailForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
