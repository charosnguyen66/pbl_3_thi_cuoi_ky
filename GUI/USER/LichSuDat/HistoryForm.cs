using BusinessLayer;
using BusinessLayer.DTO;
using DataLayer;
using GUI.USER.DatBan;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            InitializeDataGridView();
            this.Text = "Lịch sử đặt bàn";
            _invoice = new Invoice();
            _context = new PBL3Entities();
            LoadToView();
        }
        private void InitializeDataGridView()
        {
            // Customize DataGridView appearance
            dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSlateGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                e.CellStyle.BackColor = Color.LightGray;
            }
            else
            {
                e.CellStyle.BackColor = Color.White;
            }
            e.CellStyle.ForeColor = Color.Black;
            e.CellStyle.Font = new Font("Century Gothic", 9, FontStyle.Regular);
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

                detailHistory detailForm = new detailHistory(selectedInvoiceID);
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
