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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.EMPLOYEE.ManageTable
{
    public partial class ManageTable : Form
    {
        Invoice _invoice;
        DiningTable _diningTable;
        Invoice_Detail _ivDetail;
        public ManageTable()
        {
            InitializeComponent();
            _invoice = new Invoice();
            _ivDetail = new Invoice_Detail();
            _diningTable = new DiningTable();
        }
        private ucItem previousSelectedItem = null;

        public void LoadToView(DateTime d)
        {
            
            DateTime getTime = dateTimePicker1.Value;
            string formattedDate = getTime.ToString("dd/MM/yyyy");
            List<InvoiceOfCustomer> list = _invoice.GetAccountsFromTable12(d);
            pnMonAn.Controls.Clear();
            if (list != null)
            {
                foreach (var table in list)
                {
                    if(table.dess.Trim() == "0" || table.dess.Trim() == "Đã đặt")
                    {

                   
                    ucItem u = new ucItem
                    {
                        BackColor = Color.Coral,
                        nameKH = table.tenKH,
                        sdt = table.sdt,
                        diaChi = table.address,
                        maDonHang = table.InvoiceID,
                        banAn = table.maBan, 
                        desss = table.dess,
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
                        var selectedTable = btnThemMon.Tag as InvoiceOfCustomer;

                        List<Print_DTO> lisst = _invoice.getPrint(selectedTable.InvoiceID.Trim());
                        double tongCong = lisst.Sum(item => item.thanhTien);

                        lblTongTien.Text = tongCong.ToString("N0", new System.Globalization.CultureInfo("vi-VN")) + " đ";

                        // Cập nhật mục mới được chọn
                        u.BackColor = Color.Purple;
                        previousSelectedItem = u;
                    };
                    }
                }
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadToView(dateTimePicker1.Value);
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
        private void btnChuyen_Click(object sender, EventArgs e)
        {
            var selectedTable = btnThemMon.Tag as InvoiceOfCustomer;
            _invoice.changeStatus(selectedTable.InvoiceID);
            _diningTable.changeStatus1(selectedTable.listBan);
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            LoadToView(dateTimePicker1.Value);

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

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            var selectedTable = btnThemMon.Tag as InvoiceOfCustomer;

            if (selectedTable != null)
            {
                using (InputMoneyForm inputMoneyForm = new InputMoneyForm())
                {
                    if (inputMoneyForm.ShowDialog() == DialogResult.OK)
                    {
                        decimal moneyReceived = inputMoneyForm.MoneyReceived;

                        // Bạn có thể thêm mã logic xử lý số tiền ở đây nếu cần

                        HoaDon hoaDonForm = new HoaDon(selectedTable.InvoiceID);
                        hoaDonForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa nhập số tiền khách đưa vào.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn.");
            }
        }

        private void pnMonAn_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
