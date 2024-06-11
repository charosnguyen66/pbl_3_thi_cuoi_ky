using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI.THUCDON
{
    public partial class ThemMoi : Form
    {
        Product _product;
        Category _category;
        private int ingredientCount = 1; // Đếm số lượng TextBox nguyên liệu hiện có
        private List<ComboBox> ingredientComboBoxes = new List<ComboBox>();

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
            if (ofd.ShowDialog() == DialogResult.OK)
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
                using (var context = new PBL3Entities())
                {
                    // Lấy danh sách IngredientID vào bộ nhớ
                    var ingredientIDs = context.tb_Ingredient
                        .Select(i => i.IngredientID)
                        .ToList();

                    // Lấy giá trị số lớn nhất từ IngredientID
                    int maxIngredientID = ingredientIDs
                        .Select(id => Regex.Match(id, @"\d+").Value)
                        .Where(id => !string.IsNullOrEmpty(id))
                        .Select(int.Parse)
                        .DefaultIfEmpty(0)
                        .Max();

                    // Thêm sản phẩm mới vào tb_Product
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
                    product.Price = Convert.ToDouble(txtPrice.Text);
                    product.AddedDate = DateTime.Now;
                    product.CategoryID = category.switchToID(cbbTheLoai.SelectedItem.ToString());
                    product.Description = txtDes.Text;
                    product.ImageProduct = convertFileToByte(this.pbMinhHoa.ImageLocation);

                    _product.AddNew(product);

                    // Thêm nguyên liệu vào tb_Ingredient từ TextBox
                    foreach (TextBox textBox in panelIngredients.Controls.OfType<TextBox>().ToList())
                    {
                        if (!string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            tb_Ingredient ingredient = new tb_Ingredient();
                            ingredient.IngredientID = "i" + (++maxIngredientID); // Tạo mã nguyên liệu theo số nguyên liên tiếp
                            ingredient.IngredientName = textBox.Text;
                            ingredient.ProductID = product.ProductID;
                            ingredient.Number = 1; // Giả sử số lượng là 1, bạn có thể thay đổi
                            ingredient.Price = 0; // Giả sử giá là 0, bạn có thể thay đổi

                            context.tb_Ingredient.Add(ingredient);
                            context.SaveChanges();
                        }
                    }

                    // Thêm nguyên liệu từ các ComboBox chọn nguyên liệu có sẵn
                    foreach (ComboBox comboBox in ingredientComboBoxes)
                    {
                        if (comboBox.SelectedItem != null)
                        {
                            tb_Ingredient selectedIngredient = comboBox.SelectedItem as tb_Ingredient;
                            tb_Ingredient ingredient = new tb_Ingredient();
                            ingredient.IngredientID = "i" + (++maxIngredientID); // Tạo mã nguyên liệu theo số nguyên liên tiếp
                            ingredient.IngredientName = selectedIngredient.IngredientName;
                            ingredient.ProductID = product.ProductID;
                            ingredient.Number = 1; // Giả sử số lượng là 1, bạn có thể thay đổi
                            ingredient.Price = selectedIngredient.Price;

                            context.tb_Ingredient.Add(ingredient);
                            context.SaveChanges();
                        }
                    }

                    DialogResult result = MessageBox.Show("Thêm món thành công! Bạn muốn quay lại trang trước không?", "Thông báo", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Hide();
                        MainViewAdmin f1 = new MainViewAdmin();
                        f1.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thêm mới món!\n" + ex.Message);
            }
        }

        private void ThemMoi_Load(object sender, EventArgs e)
        {
        }

        private void cbbTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            // Tạo TextBox mới cho nguyên liệu
            TextBox newTextBox = new TextBox();
            newTextBox.Name = "txtIngredient" + (++ingredientCount).ToString();
            newTextBox.Size = new System.Drawing.Size(100, 22);
            newTextBox.Location = new System.Drawing.Point(0, (ingredientCount - 1) * 30);

            // Thêm TextBox mới vào panelIngredients
            panelIngredients.Controls.Add(newTextBox);
        }

        private void btnSelectIngredient_Click(object sender, EventArgs e)
        {
            // Tạo ComboBox mới để chọn nguyên liệu có sẵn
            ComboBox newComboBox = new ComboBox();
            newComboBox.Name = "cbbIngredient" + (++ingredientCount).ToString();
            newComboBox.Size = new System.Drawing.Size(200, 22);
            newComboBox.Location = new System.Drawing.Point(0, (ingredientCount - 1) * 30);

            // Lấy danh sách nguyên liệu có sẵn từ cơ sở dữ liệu
            using (var context = new PBL3Entities())
            {
                var ingredients = context.tb_Ingredient.ToList();
                newComboBox.DataSource = ingredients;
                newComboBox.DisplayMember = "IngredientName";
                newComboBox.ValueMember = "IngredientID";
            }

            // Thêm ComboBox mới vào panelIngredients và danh sách ingredientComboBoxes
            panelIngredients.Controls.Add(newComboBox);
            ingredientComboBoxes.Add(newComboBox);
        }
    }
}
