using BusinessLayer;
using DataLayer;
using GUI.Admin.Customer;
using GUI.THUCDON;
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
using System.Xml.Linq;

namespace GUI
{
    public partial class ManageCustomer : Form
    {
        public Account _customer;
        public Invoice _invoice;
        public Product _product;
        public ManageCustomer()
        {
            InitializeComponent();
            _customer = new Account();
            _invoice = new Invoice();
            _product = new Product();
            setCBB();
            LoadData();
        }
        public List<object> GetCustomerInfoList()
        {
            List<tb_Customer> customerList = _customer.GetAccountsFromTable("tb_Customer");

            List<object> selectedCustomerInfoList = new List<object>();

            foreach (var customer in customerList)
            {
                string gender = customer.Gender==true ? "Nữ" : "Nam";
                var customerInfo = new
                {
                    Mãkháchhàng = customer.CustomerID,
                    Tênkháchhàng = customer.Name,
                    Sốđiệnthoại = customer.PhoneNumber,
                    Giớitính = gender,
                    Ngàysinh = customer.Birthdate,
                    Địachỉ = customer.Address,
                    Điểmthưởng = customer.RewardPoints,
                    Mậtkhẩu = customer.Password
                };

                selectedCustomerInfoList.Add(customerInfo);
            }

            return selectedCustomerInfoList;
        }

        public void LoadData()
        {
            List<object> customerInfoList = GetCustomerInfoList();
            dataGridView1.DataSource = customerInfoList;
            dataGridView1.Columns["Mậtkhẩu"].Width = 0;
            dataGridView1.Columns["Điểmthưởng"].Width = 170;
            dataGridView1.Columns["Địachỉ"].Width = 170;
            dataGridView1.Columns["Ngàysinh"].Width = 120;
            dataGridView1.Columns["Giớitính"].Width = 90;
            dataGridView1.Columns["Sốđiệnthoại"].Width = 120;
            dataGridView1.Columns["Tênkháchhàng"].Width = 190;
            dataGridView1.Columns["Mãkháchhàng"].Width = 100;
            dataGridView1.RowTemplate.Height = 40;

        }
        private void ManageCustomer_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemMoiKH t = new ThemMoiKH();
            t.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string maKH = selectedRow.Cells["Mãkháchhàng"].Value.ToString();
                string namekh = selectedRow.Cells["Tênkháchhàng"].Value.ToString();
                string sdt = selectedRow.Cells["Sốđiệnthoại"].Value.ToString();
                DateTime birth = Convert.ToDateTime(selectedRow.Cells["Ngàysinh"].Value);
                bool gioitinh = (selectedRow.Cells["Giớitính"].Value.ToString() == "Nam") ? true : false;

                string diachi = selectedRow.Cells["Địachỉ"].Value.ToString();
                int diemthuong = Convert.ToInt32(selectedRow.Cells["Điểmthưởng"].Value.ToString());
                string matkhau = selectedRow.Cells["Mậtkhẩu"].Value.ToString();


            

                ChinhSuaKH chinhSuaForm = new ChinhSuaKH(maKH, namekh, sdt, gioitinh,birth, diachi, diemthuong, matkhau);
                chinhSuaForm.Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string masp = selectedRow.Cells["Mãkháchhàng"].Value.ToString();

            _customer.Delete(masp);

