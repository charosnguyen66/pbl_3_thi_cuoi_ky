// OrderFood.cs
using BusinessLayer;
using DataLayer;
using FontAwesome.Sharp;
using GUI.Admin.Customer;
using GUI.USER.LichSuDat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCode;
namespace GUI.USER.DatBan
{
    public partial class OrderFood : Form
    {
        private int _detailCounter = 0;
        String _tableName = "";
        Category _category;
        Invoice _invoice;
        Product _product;
        Invoice_Detail _invoice_Detail;
        Ingredient _ingre;
        DiningTable _table;
        private bool isPaymentSelected = false;

        public OrderFood(string nameTable = null)
        {
            InitializeComponent();
            InitializeDataGridView();
            _tableName = nameTable;
            _category = new Category();
            _invoice = new Invoice();
            _ingre = new Ingredient();
            _product = new Product();
            _invoice_Detail = new Invoice_Detail();
            _table = new DiningTable();
            categoryNames = GetCategoryNames();
            LoadCategory();
            LoadCBB();
            LoadProduct();
        }
        public void LoadCBB()
        {
            cbbThanhToan.Items.Clear();
            cbbThanhToan.Items.Add(new ComboBoxItem { Text = "Vui lòng chọn", Value = "" });
            cbbThanhToan.Items.Add(new ComboBoxItem { Text = "Internet Banking", Value = "P1" });
            cbbThanhToan.Items.Add(new ComboBoxItem { Text = "Thanh toán trực tiếp", Value = "P2" });
            cbbThanhToan.SelectedIndex = 0;
        }

        private void InitializeDataGridView()
        {
            dgvSP.Columns.Clear(); // Xóa tất cả các cột hiện có nếu có

            dgvSP.Columns.Add("ProductID", "Mã sản phẩm");
            dgvSP.Columns.Add("ProductName", "Tên sản phẩm");
            dgvSP.Columns.Add("Price", "Đơn giá");
            dgvSP.Columns.Add("Quantity", "Số lượng");
            dgvSP.Columns.Add("CategoryName", "Tên thể loại");
        }

        private void LoadProduct()
        {
            pnMonAn.Controls.Clear();

            List<tb_Product> list = _product.GetAvailableProducts();
            if (list != null)
            {
                foreach (var table in list)
                {
                    ucProduct u = new ucProduct
                    {
                        BackColor = Color.Coral,
                        Price = (double)table.Price,
                        name = table.ProductName,
                        id = table.ProductID,
                        star = 1,
                        category = table.CategoryID
                    };

                    using (MemoryStream ms = new MemoryStream(table.ImageProduct))
                    {
                        u.image = Image.FromStream(ms);
                    }

                    pnMonAn.Controls.Add(u);
                    pnMonAn.Controls.Add(new Panel { Size = new Size(20, 20) }); // Spacer

                    // Đăng ký sự kiện OnSelect cho ucProduct
                    u.OnSelect += (sender, e) =>
                    {
                        AddProductToDataGridView(u);
                    };
                }
            }
        }

        private void LoadProduct(string id)
        {
            pnMonAn.Controls.Clear();

            List<tb_Product> list = _product.GetAvailableProductsByCategory(id);
            if (list != null)
            {
                foreach (var table in list)
                {
                    ucProduct u = new ucProduct
                    {
                        BackColor = Color.Coral,
                        Price = (double)table.Price,
                        name = table.ProductName,
                        id = table.ProductID,
                        star = 1,
                        category = table.CategoryID
                    };

                    using (MemoryStream ms = new MemoryStream(table.ImageProduct))
                    {
                        u.image = Image.FromStream(ms);
                    }

                    pnMonAn.Controls.Add(u);
                    pnMonAn.Controls.Add(new Panel { Size = new Size(20, 20) }); // Spacer

                    // Đăng ký sự kiện OnSelect cho ucProduct
                    u.OnSelect += (sender, e) =>
                    {
                        AddProductToDataGridView(u);
                    };
                }
            }
        }

