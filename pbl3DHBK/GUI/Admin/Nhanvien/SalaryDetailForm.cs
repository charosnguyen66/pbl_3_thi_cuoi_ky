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
            LoadDataToView();

        }

        public SalaryDetailForm()
        {
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
            foreach(var i in uu)
            {
                if(i.EmployeeID.Trim() == _idNV.Trim())
                {
                    lblName.Text = i.Name;
                    
                }
            }
            int  gioLam = 0;
           
            List<tb_Wage> kk = _salary.GetAccountsFromTable("tb_Wage");
            foreach (var i in kk)
            {
                if (i.EmployeeID.Trim() == _idNV.Trim())
                {
                    lblFrom.Text = ((DateTime)i.TimeStart).ToString("yyyy/MM/dd");
                    gioLam = Convert.ToInt32(i.WorkingTime.ToString());
                    luongCoBan = Convert.ToDouble(i.Wage.ToString());
                    lblTo.Text = ((DateTime)i.TimeEnd).ToString("yyyy/MM/dd");

                }
            }
            List<tb_OverTime> oo = _overtime.GetAccountsFromTable("tb_OverTime");
            foreach (var i in oo)
            {
                if(i.EmployeeID.Trim() == _idNV.Trim())
                {
                    luongTangCa = Convert.ToDouble(i.coeffSalary.ToString());
                    gioTang += Convert.ToInt32(i.OvertimeHours.ToString());
                }
            }
            List<tb_SickOff> ii = _sickoff.GetAccountsFromTable("tb_OverTime");
            foreach (var i in ii)
            {
                if (i.EmployeeID.Trim() == _idNV.Trim())
                {
                    gioNghi++ ;
                }
            }
            lblGiatangCa.Text = luongTangCa.ToString();
            lblMatdi.Text = (luongCoBan ).ToString();
            Overtime over = new Overtime();
            dataGridView1.DataSource = over.getList(_idNV.Trim());
            dataGridView1.Columns["tb_Employee"].Width = 0;
            txtOver.Text = gioTang.ToString();
            txtSick.Text = (gioNghi*8).ToString();
            txtWork.Text = gioLam.ToString();
            double ketQua = gioLam*luongCoBan - gioNghi * luongCoBan + gioTang * luongTangCa;

            // Chuyển đổi kết quả thành chuỗi với dấu chấm ngăn cách mỗi 3 chữ số
            string ketQuaFormatted = ketQua.ToString("#,##0");

            // Gán thông điệp cho Text của điều khiển txtTotal
            txtTotal.Text = $"{gioLam} * {luongCoBan} - {gioNghi} * {luongCoBan} + {gioTang} * {luongTangCa} = {ketQuaFormatted}";
            //txtTotal.Text = (gioLam * luongCoBan - gioNghi * luongCoBan + gioTang * luongTangCa).ToString();
            dataGridView2.DataSource = _overtime.getList(_idNV.Trim());
            dataGridView2.Columns["tb_Employee"].Width = 0;

        }
        private void SalaryDetailForm_Load(object sender, EventArgs e)
        {

        }
    }
}
