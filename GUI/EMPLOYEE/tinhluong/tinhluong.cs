using BusinessLayer.DTO;
using BusinessLayer;
using System;
using System.Windows.Forms;

namespace GUI.EMPLOYEE.payroll
{
    public partial class tinhluong : Form
    {
        private SalaryCalculator salaryCalculator = new SalaryCalculator();
           
        public tinhluong()
        {
            InitializeComponent();

            // Set up the DateTimePicker to show only month and year
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/yyyy";
            
        }

        private void LoadSalaryData(int month, int year)
        {
            // Assuming employeeId is retrieved from elsewhere in your application
            string employeeId = "NV001"; // Example employeeId
            var salary = salaryCalculator.CalculateSalary(employeeId, month, year);

            txtBasicSalary.Text = salary.BasicSalary.ToString("N0");
            txtOvertimeHours.Text = salary.OvertimeHours.ToString();
            txtLatePenalty.Text = salary.LatePenalty.ToString("N0");
            txtSickDays.Text = salary.SickDays.ToString();
            txtTotalSalary.Text = salary.TotalSalary.ToString("N0");
            MessageBox.Show("Salary calculated successfully!");
        }

        
        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            int month = dateTimePicker1.Value.Month;
            int year = dateTimePicker1.Value.Year;

            LoadSalaryData(month, year);
        }
    }
}
