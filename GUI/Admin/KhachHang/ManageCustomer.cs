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
       

        public void LoadData()
        {
            Console.WriteLine("LoadData method called"); // Kiểm tra xem phương thức có được gọi không
            Account _c = new Account();
            List<object> customerInfoList = _c.GetCustomerInfoList();
            if (customerInfoList != null)
            {
                Console.WriteLine("Data loaded successfully"); // Kiểm tra xem dữ liệu có được nạp không

                dataGridView1.DataSource = customerInfoList;

                // Kiểm tra và đặt chiều rộng cho các cột nếu chúng tồn tại
                SetColumnWidth(dataGridView1, "Mậtkhẩu", 0);
                SetColumnWidth(dataGridView1, "Điểmthưởng", 170);
                SetColumnWidth(dataGridView1, "Địachỉ", 250);
                SetColumnWidth(dataGridView1, "Ngàysinh", 160);
                SetColumnWidth(dataGridView1, "Giớitính", 120);
                SetColumnWidth(dataGridView1, "Sốđiệnthoại", 170);
                SetColumnWidth(dataGridView1, "Tênkháchhàng", 270);
                SetColumnWidth(dataGridView1, "Mãkháchhàng", 150);
                dataGridView1.RowTemplate.Height = 40;
            }
            else
            {
                Console.WriteLine("No data found"); // Kiểm tra khi không có dữ liệu
            }
        }

        private void SetColumnWidth(DataGridView dgv, string columnName, int width)
        {
            if (dgv.Columns[columnName] != null)
            {
                dgv.Columns[columnName].Width = width;
                Console.WriteLine($"Column {columnName} width set to {width}"); // Kiểm tra tên và chiều rộng của cột
            }
            else
            {
                Console.WriteLine($"Column {columnName} not found"); // Kiểm tra khi cột không tồn tại
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Button1 clicked"); // Kiểm tra xem sự kiện có được kích hoạt không
            LoadData();
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


            

                ChinhSuaKH chinhSuaForm = new ChinhSuaKH(maKH, namekh, sdt, gioitinh,birth, diachi, diemthuong);
                chinhSuaForm.Show();
            }
        }
      

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string masp = selectedRow.Cells["Mãkháchhàng"].Value.ToString();
            _customer.Delete(masp.Trim());

            DialogResult result = MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
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
                up.Password = HashCode.HashPassword( selectedRow.Cells["Mãkháchhàng"].Value.ToString());
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

                // Kiểm tra xem có hóa đơn nào trong cơ sở dữ liệu với maKH không
                using (var context = new PBL3Entities())
                {
                    var invoices = context.tb_Invoice.Where(i => i.CustomerID == maKH).ToList();
                    if (invoices.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn nào cho khách hàng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                // Nếu tìm thấy hóa đơn, mở form HistoryInvoice
                HistoryInvoice chinhSuaForm = new HistoryInvoice(maKH, namekh);
                chinhSuaForm.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button2_Click(object sender, EventArgs e)
        {

            LoadData();

        }
    }
}
