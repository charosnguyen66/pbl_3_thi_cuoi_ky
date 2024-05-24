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
            if (checkEdit1.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
                txtRePass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
                txtRePass.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPass.Text != txtRePass.Text)
            {
                labelControl10.Visible = true;
                button1.BackColor = Color.Azure;
                button1.ForeColor = Color.Red;
                button1.Enabled = false;
            }

            else
            {
                labelControl10.Visible = false;

                tb_Customer account = new tb_Customer();
                account.CustomerID = txtuser.Text;
                account.Password = txtPass.Text;
                account.Address = "";
                account.Birthdate = DateTime.Now;
                account.Name = "";
                account.Gender = true;
                account.RewardPoints = 0;
                account.PhoneNumber = "";

                _account.AddNew(account);
                DialogResult result = MessageBox.Show("Thêm tài khoản thành công! Bạn muốn đăng nhập không?", "Thông báo", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Hide();
                    Login f1 = new Login();
                    f1.Show();
                }
                else
                {
                }
            }
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {
            if (_account.checkExist(txtuser.Text))
            {
                button1.BackColor = Color.Azure;
                button1.ForeColor = Color.PeachPuff;
                button1.Enabled = false;

            }
            else
            {
                // Khôi phục màu sắc mặc định của nút
                button1.BackColor = Color.Gray;
                button1.ForeColor = Color.PeachPuff;
                button1.Enabled = true;

            }
        }

        private void labelControl8_Click(object sender, EventArgs e)
        {
            Hide();
            Login f1 = new Login();
            f1.Show();
        }
    }
}
