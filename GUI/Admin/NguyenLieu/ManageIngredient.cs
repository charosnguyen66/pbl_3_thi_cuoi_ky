using BusinessLayer;
using BusinessLayer.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class ManageIngredient : Form
    {
        private Ingredient _ingredient;
        private List<Ingredient_DTO> _ingredients;
        Product _product;
        public ManageIngredient()
        {
            InitializeComponent();
            _ingredient = new Ingredient();
            _product = new Product();
            LoadToView();
        }

        public void LoadToView()
        {
            _ingredients = _ingredient.GetSelectedIngredients();
            dataGridView1.DataSource = _ingredients;
            dataGridView1.Columns["IngredientID"].HeaderText = "Mã nguyên liệu";
            dataGridView1.Columns["Name"].HeaderText = "Tên nguyên liệu";
            dataGridView1.Columns["Number"].HeaderText = "Số lượng";
            dataGridView1.Columns["ProductName"].HeaderText = "Tên sản phẩm";
            dataGridView1.Columns["Note"].HeaderText = "Ghi chú";


            dataGridView1.Columns["IngredientID"].Width = 100; // Chiều rộng cột IngredientID là 100
            dataGridView1.Columns["Name"].Width = 200; // Chiều rộng cột Name là 200
            dataGridView1.Columns["Number"].Width = 80; // Chiều rộng cột Number là 80
            dataGridView1.Columns["ProductName"].Width = 250; // Chiều rộng cột ProductName là 250
            dataGridView1.Columns["Note"].Width = 150;
        }

        private void ManageIngredient_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Thêm logic để thêm nguyên liệu
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            var filteredIngredients = _ingredients
                .Where(i => i.Name.ToLower().Contains(searchText))
                .ToList();

            dataGridView1.DataSource = filteredIngredients;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // Lấy chỉ số của ô được chọn
                int selectedColumnIndex = dataGridView1.SelectedCells[0].ColumnIndex;
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                var selectedRow = dataGridView1.Rows[selectedRowIndex];
                var ingredientID = selectedRow.Cells["IngredientID"].Value?.ToString();

                // Lấy giá trị hiện tại của ô được chọn
                if (ingredientID != null &&
                    dataGridView1[selectedColumnIndex, selectedRowIndex].Value != null &&
                    int.TryParse(dataGridView1[selectedColumnIndex, selectedRowIndex].Value.ToString(), out int currentValue))
                {
                    // Hiển thị hộp thoại nhập giá trị Number
                    int number = 0;
                    if (InputBox.Show("Nhập số", "Vui lòng nhập số để cộng thêm:", ref number) == DialogResult.OK)
                    {
                        // Cộng thêm giá trị Number vào giá trị hiện tại
                        _ingredient.setNumberToIngredient(ingredientID, number);

                        LoadToView();
                    }
                }
                else
                {
                    MessageBox.Show("Giá trị của ô phải là số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một ô.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

 


    }
}
