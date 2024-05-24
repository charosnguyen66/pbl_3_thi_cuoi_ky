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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI.Admin.Customer
{
    public partial class HistoryInvoice : Form
    {
        string _id, _name;
        public Account _customer;
        public Invoice _invoice;
        public Product _product;
        public HistoryInvoice(string id, string name)
        {
            InitializeComponent();
            _id  = id;
            _name = name;
            _customer = new Account();
            _invoice = new Invoice();
            _product = new Product();
            setView();
        }
        public List<object> GetInvoice()
        {
            List<tb_Customer> customerList = _customer.GetAccountsFromTable("tb_Customer");
            List<tb_Invoice> InvoicesList = _invoice.GetAccountsFromTable("tb_Invoice");
            List<tb_Product> productList = _product.GetProductsFromTable("tb_Product");
            List<object> selectedCustomerInfoList = new List<object>();
            
            foreach (var i in InvoicesList)
            {
                if(i.CustomerID == _id) {
                var customerInfo = new
                {
                    TênKH = customerList.FirstOrDefault(e => e.CustomerID == i.CustomerID)?.Name,
                    MãHĐ = i.InvoiceID,
                    Ngàyđặt = i.OrderDate,
                    Tìnhtrạng = i.Status,

                };

                selectedCustomerInfoList.Add(customerInfo);
                }
            }

            return selectedCustomerInfoList;
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string tenKH = selectedRow.Cells["TênKH"].Value.ToString();
                string maHD = selectedRow.Cells["MãHĐ"].Value.ToString();
                string tinhtrang = selectedRow.Cells["Tìnhtrạng"].Value.ToString();
                DateTime ngayDat = Convert.ToDateTime(selectedRow.Cells["Ngàyđặt"].Value);





                InvoiceDetail chinhSuaForm = new InvoiceDetail(_id, tenKH, maHD, tinhtrang, ngayDat);
                chinhSuaForm.Show();
            }
        }

        private void HistoryInvoice_Load(object sender, EventArgs e)
        {

        }

        public void setView()
        {
            txtName.Text = _name;
            dataGridView1.DataSource = GetInvoice();
            dataGridView1.RowTemplate.Height = 70;
            dataGridView1.Columns["TênKH"].Width = 170;
            dataGridView1.Columns["MãHĐ"].Width = 100;
            dataGridView1.Columns["Tìnhtrạng"].Width = 130;
            dataGridView1.Columns["Ngàyđặt"].Width = 170;
        }

    }
}
