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
    }
}
