using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI.THUCDON
{
    public partial class ChinhSua : Form
    {
        Category _category;
        Product _product;
        string _masp;
        Image pic;
        DateTime _add;
        string theLoai;
        public ChinhSua(string masp, string namesp, double price, DateTime addDate, DateTime edit, string des, string theloai, Image picture)
        {
            InitializeComponent();

            _product = new Product();
            _masp = masp;
            _category = new Category();
            txtName.Text = namesp;
            txtPrice.Text = price.ToString();
            txtDes.Text = des;
            _category.setCBB(cbbTheLoai);
           cbbTheLoai.SelectedIndex = cbbTheLoai.FindStringExact(theloai.Trim());
            theLoai = theloai.Trim();
            _add = addDate;
          pbMinhHoa.Image = picture;
            pic = picture;
        }
        private byte[] convertFileToByte(string path)
        {
            byte[] data = null;
            FileInfo fIn = new FileInfo(path);
            long num = fIn.Length;
            FileStream fStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)num);
            return data;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                tb_Product up = new tb_Product();
                up.ProductID = _masp;
                up.ProductName = txtName.Text;
                up.Price = Convert.ToDouble(txtPrice.Text);
                up.Description = txtDes.Text;
                string selectedCategory = cbbTheLoai.SelectedItem?.ToString();
                List<tb_Category> categoryList = _category.GetAccountsFromTable("tb_Category");

                tb_Category category = categoryList.FirstOrDefault(c => c.CategoryName.Trim() == selectedCategory);

                if (category != null)
                {
                    up.CategoryID = category.CategoryID;
                }
                up.DeleteDate = DateTime.Now;
                up.AddedDate = _add;
                up.ImageProduct = convertFileToByte(this.pbMinhHoa.ImageLocation); ;
                _product.Update(up);

                DialogResult result = MessageBox.Show("Cập nhật món thành công! Bạn muốn quay lại trang chủ không?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Hide();
                    MainViewAdmin f1 = new MainViewAdmin();
                    f1.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình cập nhật sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Vui lòng chọn một hình ảnh";
            ofd.Filter = "JPG|*.jpg|PNG|*.png|GIF|*gif";

            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.pbMinhHoa.ImageLocation = ofd.FileName;
            }
        }

        private void ChinhSua_Load(object sender, EventArgs e)
        {

        }

        private void pbMinhHoa_Click(object sender, EventArgs e)
        {

        }
    }
}
