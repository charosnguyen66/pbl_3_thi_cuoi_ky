using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI.THUCDON
{
    public partial class ThemMoi : Form
    {
        Product _product;
        Category _category;
        public ThemMoi()
        {
            InitializeComponent();
            _product = new Product();
            _category = new Category();
            _category.setCBB(cbbTheLoai);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Vui lòng chọn một hình ảnh";
            ofd.Filter = "JPG|*.jpg|PNG|*.png|GIF|*gif";

            ofd.Multiselect = false;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                this.pbMinhHoa.ImageLocation = ofd.FileName;
            }
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
                tb_Product product = new tb_Product();
                Category category = new Category();
                Random random = new Random();
                string randomNumbers = "";
                for (int i = 0; i < 3; i++)
                {
                    randomNumbers += random.Next(0, 10);
                }
                product.ProductID = "p" + randomNumbers;
                product.ProductName = txtName.Text;
                product.Price = Convert.ToDouble( txtPrice.Text);
                product.AddedDate = DateTime.Now;
                product.CategoryID = category.switchToID(cbbTheLoai.SelectedItem.ToString());
                product.Description = txtDes.Text;
                product.ImageProduct = convertFileToByte(this.pbMinhHoa.ImageLocation);

                _product.AddNew(product);
                DialogResult result = MessageBox.Show("Thêm món thành công! Bạn muốn quay lại trang trước không?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Hide();
                    MainViewAdmin f1 = new MainViewAdmin();
                    f1.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thêm mới món!");
            }
        }

        private void ThemMoi_Load(object sender, EventArgs e)
        {

        }

        private void cbbTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
