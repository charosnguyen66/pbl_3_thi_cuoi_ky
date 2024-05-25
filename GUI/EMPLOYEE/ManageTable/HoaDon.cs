using BusinessLayer;
using BusinessLayer.DTO;
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

namespace GUI.EMPLOYEE.ManageTable
{
    public partial class HoaDon : Form
    {
        Invoice _invoice;
        string _id;
        public HoaDon(string k = null)
        {
            InitializeComponent();
            _invoice = new Invoice();
            _id = k;
            LoadToView();
        }
        public void LoadToView()
        {
            // Lấy danh sách Print_DTO từ cơ sở dữ liệu dựa trên _id
            List<Print_DTO> list = _invoice.getPrint(_id.Trim());
            dataGridView1.DataSource = list;

            // Điều chỉnh chiều rộng của các cột
            dataGridView1.Columns["tenMon"].Width = 200; // Độ rộng cho cột "tenMon" là 200 pixel
            dataGridView1.Columns["soLuong"].Width = 100; // Độ rộng cho cột "soLuong" là 100 pixel
            dataGridView1.Columns["donGia"].Width = 150; // Độ rộng cho cột "donGia" là 150 pixel
            dataGridView1.Columns["thanhTien"].Width = 150; // Độ rộng cho cột "thanhTien" là 150 pixel

            // Định dạng số tiền với dấu phân cách hàng nghìn
            dataGridView1.Columns["donGia"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["thanhTien"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["donGia"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("vi-VN");
            dataGridView1.Columns["thanhTien"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("vi-VN");

            // Lấy danh sách hóa đơn từ cơ sở dữ liệu
            List<tb_Invoice> lis = _invoice.GetAccountsFromTable("");
            foreach (tb_Invoice li in lis)
            {
                if (li.InvoiceID.Trim() == _id.Trim())
                {
                    lblBan.Text = li.Note;
                    lblGioRa.Text = DateTime.Now.ToString();
                    lblGioVao.Text = li.ReserveDate;

                    using(PBL3Entities db = new PBL3Entities()) {
                    var customer = db.tb_Customer.SingleOrDefault(c => c.CustomerID == li.CustomerID);
                    if (customer != null)
                    {
                        lblSDT.Text = customer.PhoneNumber;
                        lblTenKH.Text = customer.Name;
                    }
                }
            }

              
            }
            double tongCong = list.Sum(item => item.thanhTien);

            lblTongCong.Text = tongCong.ToString("N0", new System.Globalization.CultureInfo("vi-VN")) +" đ";

            lblKhachDua.Text = InvoiceSession.tienKhachDua.ToString("N0", new System.Globalization.CultureInfo("vi-VN")) + " đ";

            double tienThua = (double)InvoiceSession.tienKhachDua - tongCong;
            lblTienThua.Text = tienThua.ToString("N0", new System.Globalization.CultureInfo("vi-VN")) + " đ";

        }
    }
}
