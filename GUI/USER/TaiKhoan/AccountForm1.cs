using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.USER.TaiKhoan
{
    public partial class AccountForm1 : Form
    {
        string _id;
        Account _customer;
        public AccountForm1(string id = null)
        {
            InitializeComponent();
            this.Text = "Thông tin cá nhân";
            _id = id;
            _customer = new Account();
            LoadToView();
        }
        private byte[] convertFileToByte(string path)
        {
            byte[] data = null;
            FileInfo fIn = new FileInfo(path);
            long num = fIn.Length;
            FileStream fStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)num);
            return data;
        }
        private void LoadToView()
        {
            List<tb_Customer> list = _customer.GetAccountsFromTable("tb_Customer");
            foreach(var i in list)
            {
                if(i.CustomerID.Trim() == _id.Trim())
                {
                    txtName.Text = i.Name;
                    txtAddress.Text = i.Address;
                    txtPhone.Text = i.PhoneNumber;
                    txtNewPass.Text = i.Password.Trim();
                    txtReNewPass.Text = i.Password.Trim();

                    Image picture = null;

                    byte[] imageData = i.image;

                    if (imageData != null && imageData.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            picture = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        // Handle the case where imageData is null or empty
                    }

                    if (picture != null)
                    {
                        pcAvt.Image = picture;
                    }
                    bool isFemale = Convert.ToBoolean(i.Gender); // Assuming i.Gender is already a boolean value
                    if (isFemale)
                    {
                        rdFemale.Checked = true;
                        rdMale.Checked = false;
                    }
                    else
                    {
                        rdFemale.Checked = false;
                        rdMale.Checked = true;
                    }

                    dateTimePicker1.Value = Convert.ToDateTime(i.Birthdate);
                }
            }
        }
        private void AccountForm_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
  
        private void iconButton1_Click(object sender, EventArgs e)
        {
            if(txtNewPass.Text.Trim() != txtReNewPass.Text.Trim())
            {
                MessageBox.Show("Mật khẩu mới không khớp, Vui lòng nhập lại!");
                
            }
            else { 
            List<tb_Customer> list = _customer.GetAccountsFromTable("tb_Customer");
            foreach (var i in list)
            {
                if (i.CustomerID.Trim() == _id.Trim())
                {
                    if(i.Password.Trim() != HashCode.HashPassword( txtOldPass.Text.Trim()))
                    {
                        MessageBox.Show("Mật khẩu cũ không khớp, Vui lòng nhập lại!");
                        txtOldPass.ForeColor = Color.Red;
                            return;
                        }
                }
                    
             }

                    try
                 {
                tb_Customer up = new tb_Customer();
                up.CustomerID = _id;
                up.Name = txtName.Text;
                up.PhoneNumber = txtPhone.Text;
                
                up.Gender = (rdFemale.Checked) ? true : false;

                up.Birthdate = dateTimePicker1.Value;
                up.Address = txtAddress.Text;
                up.Password = txtNewPass.Text.Trim();
                up.image = convertFileToByte(this.pcAvt.ImageLocation);
                _customer.Update(up);

                DialogResult result = MessageBox.Show("Cập nhật Khách hàng thành công!", "Thông báo", MessageBoxButtons.YesNo);
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
        }

        private void btnUpdateImg_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Vui lòng chọn một hình ảnh";
            ofd.Filter = "JPG|*.jpg|PNG|*.png|GIF|*gif";

            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.pcAvt.ImageLocation = ofd.FileName;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtReNewPass.UseSystemPasswordChar = false;
                txtNewPass.UseSystemPasswordChar = false;
                txtOldPass.UseSystemPasswordChar = false;

            }
            else
            {
                txtReNewPass.UseSystemPasswordChar = true;
                txtNewPass.UseSystemPasswordChar = true;
                txtOldPass.UseSystemPasswordChar = true;
            }
        }
    }
}
