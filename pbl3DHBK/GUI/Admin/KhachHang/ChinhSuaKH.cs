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

namespace GUI.Admin.Customer
{
    public partial class ChinhSuaKH : Form
    {
        Account _customer;
        string _maKH, _pass;
        public ChinhSuaKH(string id, string name, string phone, bool gender, DateTime birth, string address, int reward, string pass)
        {
          
            InitializeComponent();
            setCCB();
            _maKH = id;
            _customer = new Account();
            txtName.Text = name;
            txtPhone.Text = phone;
            string gen = gender==true ? "Nam" : "Nữ";
            cbbGender.SelectedIndex = cbbGender.FindStringExact(gen.Trim());
            dpBirth.Value = birth;
            txtAddress.Text = address;
            _pass = pass;
        }

       public void LoadDataToForm()
        {
            
        }
        public void setCCB()
        {
            cbbGender.Items.Add("Nam");
            cbbGender.Items.Add("Nữ");

        }
        private void label1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void cbbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                tb_Customer up = new tb_Customer();
                up.CustomerID = _maKH;
                up.Name = txtName.Text;
                up.PhoneNumber = txtPhone.Text;
                string selectedCategory = cbbGender.SelectedItem?.ToString();
                up.Gender = (selectedCategory == "Nam") ? false : true;

                up.Birthdate = dpBirth.Value;
               up.Address = txtAddress.Text;
                up.Password = _pass;

                _customer.Update(up);
                
                DialogResult result = MessageBox.Show("Cập nhật Khách hàng thành công! Bạn muốn quay lại trang chủ không?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Hide();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình cập nhật khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ChinhSuaKH_Load(object sender, EventArgs e)
        {

        }
    }
}