        private void LoadCategory()
        {
            List<tb_Category> list = _category.GetAccountsFromTable();

            cbbTheLoai.Items.Clear();

            if (list != null)
            {
                cbbTheLoai.Items.Add(new ComboBoxItem { Text = "Tất cả", Value = null });

                foreach (var table in list)
                {
                    cbbTheLoai.Items.Add(new ComboBoxItem { Text = table.CategoryName.Trim(), Value = table.CategoryID });
                }

                cbbTheLoai.SelectedIndex = 0;

                cbbTheLoai.SelectedIndexChanged += (sender, e) =>
                {
                    ComboBox comboBox = sender as ComboBox;
                    if (comboBox.SelectedItem is ComboBoxItem selectedItem)
                    {
                        if (selectedItem.Value == null)
                        {
                            LoadProduct();
                        }
                        else
                        {
                            LoadProduct((string)selectedItem.Value);
                        }
                    }
                };
            }
        }

        // Lớp hỗ trợ cho các mục trong ComboBox
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private Dictionary<string, string> categoryNames;

        private Dictionary<string, string> GetCategoryNames()
        {
            List<tb_Category> categories = _category.GetAccountsFromTable();
            Dictionary<string, string> categoryNames = new Dictionary<string, string>();

            foreach (var category in categories)
            {
                categoryNames[category.CategoryID] = category.CategoryName.Trim();
            }

            return categoryNames;
        }

