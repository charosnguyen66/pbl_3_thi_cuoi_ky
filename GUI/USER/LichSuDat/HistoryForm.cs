using BusinessLayer;
using BusinessLayer.DTO;
using DataLayer;
using GUI.USER.DatBan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI.USER.LichSuDat
{
    public partial class HistoryForm : Form
    {
        private PBL3Entities _context;

        Invoice _invoice;
        public HistoryForm()
        {
            InitializeComponent();
            this.Text = "Lịch sử đặt bàn";
            _invoice = new Invoice();
            _context = new PBL3Entities();
            LoadToView();
        }

        private void LoadToView()
        {
            List<Invoice_DTO> list = _invoice.getInvoice();
            dataGridView1.DataSource = list;
        }

        private string GetPaymentMethodName(string paymentId)
        {
            var paymentMethod = _context.tb_Payment.FirstOrDefault(p => p.PaymentID == paymentId);
            return paymentMethod?.PaymentMethod ?? "Unknown";
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string selectedInvoiceID = dataGridView1.CurrentRow.Cells["InvoiceID"].Value.ToString();

                detailHistory detailForm = new detailHistory();
                detailForm.LoadInvoiceDetails(selectedInvoiceID);
                detailForm.Show();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string selectedInvoiceID = dataGridView1.CurrentRow.Cells["InvoiceID"].Value.ToString();

                try
                {
                    _invoice.Delete(selectedInvoiceID);
                    MessageBox.Show("Hóa đơn đã được hủy thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi hủy hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadToView();
            }
        }
    }
}
