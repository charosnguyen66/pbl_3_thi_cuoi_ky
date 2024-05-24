using BusinessLayer;
using DataLayer;
using GUI.Admin.Nhanvien;
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

namespace GUI.Admin.Customer
{
    public partial class ThemMoiKH : Form
    {
        Account _customer;
        public ThemMoiKH()
        {
            InitializeComponent();
            setCCB();
           
            _customer = new Account();
        }
        public void setCCB()
        {
            cbbGender.Items.Add("Nam");
            cbbGender.Items.Add("Nữ");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                tb_Customer product = new tb_Customer();
                Random random = new Random();
                string randomNumbers = "";
                for (int i = 0; i < 3; i++)
                {
                    randomNumbers += random.Next(0, 10);
                }
                product.CustomerID = "KH" + randomNumbers;
                product.Name = txtName.Text;
                product.PhoneNumber = txtPhone.Text;
                product.Gender = (cbbGender.SelectedItem.ToString() == "Nam") ? false : true;

                product.Birthdate = dpBirth.Value;

                product.Address = txtAddress.Text;
                product.RewardPoints = 0;
                product.Password = HashCode.HashPassword( txtPass.Text);

                _customer.AddNew(product);
                DialogResult result = MessageBox.Show("Thêm tài khoản thành công! " +
                    "Tên đăng nhập là: "+product.CustomerID+ "Mật khẩu là: "+txtPass.Text +
                    "Bạn muốn quay lại trang trước không?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Hide();

                   
                }

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void ThemMoiKH_Load(object sender, EventArgs e)
        {

        }
    }
}
