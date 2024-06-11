using BusinessLayer;
using BusinessLayer.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Admin.Nhanvien
{
    public partial class ChinhSuaNV : Form
    {
        string _id, _pass;
        Employee _employee;
        public ChinhSuaNV(string name, string pa)
        {
            InitializeComponent();
            _id = name;
            _employee = new Employee();
            setCCB();
            LoadDataToView();
            _pass = pa;
        }
        public void setCCB()
        {

            cbbTypeEm.Items.Add(new CBBItem
            {
                Value = 0,
                Text = "Phục vụ"
            });
            cbbTypeEm.Items.Add(new CBBItem
            {
                Value = 1,
                Text = "Đầu bếp"
            });
        }
        public void LoadDataToView()
        {
            List<NhanVien_DTO> list = _employee.GetAccountsFromTable1();
            foreach (var i in list)
            {
                if (i.EmployeeID == _id)
                {
                    txtName.Text = i.Name;
                    txtPhone.Text = i.PhoneNumber;
                    rdFemale.Checked = (i.Gender == "Nữ");
                    if (i.TypeEmployee.Trim() == "Đầu bếp")
                    {

                        cbbTypeEm.SelectedIndex = 1;
                    }
                    if (i.TypeEmployee.Trim() == "Phục vụ")
                    {

                        cbbTypeEm.SelectedIndex = 0;
                    }
                    rdMale.Checked = (i.Gender == "Nam");
                    dpBirth.Value = (DateTime)i.BirthDate;
                  
                }
            }

        }
        private void ChinhSuaNV_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtPhone.Text) ||
                    cbbTypeEm.SelectedItem == null ||
                    dpBirth.Value == null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }


                tb_Employee q = new tb_Employee
                {
                    EmployeeID = _id,
                    Name = txtName.Text,
                    PhoneNumber = txtPhone.Text,
                    Gender = false,
                    BirthDate = DateTime.Now,
                    TypeEmployee = "Nhân viên",
                    Password = _pass
                };
                _employee.Update(q);
                DialogResult result = MessageBox.Show("Cập nhật Nhân viên thành công! Bạn muốn quay lại trang chủ không?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.Dispose();
                }
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình cập nhật dữ liệu: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbTypeEm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
