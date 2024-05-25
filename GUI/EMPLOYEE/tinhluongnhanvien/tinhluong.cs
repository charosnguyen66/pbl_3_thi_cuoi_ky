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
    {   
        string employeeID;
        
        public tinhluong(string employeeID)
        {
            InitializeComponent();
            dateTimePicker1.ValueChanged += DateTimePicker_ValueChanged;
            this.employeeID = employeeID;
        }

        private void btnChonThoiGian_Click(object sender, EventArgs e)
        {
            
        }
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // Lấy ngày được chọn từ DateTimePicker và hiển thị nó
            DateTime selectedDate = dateTimePicker1.Value;
            CalculateSalary(employeeID, selectedDate);




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
