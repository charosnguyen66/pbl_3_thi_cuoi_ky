using BusinessLayer;
using BusinessLayer.DTO;
using DataLayer;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace GUI.Admin.ThongKe
{
    public partial class ManageStatistic : Form
    {
        private Invoice_Detail _ivd;

        public ManageStatistic()
        {
            InitializeComponent();
            _ivd = new Invoice_Detail();
            setcbb();
            LoadToView();
        }
<<<<<<< HEAD

=======
>>>>>>> 64de7580e291ace885cd111372303e1c5a33b3ef
        public void setcbb()
        {
            cbb1.Items.Add("Theo món ăn");
            cbb1.Items.Add("Theo doanh thu");

            // Thiết lập giá trị cho cbbThang (comboBoxThang)
            for (int i = 1; i <= 12; i++)
            {
                cbbThang.Items.Add(i);
            }
        }
<<<<<<< HEAD

        public void LoadToView()
        {
            // Implement load logic if needed
=======
        public void LoadToView()
        {
            
>>>>>>> 64de7580e291ace885cd111372303e1c5a33b3ef
        }

        private void DisplayTopThreeItems(int targetMonth)
        {
            // Lấy thông tin của 3 mục hàng có doanh thu cao nhất trong tháng được chỉ định
            var top3Items = _ivd.getTop3ByMonth(targetMonth);

            var itemsData = new Dictionary<string, Dictionary<string, double>>();

            // Duyệt qua từng món hàng để lấy dữ liệu
            foreach (var item in top3Items)
            {
                // Chuyển đổi chuỗi ngày thành kiểu DateTime
<<<<<<< HEAD
=======

>>>>>>> 64de7580e291ace885cd111372303e1c5a33b3ef
                DateTime thoigianDateTime = DateTime.ParseExact(item.thoigian, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                string monthYear = thoigianDateTime.ToString("MM/yyyy");

                // Kiểm tra nếu món hàng đã tồn tại trong từ điển
                if (!itemsData.ContainsKey(item.tenMon))
                {
                    itemsData[item.tenMon] = new Dictionary<string, double>();
                }

                // Kiểm tra nếu tháng đã tồn tại trong danh sách
                if (!itemsData[item.tenMon].ContainsKey(monthYear))
                {
                    itemsData[item.tenMon][monthYear] = 0;
                }

                // Cộng doanh thu vào tháng đã tồn tại
                itemsData[item.tenMon][monthYear] += item.tongTien;
            }

            // Tạo danh sách các tháng duy nhất
            var months = itemsData.Values.SelectMany(d => d.Keys).Distinct().OrderBy(m => m).ToList();

            // Tạo Cartesian Chart
            chartMon.Series.Clear();
            chartMon.AxisX.Clear();
            chartMon.AxisY.Clear();

            // Thiết lập trục x
            chartMon.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = months
            });

            // Thiết lập trục y
            chartMon.AxisY.Add(new Axis
            {
                Title = "Total Revenue",
                LabelFormatter = value => value.ToString("N0") + " VND" // Định dạng tiền tệ VND
            });

            // Thêm dữ liệu cho từng món hàng
            foreach (var itemName in itemsData.Keys)
            {
                var revenues = new ChartValues<double>();
                foreach (var month in months)
                {
                    if (itemsData[itemName].ContainsKey(month))
                    {
                        revenues.Add(itemsData[itemName][month]);
                    }
                    else
                    {
                        revenues.Add(0);
                    }
                }

                chartMon.Series.Add(new ColumnSeries
                {
                    Title = itemName,
                    Values = revenues
                });
            }
        }

        private void cbb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb1.SelectedItem != null)
            {
                string selectedValue = cbb1.SelectedItem.ToString();
                if (selectedValue == "Theo món ăn")
                {
                    lblThang.Visible = true;
                    cbbThang.Visible = true;
<<<<<<< HEAD
                }
                else if (selectedValue == "Theo doanh thu")
                {
                    lblThang.Visible = false;
                    cbbThang.Visible = false;
=======

                    
                    // Không gọi DisplayTopThreeItems ở đây
                    // Thực hiện công việc khi chọn "Theo món ăn"
                }
                else if (selectedValue == "Theo doanh thu")
                {
                    // Thực hiện công việc khi chọn "Theo doanh thu"
>>>>>>> 64de7580e291ace885cd111372303e1c5a33b3ef
                }
            }
        }

        private void cbbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi người dùng chọn một tháng từ combobox cbbThang
            // Gọi phương thức DisplayTopThreeItems với tháng đã chọn
<<<<<<< HEAD
=======
          
>>>>>>> 64de7580e291ace885cd111372303e1c5a33b3ef
        }

        private void cbbThang_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbbThang.SelectedItem != null)
            {
                int selectedMonth;
                if (int.TryParse(cbbThang.SelectedItem.ToString(), out selectedMonth))
                {
                    List<THONGKE_DTO> list = _ivd.gett(selectedMonth);
                    dataGridView1.DataSource = list;
                    DisplayTopThreeItems(selectedMonth);
                }
            }
        }
    }
}
<<<<<<< HEAD
=======

>>>>>>> 64de7580e291ace885cd111372303e1c5a33b3ef
