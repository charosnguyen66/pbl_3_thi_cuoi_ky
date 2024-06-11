using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.EMPLOYEE.tinhluongnhanvien
{
    public partial class tinhluong : Form
<<<<<<< HEAD
    {
        string employeeID;

=======
    {   
        string employeeID;
        
>>>>>>> 64de7580e291ace885cd111372303e1c5a33b3ef
        public tinhluong(string employeeID)
        {
            InitializeComponent();
            dateTimePicker1.ValueChanged += DateTimePicker_ValueChanged;
            this.employeeID = employeeID;
        }

        private void btnChonThoiGian_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD

=======
            
>>>>>>> 64de7580e291ace885cd111372303e1c5a33b3ef
        }
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // Lấy ngày được chọn từ DateTimePicker và hiển thị nó
            DateTime selectedDate = dateTimePicker1.Value;
            CalculateSalary(employeeID, selectedDate);
<<<<<<< HEAD
        }


        public double CalculateSalary(string employeeId, DateTime selectedDate)
        {
            Salary salaryManager = new Salary();
            sickOff sickOffManager = new sickOff();
            Overtime overtimeManager = new Overtime();
            double totalSalary = 0;
            int month = selectedDate.Month;
            int year = selectedDate.Year;

            // Lấy thông tin lương của nhân viên
            var salaryInfo = salaryManager.getItem(employeeId, month, year);
            if (salaryInfo == null)
            {
                txtLuongCoBan.Text = "không có dữ liệu";
                txtLuongTangCa.Text = "không có dữ liệu";
                txtSoGioTangCa.Text = "không có dữ liệu";
                txtSoNgayNghi.Text = "không có dữ liệu";
                txtTongLuong.Text = "không có dữ liệu";
                MessageBox.Show("không có dữ liệu về lương của tháng" + month + "năm" + year);
                return 0; // Trả về 0 khi không tìm thấy thông tin lương
            }
            else
            {
                // Lấy tiền lương tháng đó của nhân viên
                totalSalary = salaryInfo.Wage.Value;
                
                txtLuongCoBan.Text = totalSalary.ToString();

                // Lấy danh sách ngày nghỉ ốm của nhân viên
                List<tb_SickOff> sickOffList = sickOffManager.getList(employeeId);
                int soNgayNghi = 0;
                foreach (var sickDay in sickOffList)
                {
                    if (sickDay.SickDate.Value.Year == year && sickDay.SickDate.Value.Month == month)
                    {
                        totalSalary -= (totalSalary / 30); // Trừ tiền lương mỗi ngày nghỉ ốm
                        soNgayNghi++;
                    }
                }
                txtSoNgayNghi.Text = soNgayNghi.ToString();

                // Lấy danh sách giờ làm thêm giờ của nhân viên
                List<tb_OverTime> overTimesList = overtimeManager.getList(employeeId);
                int soGio = 0;
                double luongTangCa;
                foreach (var overtime in overTimesList)
                {
                    if (overtime.OvertimeDate.Value.Year == year && overtime.OvertimeDate.Value.Month == month)
                    {
                       int soGioTangCa = overtime.HoursOT.Value;
                       soGio = soGioTangCa;
                        luongTangCa = overtime.coeffSalary.Value;
                        txtLuongTangCa.Text = luongTangCa.ToString();
                        while (soGioTangCa > 0)
                        {
                            totalSalary += overtime.coeffSalary.Value;
                            
                            soGioTangCa--;
                        }; // Cộng tiền lương làm thêm giờ
                    }
                }
                txtSoGioTangCa.Text = soGio.ToString();
               txtTongLuong.Text = totalSalary.ToString();
                return totalSalary; // Trả về tổng lương sau khi đã tính toán các khoản trừ và cộng
            }
        }

       
    }
}
=======




        }
        private Salary salaryManager = new Salary();
        private sickOff sickOffManager = new sickOff();
        private Overtime overtimeManager = new Overtime();

        public double CalculateSalary(string employeeId, DateTime selectedDate)
        {
            double totalSalary = 0;

            // Lấy thông tin lương của nhân viên
            var salaryInfo = salaryManager.getItem(employeeId);
            if (salaryInfo == null)
            {
                MessageBox.Show("Không tìm thấy thông tin lương cho nhân viên có ID: " + employeeId);
            }
            else
            {
                // Lấy danh sách ngày nghỉ ốm của nhân viên
                List<tb_SickOff> = tb_SickOff.

                // Lấy danh sách giờ làm thêm giờ của nhân viên


                // Tính toán tiền lương
            }




            return totalSalary;
        }
    }
}
>>>>>>> 64de7580e291ace885cd111372303e1c5a33b3ef
