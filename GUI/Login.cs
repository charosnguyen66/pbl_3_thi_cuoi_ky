using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        Employee uu = new Employee();

        private void labelControl8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng ký tài khoản mới không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Hide();

                RegistrationForm registrationForm = new RegistrationForm();
                registrationForm.Show();
            }
            else
            {

            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            String user = txtuser.Text.Trim();
            //String pass = HashCode.HashPassword( txtPass.Text.Trim());
            String pass = txtPass.Text.Trim();
            int role = uu.LoginAs(user, pass);
            Console.WriteLine(role);
            switch (role)
            {
                case 1: // Khách hàng
                        //Account customer = new Account();
                        //if (customer.CheckLogin(user, pass))
                        //{
                    MainViewEmployee mainViewCustomer = new MainViewEmployee(user);
                    Hide();
                    MessageBox.Show("Đăng nhập thành công", "Thành công");
                    mainViewCustomer.Show();
                    //}
                    break;
                case 2: // Nhân viên
                        //Employee employee = new Employee();
                        //if (employee.CheckLogin(user, pass))
                        //{
                    MainViewCustomer mainViewEmployee = new MainViewCustomer(user);
                    Hide();
                    MessageBox.Show("Đăng nhập thành công", "Thành công");
                    mainViewEmployee.Show();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Đăng nhập thất bại", "Thất bại");
                    //}
                    break;
                case 3: // Quản trị viên

                    MainViewAdmin mainViewAdmin = new MainViewAdmin();
                    Hide();
                    MessageBox.Show("Đăng nhập thành công", "Thành công");
                    mainViewAdmin.Show();

                    break;
                default:
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Lỗi đăng nhập");
                    break;
            }
        }

        private void checkEdit1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Hide();
            RegistrationForm r = new RegistrationForm();
            r.Show();
        }
    }
}
