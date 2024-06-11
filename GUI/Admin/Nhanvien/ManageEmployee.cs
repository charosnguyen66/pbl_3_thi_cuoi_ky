using BusinessLayer;
using BusinessLayer.DTO;
using DataLayer;
using GUI.Admin.Nhanvien;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class ManageEmployee : Form
    {
        Employee _employee;

        public ManageEmployee()
        {
            InitializeComponent();
            _employee = new Employee();
            setCCB();
            LoadToView();
        }

        public void setCCB()
        {
            cbbLop.Items.Add(new CBBItem
            {
                Value = 0,
                Text = "Tất cả"
            });
            cbbLop.Items.Add(new CBBItem
            {
                Value = 1,
                Text = "Phục vụ"
            });
            cbbLop.Items.Add(new CBBItem
            {
                Value = 2,
                Text = "Đầu bếp"
            });
            cbbLop.SelectedIndex = 0; // Set default selected index
            cbbLop.SelectedIndexChanged += new EventHandler(cbbLop_SelectedIndexChanged); // Add event handler
        }
        public void LoadToView()
        {
            Employee k = new Employee();
            var data = k.GetAccountsFromTable1();

            dataGridView1.DataSource = data;
            dataGridView1.RowTemplate.Height = 70;
            dataGridView1.Columns["EmployeeID"].HeaderText = "Mã nhân viên";
            dataGridView1.Columns["Name"].HeaderText = "Tên nhân viên";
            dataGridView1.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
            dataGridView1.Columns["Gender"].HeaderText = "Giới tính";
            dataGridView1.Columns["BirthDate"].HeaderText = "Ngày sinh";
            dataGridView1.Columns["TypeEmployee"].HeaderText = "Loại nhân viên";
            dataGridView1.Columns["Password"].Visible = false;

            // Thiết lập màu sắc cho DataGridView
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 123, 255);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular); // Đổi kích thước chữ
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 123, 255);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold); // Đổi kích thước chữ cho header
            dataGridView1.EnableHeadersVisualStyles = false;

            // Thiết lập chiều rộng cho các cột
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Thiết lập màu sắc khi chọn
            dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.Yellow; // Màu nền khi chọn
            dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.Red; // Màu chữ khi chọn
        }

        private void ManageEmployee_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            LoadToView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Them k = new Them();
            k.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadToView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            DataGridViewRow selectedRo1w = dataGridView1.CurrentRow;

            string column1Value = selectedRow.Cells["EmployeeID"].Value.ToString();
            string pass = selectedRo1w.Cells["Password"].Value.ToString();
            ChinhSuaNV u = new ChinhSuaNV(column1Value, pass);
            u.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string masp = selectedRow.Cells["EmployeeID"].Value.ToString();
            DialogResult result = MessageBox.Show("Ban có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _employee.Delete(masp);
                DialogResult result1 = MessageBox.Show("Xóa nhân viên thành công! ", "Thông báo", MessageBoxButtons.OK);
                if (result1 == DialogResult.Yes)
                {


                }
                LoadToView();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                tb_Employee up = new tb_Employee();
                up.EmployeeID = selectedRow.Cells["EmployeeID"].Value.ToString();
                up.Name = selectedRow.Cells["Name"].Value.ToString();
                up.PhoneNumber = selectedRow.Cells["PhoneNumber"].Value.ToString();
                string gioitinh = selectedRow.Cells["Gender"].Value.ToString();

                up.Gender = gioitinh == "Nữ" ? true : false;

                up.BirthDate = Convert.ToDateTime(selectedRow.Cells["BirthDate"].Value);
                up.TypeEmployee = selectedRow.Cells["TypeEmployee"].Value.ToString();
                up.Password = HashCode.HashPassword( selectedRow.Cells["EmployeeID"].Value.ToString());
                _employee.Update(up);

                DialogResult result = MessageBox.Show("Cấp lại mật khẩu cho nhân viên thành công!", "Thông báo", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    LoadToView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình cập nhật khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;

            string column1Value = selectedRow.Cells["EmployeeID"].Value.ToString();
            SalaryDetailForm u = new SalaryDetailForm(column1Value);
            u.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadToView();
                return;
            }

            var data = _employee.GetAccountsFromTable1().Where(emp =>
                emp.EmployeeID.Contains(searchText) ||
                emp.Name.Contains(searchText) ||
                emp.PhoneNumber.Contains(searchText) ||
                emp.TypeEmployee.Contains(searchText)).ToList();

            dataGridView1.DataSource = data;
        }

        private void cbbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = ((CBBItem)cbbLop.SelectedItem).Text;
            LoadDataToGridView(selectedValue);
        }

        private void LoadDataToGridView(string employeeType)
        {
            var data = _employee.GetAccountsFromTable1();

            // Lọc dữ liệu dựa trên loại nhân viên được chọn
            var filteredData = data.Where(d => d.TypeEmployee == employeeType).ToList();

            // Nếu chọn "Tất cả", hiển thị tất cả dữ liệu
            if (employeeType == "Tất cả")
            {
                filteredData = data;
            }

            // Gán dữ liệu đã chuyển đổi vào DataGridView
            dataGridView1.DataSource = filteredData;
            dataGridView1.RowTemplate.Height = 70;
            dataGridView1.Columns["EmployeeID"].HeaderText = "Mã nhân viên";
            dataGridView1.Columns["Name"].HeaderText = "Tên nhân viên";
            dataGridView1.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
            dataGridView1.Columns["Gender"].HeaderText = "Giới tính";
            dataGridView1.Columns["BirthDate"].HeaderText = "Ngày sinh";
            dataGridView1.Columns["TypeEmployee"].HeaderText = "Loại nhân viên";
            dataGridView1.Columns["Password"].Visible = false;
        }
    }
}
