using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Admin.Customer
{
    public partial class InvoiceDetail : Form
    {
        string _idKH, _nameKH, _maHD, _tinhTrang;
        DateTime _dateOrder;
        public Account _customer;
        public Invoice _invoice;
        public Product _product;
        public Invoice_Detail _ÌDetail;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
 
        public InvoiceDetail(string ma, string name, string maHD, string tinhTrang, DateTime ngayDat)
        {
            InitializeComponent();
            _idKH = ma;
            _nameKH = name; 
            _maHD = maHD;
           _tinhTrang = tinhTrang;
            _dateOrder = ngayDat;
            _invoice = new Invoice();
            _product = new Product();
            _ÌDetail = new Invoice_Detail();
            LoadView();

        }

        public void LoadView()
        {
           lblName.Text = _nameKH;
           lblDate.Text = _dateOrder.ToString();
            dataGridView1.DataSource = GetInvoice();
            dataGridView1.RowTemplate.Height = 70;
            dataGridView1.RowTemplate.Height = 70;
            dataGridView1.Columns["Tênmón"].Width = 170;
            dataGridView1.Columns["Sólương"].Width = 100;
            dataGridView1.Columns["Đơngiá"].Width = 130;
            dataGridView1.Columns["Thànhtiền"].Width = 220;
        }
        private void InvoiceDetail_Load(object sender, EventArgs e)
        {

        }
        public List<object> GetInvoice()
        {
            List<tb_Invoice> InvoicesList = _invoice.GetAccountsFromTable("tb_Invoice");
            List<tb_Product> productList = _product.GetProductsFromTable("tb_Product");
            List<tb_Invoice_Detail> IDetailList = _ÌDetail.GetAccountsFromTable("tb_Invoice_Detail");
            List<object> selectedCustomerInfoList = new List<object>();

            foreach (var i in IDetailList)
            {
                if (i.InvoiceID == _maHD)
                {
                    var customerInfo = new
                    {
                        Tênmón = productList.FirstOrDefault(e => e.ProductID == i.ProductID)?.ProductName,
                        Sólương = i.Quanlity,
                        Đơngiá = productList.FirstOrDefault(e => e.ProductID == i.ProductID)?.Price,
                        Thànhtiền = productList.FirstOrDefault(e => e.ProductID == i.ProductID)?.Price * i.Quanlity,
                    };

                    selectedCustomerInfoList.Add(customerInfo);
                }
            }

            return selectedCustomerInfoList;
        }
    }
}
