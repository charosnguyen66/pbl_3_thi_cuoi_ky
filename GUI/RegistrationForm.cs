using BusinessLayer;
using DataLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class RegistrationForm : Form
    {
        Account _account;

        public RegistrationForm()
        {
            InitializeComponent();
            _account = new Account();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            tb_Customer account = new tb_Customer
            {
                CustomerID = txtuser.Text,
                Password = HashCode.HashPassword(txtPass.Text),
                Address = "",
                Birthdate = DateTime.Now,
                Name = "",
                Gender = true,
                RewardPoints = 0,
                PhoneNumber = ""
            };

            try
            {
                _account.AddNew(account);
                DialogResult result = MessageBox.Show("Thêm tài khoản thành công! Bạn muốn đăng nhập không?", "Thông báo", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Hide();
                    Login f1 = new Login();
                    f1.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            if (txtPass.Text != txtRePass.Text)
            {
                MessageBox.Show("Mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_account.checkExist(txtuser.Text))
            {
                MessageBox.Show("Mã CustomerID đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {
            if (_account.checkExist(txtuser.Text))
            {
                button1.BackColor = Color.Azure;
                button1.ForeColor = Color.Red;
                button1.Enabled = false;
            }
            else
            {
                button1.BackColor = Color.Gray;
                button1.ForeColor = Color.Black;
                button1.Enabled = true;
            }
        }

        private void labelControl8_Click(object sender, EventArgs e)
        {
            Hide();
            Login f1 = new Login();
            f1.Show();
        }

        private void checkEdit1_CheckedChanged_1(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !checkEdit1.Checked;
            txtRePass.UseSystemPasswordChar = !checkEdit1.Checked;
        }
    }
}
