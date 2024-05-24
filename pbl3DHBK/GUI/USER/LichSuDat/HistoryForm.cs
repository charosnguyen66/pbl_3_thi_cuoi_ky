using DataLayer;
using GUI.USER.DatBan;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI.USER.LichSuDat
{
    public partial class HistoryForm : Form
    {
        private PBL3Entities _context;

        public HistoryForm()
        {
            InitializeComponent();
            this.Text = "Lịch sử đặt bàn";
            _context = new PBL3Entities();
            LoadToView();
        }

        private void LoadToView()
        {
            // Giả sử UserSession.UserID chứa ID của khách hàng hiện tại
            string customerId = UserSession.UserID;

            // Truy vấn các đơn đặt bàn theo ID khách hàng từ cơ sở dữ liệu
            var invoices = _context.tb_Invoice
                                   .Where(inv => inv.CustomerID == customerId)
                                   .ToList();

            // Tạo danh sách mới chứa các thuộc tính bạn muốn hiển thị
            var dataToShow = invoices.Select(inv => new
            {
                InvoiceID = inv.InvoiceID,
                OrderDate = inv.OrderDate,
                PaymentMethod = GetPaymentMethodName(inv.PaymentID), // Lấy phương thức thanh toán thay vì ID
                Status = inv.Status,
                Note = inv.Note,
                TableID = inv.TableID,
            }).ToList();

            // Gán danh sách mới vào DataSource của DataGridView
            dataGridView1.DataSource = dataToShow;
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
