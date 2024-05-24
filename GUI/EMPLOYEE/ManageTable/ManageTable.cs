using BusinessLayer;
using BusinessLayer.DTO;
using DataLayer;
using GUI.USER.DatBan;
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
        private ucItem previousSelectedItem = null;

        public void LoadToView()
        {
            DateTime getTime = dateTimePicker1.Value;
            string formattedDate = getTime.ToString("dd/MM/yyyy");
            List<InvoiceOfCustomer> list = _invoice.GetAccountsFromTable12();
            pnMonAn.Controls.Clear();
            if (list != null)
            {
                foreach (var table in list)
                {
                    ucItem u = new ucItem
                    {
                        BackColor = Color.Coral,
                        nameKH = table.tenKH,
                        sdt = table.sdt,
                        diaChi = table.address,
                        maDonHang = table.InvoiceID,
                        banAn = table.maBan
                    };

                    pnMonAn.Controls.Add(u);
                    pnMonAn.Controls.Add(new Panel { Size = new Size(20, 20) }); // Spacer

                    // Đăng ký sự kiện OnSelect cho ucProduct
                    u.OnSelect += (sender, e) =>
                    {
                        btnThemMon.Visible = true;
                        btnThemMon.Tag = table;

                        // Đổi màu mục trước đó về màu ban đầu
                        if (previousSelectedItem != null)
                        {
                            previousSelectedItem.BackColor = Color.Coral;
                        }

                        // Cập nhật mục mới được chọn
                        u.BackColor = Color.Purple;
                        previousSelectedItem = u;
                    };
                }
            }
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            var selectedTable = btnThemMon.Tag as InvoiceOfCustomer;
            if (selectedTable != null)
            {
                string selectedOrderId = selectedTable.InvoiceID;
                string idBan = selectedTable.maBan;

                if (!string.IsNullOrEmpty(selectedOrderId))
                {
                    // Sử dụng selectedOrderId theo nhu cầu của bạn
                    MessageBox.Show("Mã ID đơn hàng đã chọn: " + selectedOrderId);
                    InvoiceSession.idOfInvoice = selectedOrderId;
                    InvoiceSession.inOfTable = idBan;
                    updateInvoice k = new updateInvoice(idBan, selectedOrderId);
                    k.Show();

                    List<tb_Invoice_Detail> listDetails = _ivDetail.GetAccountsFromTable("tb_InvoiceDetail");
                    foreach (tb_Invoice_Detail item in listDetails)
                    {
                        if (item.InvoiceID == selectedOrderId)
                        {
                            Product o = new Product();
                            tb_Product gett = o.getItem(item.ProductID);
                            ucProduct p = new ucProduct()
                            {
                                name = gett.ProductName,
                                Price = Convert.ToDouble(gett.Price),
                                id = gett.ProductID,
                                star = 1,
                                category = gett.CategoryID
                            };
                            k.AddProductToDataGridView(p);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một đơn hàng.");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            LoadToView();

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            foreach (Control control in pnMonAn.Controls)
            {
                if (control is ucItem pro)
                {
                    pro.Visible = pro.nameKH.ToLower().Contains(txtTimKiem.Text.Trim().ToLower());
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
