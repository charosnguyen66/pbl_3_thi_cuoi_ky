using BusinessLayer;
using BusinessLayer.DTO;
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
    public partial class Them : Form
    {
        private string _id;

        Employee _employee;
        public delegate void MyDel(int ID );
        public MyDel d { get; set; }
        public Them(string id = null)
        {
            InitializeComponent();
            _employee = new Employee();
            _id = id;
            setCCB();
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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random();
                string randomNumbers = "";
                for (int i = 0; i < 3; i++)
                {
                    randomNumbers += random.Next(0, 10);
                }

                if (string.IsNullOrWhiteSpace(txtAddress.Text) ||
                    string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtPass.Text) ||
                    string.IsNullOrWhiteSpace(txtPhone.Text) ||
                    cbbTypeEm.SelectedIndex < 0 ||
                    (!rdFemale.Checked && !rdMale.Checked))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                string typeEmployee = cbbTypeEm.SelectedItem.ToString();
                tb_Employee q = new tb_Employee
                {
                    EmployeeID = "NV" + randomNumbers,
                    Name = txtName.Text,
                    Password = txtPass.Text,
                    PhoneNumber = txtPhone.Text,
                    BirthDate = dpBirth.Value,
                    Gender = rdFemale.Checked,
                    TypeEmployee = typeEmployee
                };

                _employee.AddNew(q);

                DialogResult result = MessageBox.Show("Thêm nhân viên thành công! " +
                    "Tên đăng nhập là: " + q.EmployeeID + "\nMật khẩu là: " + txtPass.Text +
                    "\nBạn muốn quay lại trang trước không?", "Thông báo", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình thêm mới Nhân viên: " + ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Them_Load(object sender, EventArgs e)
        {

        }
    }
}