        public void AddProductToDataGridView(ucProduct product)
        {
            if (isPaymentSelected)
            {
                MessageBox.Show("Bạn không thể thêm món khi đã chọn thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra xem có đủ nguyên liệu cho sản phẩm không
            if (!_ingre.setIngrdient(product.id, 1))
            {
                MessageBox.Show($"Không đủ nguyên liệu cho sản phẩm {product.name}. Vui lòng chọn sản phẩm khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Không thêm sản phẩm vào DataGridView nếu không đủ nguyên liệu
            }

            bool productExists = false;

            // Duyệt qua các hàng trong DataGridView để kiểm tra xem sản phẩm đã tồn tại chưa
            foreach (DataGridViewRow row in dgvSP.Rows)
            {
                if (row.Cells["ProductID"].Value?.ToString() == product.id)
                {
                    // Nếu sản phẩm đã tồn tại, tăng số lượng lên
                    int currentQuantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    row.Cells["Quantity"].Value = currentQuantity + 1;
                    productExists = true;
                    break;
                }
            }

            // Nếu sản phẩm chưa tồn tại, thêm dòng mới
            if (!productExists)
            {
                int rowIndex = dgvSP.Rows.Add();
                DataGridViewRow newRow = dgvSP.Rows[rowIndex];

                newRow.Cells["ProductID"].Value = product.id;
                newRow.Cells["ProductName"].Value = product.name;
                newRow.Cells["Price"].Value = product.Price;
                newRow.Cells["Quantity"].Value = 1; // Khởi tạo số lượng là 1

                // Lấy tên thể loại từ từ điển
                if (categoryNames.TryGetValue(product.category, out string categoryName))
                {
                    newRow.Cells["CategoryName"].Value = categoryName;
                }
                else
                {
                    newRow.Cells["CategoryName"].Value = "Unknown"; // Hoặc xử lý khác nếu không tìm thấy
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            foreach (Control control in pnMonAn.Controls)
            {
                if (control is ucProduct pro)
                {
                    pro.Visible = pro.name.ToLower().Contains(txtTimKiem.Text.Trim().ToLower());
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSP.SelectedRows.Count > 0)
            {
                // Xác nhận hàng mới nếu có
                dgvSP.EndEdit();

                try
                {
                    // Xóa hàng được chọn
                    foreach (DataGridViewRow row in dgvSP.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            dgvSP.Rows.Remove(row);
                        }
                    }
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Không thể xóa hàng mới chưa được xác nhận. Vui lòng xác nhận hàng trước khi xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public string GenerateNewInvoiceID()
        {
            Invoice invoiceService = new Invoice();
            string lastInvoiceID = invoiceService.GetLastInvoiceID();

            if (string.IsNullOrEmpty(lastInvoiceID))
            {
                return "HD01"; // Nếu không có hóa đơn nào, bắt đầu từ HD01
            }

            string numberPart = lastInvoiceID.Substring(2);
            int number = int.Parse(numberPart);

            number++;

            return "HD" + number.ToString("D2");
        }

        public void SaveChangesWithValidation(PBL3Entities context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        sb.AppendLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }

                throw new Exception(sb.ToString(), ex);
            }
            catch (DbUpdateException ex)
            {
                StringBuilder sb = new StringBuilder();

                Exception innerException = ex.InnerException;
                while (innerException != null)
                {
                    sb.AppendLine(innerException.Message);
                    innerException = innerException.InnerException;
                }

                throw new Exception("An error occurred while updating the entries. See the inner exception for details: " + sb.ToString(), ex);
            }
        }

        private string GenerateNewIDDetail()
        {
            Invoice_Detail invoiceService = new Invoice_Detail();
            string lastInvoiceID = invoiceService.GetLastInvoiceID();

            if (string.IsNullOrEmpty(lastInvoiceID))
            {
                return "CT01"; // Nếu không có hóa đơn nào, bắt đầu từ HD01
            }

            string numberPart = lastInvoiceID.Substring(2);
            int number = int.Parse(numberPart);

            number++;

            return "CT" + number.ToString("D2");
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Bạn có chắc chắn muốn thêm chi tiết hóa đơn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                string[] tableNames = _tableName.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string invoiceID = GenerateNewInvoiceID();

                // Get the selected payment method
                string paymentID = "";
                if (cbbThanhToan.SelectedItem is ComboBoxItem selectedItem)
                {
                    paymentID = selectedItem.Value.ToString();
                }

                try
                {
                    var newInvoice = new tb_Invoice
                    {
                        InvoiceID = invoiceID,
                        CustomerID = UserSession.UserID,
                        OrderDate = DateTime.Now,
                        PaymentID = paymentID,
                        Status = "Đã đặt",
                        ReserveDate = TimeOrde.dateNhan,
                        TableID = tableNames[0].Trim(),
                        Note = _tableName
                    };

                    _invoice.AddNew(newInvoice);
                    foreach (DataGridViewRow row in dgvSP.Rows)
                    {
                        string productID = row.Cells["ProductID"].Value?.ToString();
                        if (string.IsNullOrEmpty(productID)) continue;

                        int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                        string detailID = GenerateNewIDDetail();
                        var newDetail = new tb_Invoice_Detail
                        {
                            ID = detailID,
                            InvoiceID = invoiceID,
                            ProductID = productID,
                            Quanlity = quantity,
                        };
                        _ingre.setIngrdient(productID, quantity);
                        foreach (var i in tableNames)
                        {
                            _table.changeStatus(i);
                        }

                        _invoice_Detail.AddNew(newDetail);
                    }

                    _invoice.SaveChangesWithValidation();

                }
                catch (Exception ex)
                {
                    var innerExceptionMessage = GetInnerExceptionMessages(ex);
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}\nChi tiết: {innerExceptionMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.ToString());
                }

                MessageBox.Show("Đặt món thành công, Cám ơn quý khách đã ủng hộ chúng tôi. Vui lòng xem thông tin để đến đúng giờ");
            }
        }

        private string GetInnerExceptionMessages(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            Exception inner = ex;
            while (inner != null)
            {
                sb.AppendLine(inner.Message);
                inner = inner.InnerException;
            }
            return sb.ToString();
        }


        private void UpdateIngredientQuantity(PBL3Entities context, string productID, int quantity)
        {
            var ingredients = context.tb_Ingredient.Where(i => i.ProductID == productID).ToList();
            foreach (var ingredient in ingredients)
            {
                ingredient.Number -= quantity;
            }
            context.SaveChanges();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pnMonAn_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbbThanhToan_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbbThanhToan.SelectedItem.ToString() != "Vui lòng chọn")
    {
        isPaymentSelected = true;
        pnMonAn.Enabled = false; // Disable product panel

        if (cbbThanhToan.SelectedItem.ToString() == "Internet Banking")
        {
            GenerateAndDisplayQrCode();
        }
    }
    else
    {
        isPaymentSelected = false;
        pnMonAn.Enabled = true; // Enable product panel
    }
        }
      

        private void GenerateAndDisplayQrCode()
        {
            // Example QR code content, replace with actual payment information
            string qrCodeContent = "Internet Banking Payment Information";

            // Generate QR code
            var qrGenerator = new QRCoder.QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(qrCodeContent, QRCoder.QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCoder.QRCode(qrCodeData);

            // Convert QR code to bitmap
            using (var qrCodeBitmap = qrCode.GetGraphic(20))
            {
                // Open the new form and display the QR code
                QrCodeForm qrCodeForm = new QrCodeForm(new Bitmap(qrCodeBitmap));
                qrCodeForm.ShowDialog();
            }
        }

        private void OrderFood_Load(object sender, EventArgs e)
        {

        }
    }
    }
