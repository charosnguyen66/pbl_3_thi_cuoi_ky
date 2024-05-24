using BusinessLayer;
using DataLayer;
using GUI.USER.DatBan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GUI.EMPLOYEE.ManageTable
{
    public partial class updateInvoice : Form
    {
        private int _detailCounter = 0;
        String _tableName = "";
        Category _category;
        Product _product;
        DiningTable _table;
        string _idInvoi;
        public updateInvoice(string nameTable = null, string id = null)
        {
            InitializeComponent();
            InitializeDataGridView();
            _tableName = nameTable;
            _category = new Category();
            _product = new Product();
            _idInvoi = id;
            _table = new DiningTable();
            categoryNames = GetCategoryNames();
            LoadCategory();
            LoadProduct();
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
            pnMonAn.Controls.Clear(); // Consider whether this is needed

            List<tb_Product> list = _product.GetProductsFromTable("tb_Product");
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
            pnMonAn.Controls.Clear(); // Consider whether this is needed

            List<tb_Product> list = _product.GetProductsByCategory1("tb_Product", id);
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
            string newID;
            using (var context = new PBL3Entities())
            {
                do
                {
                    newID = "CT" + new Random().Next(1000, 9999).ToString();
                } while (context.tb_Invoice_Detail.Any(detail => detail.ID == newID));
            }
            return newID;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Bạn có chắc chắn muốn thêm chi tiết hóa đơn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                string[] tableNames = _tableName.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Invoice u = new Invoice();
                string idKH="";
                List<tb_Invoice> list = u.GetAccountsFromTable("tb_Invoice");
                foreach(var i in list)
                {
                    if(i.InvoiceID == _idInvoi)
                    {
                        idKH = i.CustomerID;
                    }
                }
                using (var context = new PBL3Entities())
                {
                    try
                    {
                        var newInvoice = new tb_Invoice
                        {
                            InvoiceID = _idInvoi,
                            CustomerID = idKH,
                            OrderDate = DateTime.Now,
                            PaymentID = null,
                            Status = null,
                            TableID = _tableName,
                        };

                        if (tableNames.Length > 2)
                        {
                            newInvoice.Note = "Gộp các bàn" + _tableName;
                        }

                        context.tb_Invoice.AddOrUpdate(newInvoice);

                        foreach (DataGridViewRow row in dgvSP.Rows)
                        {
                            if (row.IsNewRow) continue;
                            string productID = row.Cells["ProductID"].Value?.ToString();
                            int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                            decimal discount = 0;
                            string detailID = this.GenerateNewIDDetail(); // Fully qualify the method call

                            var newDetail = new tb_Invoice_Detail
                            {
                                ID = detailID,
                                InvoiceID = _idInvoi,
                                ProductID = productID,
                                Quanlity = quantity,
                                Discount = discount
                            };

                            var ingredients = context.tb_Ingredient.Where(i => i.ProductID == productID).ToList();
                            foreach (var ingredient in ingredients)
                            {
                                if (ingredient.Number >= quantity)
                                {
                                    ingredient.Number -= quantity;
                                }
                                else
                                {
                                    throw new Exception($"Không đủ nguyên liệu cho sản phẩm {productID}");
                                }
                            }

                            context.tb_Invoice_Detail.Add(newDetail);
                        }
                  

                        context.SaveChanges();
                        MessageBox.Show("Chi tiết hóa đơn đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Có lỗi xảy ra: {ex.Message}\nChi tiết: {ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Thêm chi tiết hóa đơn đã bị hủy bỏ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
    }
}
