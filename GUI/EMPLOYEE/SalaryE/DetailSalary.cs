using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BusinessLayer;

namespace GUI.EMPLOYEE.Salary
{
    public partial class DetailSalary : Form
    {
        private BusinessLayer.Salary salaryBusiness = new BusinessLayer.Salary();
        private Overtime overtimeBusiness = new Overtime();
        private sickOff sickOffBusiness = new sickOff();
        string _id;

        public DetailSalary(string id)
        {
            InitializeComponent();
            _id = id;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpMonthYear.Value;
            int month = selectedDate.Month;
            int year = selectedDate.Year;

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

        private string FormatCurrency(decimal amount)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            return String.Format(culture, "{0:C0}", amount);
        }
    }
}
