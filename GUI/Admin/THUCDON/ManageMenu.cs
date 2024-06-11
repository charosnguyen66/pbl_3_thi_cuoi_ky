using BusinessLayer;
using DataLayer;
using GUI.THUCDON;
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

namespace GUI
{
    public partial class ManageMenu : Form
    {
        Product _product;
        Category _category;
        public ManageMenu()
        {
            InitializeComponent();
            _product = new Product();
            _category = new Category();
            LoadDataToView();
        }

        private void ManageMenu_Load(object sender, EventArgs e)
        {

        }

        public void LoadDataToView()
        {
            List<tb_Product> list = _product.GetProductsFromTable("tb_Product");
            List<tb_Category> categoryList = _category.GetAccountsFromTable("tb_Category");

            var selectedProducts = list.Select(p => new {
                Mãsảnphẩm =  p.ProductID ,
                TênSảnPhẩm =  p.ProductName ,
                Giá = p.Price,
                NgàyThêm =  p.AddedDate,
                NgàyChỉnh = p.DeleteDate,
                MôTả =   p.Description,
                HìnhẢnh =  p.ImageProduct,
                ThểLoại = categoryList.FirstOrDefault(c => c.CategoryID == p.CategoryID)?.CategoryName
            }).ToList();

            dataGridView1.RowTemplate.Height = 70;
            dataGridView1.DataSource = selectedProducts;
            var hinhAnhColumn = dataGridView1.Columns["HìnhẢnh"] as DataGridViewImageColumn;
            if (hinhAnhColumn != null)
            {
                // Đặt ImageLayout của cột hình ảnh thành StretchImage
                hinhAnhColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            }
            dataGridView1.Columns["Mãsảnphẩm"].Width = 0;
            dataGridView1.Columns["NgàyChỉnh"].Width = 0;
            dataGridView1.Columns["TênSảnPhẩm"].Width = 220;
            dataGridView1.Columns["Giá"].Width = 150; 
            dataGridView1.Columns["NgàyThêm"].Width = 150;
            dataGridView1.Columns["MôTả"].Width = 290; 
            dataGridView1.Columns["HìnhẢnh"].Width = 120;
            dataGridView1.Columns["ThểLoại"].Width = 190;
        }


        bool expand = false;
      

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemMoi k = new ThemMoi();
            k.Show();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string masp = selectedRow.Cells["Mãsảnphẩm"].Value.ToString();
                string namesp = selectedRow.Cells["TênSảnPhẩm"].Value.ToString();
                double price = Convert.ToDouble(selectedRow.Cells["Giá"].Value);
                DateTime addDate = Convert.ToDateTime(selectedRow.Cells["NgàyThêm"].Value);
                DateTime EditDate = Convert.ToDateTime(selectedRow.Cells["NgàyChỉnh"].Value);
                string des = selectedRow.Cells["MôTả"].Value.ToString();
                string theloai = selectedRow.Cells["ThểLoại"].Value.ToString();
                Image picture = null;

                if (selectedRow.Cells["HìnhẢnh"].Value != DBNull.Value)
                {
                    byte[] imageData = (byte[])selectedRow.Cells["HìnhẢnh"].Value;

                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        picture = Image.FromStream(ms);
                    }
                }

                // Khởi tạo form "Chỉnh sửa" và truyền dữ liệu qua constructor
                ChinhSua chinhSuaForm = new ChinhSua(masp,namesp, price, addDate, EditDate, des, theloai, picture);
                chinhSuaForm.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string masp = selectedRow.Cells["Mãsảnphẩm"].Value.ToString();

            _ = _product.Delete(masp);

            DialogResult result = MessageBox.Show("Xóa món thành công! Bạn muốn quay lại trang chủ không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                LoadDataToView();
                Hide();
                MainViewAdmin f1 = new MainViewAdmin();
                f1.Show();
            }
            else
            {
                LoadDataToView();
            }
        }






        private void button3_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim(); // Lấy từ khóa tìm kiếm từ TextBox

            List<tb_Product> productList = _product.GetProductsFromTable("tb_Product");

            var filteredProducts = productList.Where(p => p.ProductName.Contains(searchKeyword)).ToList();

            List<tb_Category> categoryList = _category.GetAccountsFromTable("tb_Category");

            var selectedProducts = filteredProducts.Select(p => new {
                Mãsảnphẩm = p.ProductID,
                TênSảnPhẩm = p.ProductName,
                Giá = p.Price,
                NgàyThêm = p.AddedDate,
                NgàyChỉnh = p.DeleteDate,
                MôTả = p.Description,
                HìnhẢnh = p.ImageProduct,
                ThểLoại = categoryList.FirstOrDefault(c => c.CategoryID == p.CategoryID)?.CategoryName
            }).ToList();

            dataGridView1.RowTemplate.Height = 70;
            dataGridView1.DataSource = selectedProducts;

            var hinhAnhColumn = dataGridView1.Columns["HìnhẢnh"] as DataGridViewImageColumn;
            if (hinhAnhColumn != null)
            {
                hinhAnhColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            }

            dataGridView1.Columns["Mãsảnphẩm"].Width = 0;
            dataGridView1.Columns["NgàyChỉnh"].Width = 0;
            dataGridView1.Columns["TênSảnPhẩm"].Width = 170;
            dataGridView1.Columns["Giá"].Width = 100;
            dataGridView1.Columns["NgàyThêm"].Width = 130;
            dataGridView1.Columns["MôTả"].Width = 220;
            dataGridView1.Columns["HìnhẢnh"].Width = 120;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

