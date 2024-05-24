using BusinessLayer.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI.USER.LichSuDat
{
    public partial class detailHistory : Form
    {
        private PBL3Entities _context;

        public detailHistory()
        {
            InitializeComponent();
            _context = new PBL3Entities();
        }

        public void LoadInvoiceDetails(string invoiceID)
        {
            // Truy vấn các chi tiết hóa đơn từ cơ sở dữ liệu dựa trên invoiceID
            var invoiceDetails = _context.tb_Invoice_Detail
                .Where(detail => detail.InvoiceID == invoiceID)
                .ToList() // Chuyển đổi truy vấn sang dạng List trong bộ nhớ
                .Select(detail => new DetailInvoice_DTO
                {
                    ProductName = detail.tb_Product.ProductName,
                    Price = (decimal)(detail.tb_Product.Price ?? 0), // Ép kiểu từ double? sang decimal
                    Quantity = detail.Quanlity ?? 0,
                    TotalPrice = (decimal)(detail.tb_Product.Price ?? 0) * (detail.Quanlity ?? 0)
                }).ToList();

            // Gán danh sách mới vào DataSource của DataGridView
            dataGridView1.DataSource = invoiceDetails;
        }
    }
}
