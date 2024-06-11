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

namespace GUI.EMPLOYEE.TaiKhoanNhanVien
{
    public partial class accountNV : Form
    {
        string _id;
        Employee _employee;
        public accountNV(string id = null)
        {
            InitializeComponent();
            this.Text = "Thông tin cá nhân";
            _id = id;
            _employee = new Employee();
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
        private void LoadToView()
        {
            List<tb_Employee> list = _employee.GetAccountsFromTable("tb_Employee");
            foreach (var i in list)
            {
                if (i.EmployeeID.Trim() == _id.Trim())
                {
                    txtName.Text = i.Name;
                    txtAddress.Text = i.Address;
                    txtPhone.Text = i.PhoneNumber;
                    txtNewPass.Text = "";
                    txtReNewPass.Text = "";
                    txtLoaiNhanVien.Text = i.TypeEmployee;

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

                    dateTimePicker1.Value = Convert.ToDateTime(i.BirthDate);
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            // Check if the new password fields match
            if (txtNewPass.Text.Trim() != txtReNewPass.Text.Trim())
            {
                MessageBox.Show("Mật khẩu mới không khớp, Vui lòng nhập lại!");
                return;
            }

            List<tb_Employee> list = _employee.GetAccountsFromTable("tb_Employee");
            foreach (var i in list)
            {
                if (i.EmployeeID.Trim() == _id.Trim())
                {
                    // Hash the old password input and compare with stored hashed password
                    if (HashCode.HashPassword(txtOldPass.Text.Trim()) != i.Password.Trim())
                    {
                        MessageBox.Show("Mật khẩu cũ không khớp, Vui lòng nhập lại!");
                        txtOldPass.ForeColor = Color.Red;
                        return;
                    }
                }
            }

            try
            {
                tb_Employee up = new tb_Employee
                {
                    EmployeeID = _id,
                    Name = txtName.Text,
                    PhoneNumber = txtPhone.Text,
                    Gender = rdFemale.Checked,
                    TypeEmployee = txtLoaiNhanVien.Text,
                    BirthDate = dateTimePicker1.Value,
                    Address = txtAddress.Text,
                    // Retain the current password if new password fields are empty
                    Password = string.IsNullOrWhiteSpace(txtNewPass.Text) ? list.FirstOrDefault(ee => ee.EmployeeID.Trim() == _id.Trim()).Password : HashCode.HashPassword(txtNewPass.Text.Trim())
                };

                if (this.pcAvt.ImageLocation == null)
                {
                    up.image = null;
                }
                else
                {
                    up.image = convertFileToByte(this.pcAvt.ImageLocation);
                }

                _employee.Update(up);

                DialogResult result = MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình cập nhật nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
