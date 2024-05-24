using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ManageStatistic : Form
    {
        public ManageStatistic()
        {

            InitializeComponent();
            InitializeComboBox();
            InitializeDataGridView();
        }

        private void ManageStatistic_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

        }
        private void InitializeComboBox()
        {
            // Thêm các mục vào ComboBox
            comboBoxThongKe.Items.Add("Doanh số");
            comboBoxThongKe.Items.Add("Món ăn");
            comboBoxThongKe.Items.Add("Chi phí nguyên liệu");
            comboBoxThongKe.Items.Add("Đánh giá khách hàng");

            // Đặt mục mặc định
            comboBoxThongKe.SelectedIndex = 0;

            // Đăng ký sự kiện SelectedIndexChanged
            comboBoxThongKe.SelectedIndexChanged += comboBoxThongKe_SelectedIndexChanged;
        }

        private void InitializeDataGridView()
        {
            // Thiết lập cấu trúc ban đầu cho DataGridView nếu cần

            dataGridView.ColumnCount = 4; // Giả sử luôn có 4 cột
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //đặt chiều cao khớp với dữ liệu 
            dataGridView.Height = dataGridView.ColumnHeadersHeight + dataGridView.Rows.GetRowsHeight(DataGridViewElementStates.Visible) ;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AllowUserToAddRows = false;
        }


        private void comboBoxThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy mục được chọn
            string selectedValue = comboBoxThongKe.SelectedItem.ToString();

            // Thực hiện hành động dựa trên mục được chọn
            switch (selectedValue)
            {
                case "Doanh số":
                    SetDoanhSoColumns();
                    ShowDoanhSo();
                    break;
                case "Món ăn":
                    SetMonAnColumns();
                    ShowMonAn();
                    break;
                case "Chi phí nguyên liệu":
                    SetChiPhiNguyenLieuColumns();
                    ShowChiPhiNguyenLieu();
                    break;
                case "Đánh giá khách hàng":
                    SetDanhGiaKhachHangColumns();
                    ShowDanhGiaKhachHang();
                    break;
            }
        }

        private void SetDoanhSoColumns()
        {
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("TenMon", "Tên món");
            dataGridView.Columns.Add("DonGia", "Đơn giá");
            dataGridView.Columns.Add("SoDon", "Số đơn");
            dataGridView.Columns.Add("DoanhSo", "Doanh số");
        }

        private void SetMonAnColumns()
        {
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("TenMon", "Tên món");
            dataGridView.Columns.Add("MoTa", "Mô tả");
            dataGridView.Columns.Add("Gia", "Giá");
        }

        private void SetChiPhiNguyenLieuColumns()
        {
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("NguyenLieu", "Nguyên liệu");
            dataGridView.Columns.Add("SoLuong", "Số lượng");
            dataGridView.Columns.Add("ChiPhi", "Chi phí");
        }

        private void SetDanhGiaKhachHangColumns()
        {
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("KhachHang", "Khách hàng");
            dataGridView.Columns.Add("DanhGia", "Đánh giá");
            dataGridView.Columns.Add("NgayDanhGia", "Ngày đánh giá");
        }

        private void ShowDoanhSo()
        {
            // Cập nhật dữ liệu cho DataGridView
            dataGridView.Rows.Clear();
            dataGridView.Rows.Add("Bánh tráng trộn", "49.000", "30", "1.470.000");
            dataGridView.Rows.Add("Lẩu ếch", "149.000", "20", "2.980.000");
            dataGridView.Rows.Add("Gà quay", "229.000", "15", "3.450.000");
            dataGridView.Rows.Add("Cơm chiên", "49.000", "10", "490.000");
        }

        private void ShowMonAn()
        {
            dataGridView.Rows.Clear();
            // Thêm dữ liệu liên quan đến món ăn
            dataGridView.Rows.Add("Bánh tráng trộn", "Món ăn vặt phổ biến", "49.000");
            dataGridView.Rows.Add("Lẩu ếch", "Món lẩu đặc biệt", "149.000");
            dataGridView.Rows.Add("Gà quay", "Gà quay ngon", "229.000");
            dataGridView.Rows.Add("Cơm chiên", "Cơm chiên Dương Châu", "49.000");
        }

        private void ShowChiPhiNguyenLieu()
        {
            dataGridView.Rows.Clear();
            // Thêm dữ liệu liên quan đến chi phí nguyên liệu
            dataGridView.Rows.Add("Thịt gà", "10 kg", "500.000");
            dataGridView.Rows.Add("Rau củ", "20 kg", "300.000");
            dataGridView.Rows.Add("Gia vị", "5 kg", "100.000");
        }

        private void ShowDanhGiaKhachHang()
        {
            dataGridView.Rows.Clear();
            // Thêm dữ liệu liên quan đến đánh giá khách hàng
            dataGridView.Rows.Add("Nguyễn Văn A", "Rất ngon", "01/01/2024");
            dataGridView.Rows.Add("Trần Thị B", "Bình thường", "02/01/2024");
            dataGridView.Rows.Add("Lê Văn C", "Tuyệt vời", "03/01/2024");
        }
    }
   }
    