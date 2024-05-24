using BusinessLayer;
using BusinessLayer.DTO;
using DataLayer;
using GUI.USER.DatBan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.EMPLOYEE.ManageTable
{
    public partial class ManageTable : Form
    {
        Invoice _invoice;
        Invoice_Detail _ivDetail;
        public ManageTable()
        {
            InitializeComponent();
            _invoice = new Invoice();
            _ivDetail = new Invoice_Detail();
            LoadToView();
        }
        public void LoadToView()
        {
            DateTime getTime = dateTimePicker1.Value;
            string formattedDate = getTime.ToString("dd/MM/yyyy");
            List < InvoiceOfCustomer > list = _invoice.GetAccountsFromTable12();
            dataGridView1.DataSource = list;
        }
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            string selectedOrderId = "";
            string idBan = "";
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedOrderId = Convert.ToString(dataGridView1.SelectedRows[0].Cells["InvoiceID"].Value);
                idBan = Convert.ToString(dataGridView1.SelectedRows[0].Cells["maBan"].Value);
            }

            if (!string.IsNullOrEmpty(selectedOrderId))
            {
                // Sử dụng selectedOrderId theo nhu cầu của bạn
                MessageBox.Show("Mã ID đơn hàng đã chọn: " + selectedOrderId);
                InvoiceSession.idOfInvoice = selectedOrderId;
                InvoiceSession.inOfTable = idBan;
                updateInvoice k = new updateInvoice(idBan, selectedOrderId);
                k.Show();
                List<tb_Invoice_Detail> list = _ivDetail.GetAccountsFromTable("tb_InvoiceDetail");
                foreach(tb_Invoice_Detail item in list)
                {
                    if(item.InvoiceID == selectedOrderId) { 
                        Product o = new Product();
                        tb_Product gett = o.getItem(item.ProductID);
                    ucProduct p = new ucProduct()
                    {
                        name = gett.ProductName,
                        Price =Convert.ToDouble( gett.Price),
                        id = gett.ProductID,
                        star = 1,
                        category = gett.CategoryID
                    };
                    k.AddProductToDataGridView(p);
                    }
                }
                
                // Thực hiện các hành động khác với selectedOrderId
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            LoadToView();

        }
    }
}