            DialogResult result = MessageBox.Show("Xóa khách hàng thành công! Bạn muốn quay lại trang chủ không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Hide();
                MainViewAdmin f1 = new MainViewAdmin();
                f1.Show();
            }
            else
            {
                LoadData();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                tb_Customer up = new tb_Customer();
                up.CustomerID = selectedRow.Cells["Mãkháchhàng"].Value.ToString();
                up.Name = selectedRow.Cells["Tênkháchhàng"].Value.ToString();
                up.PhoneNumber = selectedRow.Cells["Sốđiệnthoại"].Value.ToString();
                string gioitinh = selectedRow.Cells["Giớitính"].Value.ToString();

                up.Gender = gioitinh == "Nữ" ? true : false;

                up.Birthdate = Convert.ToDateTime(selectedRow.Cells["Ngàysinh"].Value);
                up.Address = selectedRow.Cells["Địachỉ"].Value.ToString();
                up.Password = selectedRow.Cells["Mãkháchhàng"].Value.ToString();
                _customer.Update(up);

                DialogResult result = MessageBox.Show("Cấp lại mật khẩu cho Khách hàng thành công!", "Thông báo", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {

                    LoadData();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình cập nhật khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
       
        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string maKH = selectedRow.Cells["Mãkháchhàng"].Value.ToString();
                string namekh = selectedRow.Cells["Tênkháchhàng"].Value.ToString();
                string sdt = selectedRow.Cells["Sốđiệnthoại"].Value.ToString();
                DateTime birth = Convert.ToDateTime(selectedRow.Cells["Ngàysinh"].Value);
                bool gioitinh = (selectedRow.Cells["Giớitính"].Value.ToString() == "Nam") ? true : false;

                string diachi = selectedRow.Cells["Địachỉ"].Value.ToString();
                int diemthuong = Convert.ToInt32(selectedRow.Cells["Điểmthưởng"].Value.ToString());
                string matkhau = selectedRow.Cells["Mậtkhẩu"].Value.ToString();




                HistoryInvoice chinhSuaForm = new HistoryInvoice(maKH, namekh);
                chinhSuaForm.Show();
            }
        }

        private void rdAll_CheckedChanged(object sender, EventArgs e)
        {
            if(rdAll.Checked)
            {
                LoadData();
            }
        }
        public List<object> GetCustomerInfoListNam(bool genderr)
        {
            List<tb_Customer> customerList = _customer.GetAccountsFromTable("tb_Customer");

            List<object> selectedCustomerInfoList = new List<object>();

            foreach (var customer in customerList)
            {
                if (customer.Gender == genderr)
                {
                    string gender = customer.Gender == true ? "Nữ" : "Nam";
                var customerInfo = new
                {
                    Mãkháchhàng = customer.CustomerID,
                    Tênkháchhàng = customer.Name,
                    Sốđiệnthoại = customer.PhoneNumber,
                    Giớitính = gender,
                    Ngàysinh = customer.Birthdate,
                    Địachỉ = customer.Address,
                    Điểmthưởng = customer.RewardPoints,
                    Mậtkhẩu = customer.Password
                };
               

                
                selectedCustomerInfoList.Add(customerInfo);
                }
            }

            return selectedCustomerInfoList;
        }
        public void switchGender()
        {
             
        }
        private void rdFilter_CheckedChanged(object sender, EventArgs e)
        {
           
        }
        public void setCBB()
        {
            cbbGender.Items.Add("Nam");
            cbbGender.Items.Add("Nữ");
            cbbGender.SelectedIndex = 0;
        }
        private void cbbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdFilter.Checked && cbbGender.SelectedValue == null)
            {
                if (rdFilter.Checked)
                {
                   
                    if (cbbGender.SelectedIndex == 0)
                    {
                        dataGridView1.DataSource = GetCustomerInfoListNam(false);
                    }

                    // Gọi hàm GetCustomerInfoListByGender với giới tính được xác định từ ComboBox

                    else if(cbbGender.SelectedIndex == 1) 
                    {
                        dataGridView1.DataSource = GetCustomerInfoListNam(true);

                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim(); // Lấy từ khóa tìm kiếm từ TextBox

            List<tb_Customer> customerList = _customer.GetAccountsFromTable("tb_Customer");

            var filteredCustomers = customerList.Where(c =>
                c.CustomerID.ToString().Contains(searchKeyword) ||
                c.Name.Contains(searchKeyword) ||
                c.PhoneNumber.Contains(searchKeyword) ||
                c.Birthdate.ToString().Contains(searchKeyword) ||
                c.Address.Contains(searchKeyword) ||
                c.RewardPoints.ToString().Contains(searchKeyword) 
            ).ToList();

            var selectedCustomerInfoList = filteredCustomers.Select(c => new {
                Mãkháchhàng = c.CustomerID,
                Tênkháchhàng = c.Name,
                Sốđiệnthoại = c.PhoneNumber,
                Giớitính = c.Gender==false ? "Nam" : "Nữ",
                Ngàysinh = c.Birthdate,
                Địachỉ = c.Address,
                Điểmthưởng = c.RewardPoints,
            }).ToList();

            dataGridView1.DataSource = selectedCustomerInfoList;

        }
    }
}
