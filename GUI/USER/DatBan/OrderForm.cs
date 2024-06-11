using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace GUI.USER.DatBan
{
    public partial class OrderForm : Form
    {
        DiningTable _table;
        
        public OrderForm()
        {
            InitializeComponent();
            this.Text = "Đặt bàn trực tuyến";
            _table = new DiningTable();
            pnTable.Dock = DockStyle.Fill;
            pnTable.AutoScroll = true;
           
            //LoadToView();
        }
        public void LoadToView()
        {
            
            List<tb_DiningTable> list = _table.GetAccountsFromTable("tb_DiningTable");
            pnTable.Controls.Clear();
            if (list != null)
            {
                MessageBox.Show("Da qua ktr");

                foreach (var i in list)
                {
                    if(i.Description.Trim() == "0") { 

                    UserControl1 u = new UserControl1();
                   
                        u.BackColor = Color.Chocolate;

                    
                  

                    u.Size = new Size(102, 142);

                    u.TableName = i.TableID.ToString().Trim();
                    u.Click += (sender, e) =>
                    {
                        // Hiển thị thông báo đã chọn
                        MessageBox.Show("Đã chọn bàn " + (sender as UserControl1).TableName);
                    };
                    pnTable.Controls.Add(u);

                    Panel spacer = new Panel();
                    spacer.Size = new Size(100, 100); // Kích thước của khoảng cách, có thể điều chỉnh
                    pnTable.Controls.Add(spacer);
                    }
                }
            }
        }
        private void OrderForm_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

            OrderFood k = new OrderFood();
            k.Show();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Close();

            // Mở FoodForm và thêm vào vị trí của OrderForm
            MainViewCustomer mainViewCustomer = this.ParentForm as MainViewCustomer;
            if (mainViewCustomer != null)
            {
                mainViewCustomer.ActivateButton(iconButton2, RGBColors.color2); // Kích hoạt nút tương ứng trên thanh menu
                mainViewCustomer.OpenChildForm(new OrderFood());
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            List<tb_DiningTable> list = _table.GetAccountsFromTable("tb_DiningTable");
            pnTable.Controls.Clear();

            if (list != null)
            {
                int a = list.Max(table => table.NumberPerson);
                bool b = true;
                int number;
                while (true)
                {
                    try
                    {
                        number = Convert.ToInt32(txtNumber.Text.Trim());
                        b = number > a;
                        break; // Thoát khỏi vòng lặp nếu không có ngoại lệ
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Vui lòng nhập đúng định dạng số!");
                        txtNumber.Focus(); // Đặt con trỏ vào hộp nhập liệu để người dùng nhập lại
                        txtNumber.SelectAll(); // Chọn tất cả nội dung hiện tại để người dùng có thể xóa hoặc sửa đổi dễ dàng
                        return; // Thoát khỏi phương thức để chờ sự kiện nhấp lại
                    }
                }

                if (!b)
                {
                    List<UserControl1> userControls = new List<UserControl1>();

                    foreach (var table in list)
                    {
                        if (table.NumberPerson >= Convert.ToInt32(txtNumber.Text.Trim()))
                        {
                            if(table.Description.Trim() == "0") {
                            UserControl1 u = new UserControl1
                            {
                                BackColor = Color.Chocolate,
                                Size = new Size(102, 142),
                                TableName = table.TableID.ToString().Trim()
                            };

                            pnTable.Controls.Add(u);

                            Panel spacer = new Panel { Size = new Size(100, 100) };
                            pnTable.Controls.Add(spacer);

                            userControls.Add(u);
                            }
                        }
                    }
                    //123
                    foreach (var u in userControls)
                    {
                        u.Click += (ui, ee) =>
                        {
                            DialogResult result = MessageBox.Show(
                                "Bạn có muốn đặt bàn " + (ui as UserControl1).TableName + " không?",
                                "Xác nhận đặt bàn",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                MainViewCustomer mainViewCustomer = this.ParentForm as MainViewCustomer;
                                if (mainViewCustomer != null)
                                {
                                    string time = timeNhan.Value.ToString("HH:mm"); // Lấy giờ và phút từ DateTimePicker1
                                    string date = dateNhan.Value.ToString("dd/MM/yyyy"); // Lấy ngày, tháng và năm từ DateTimePicker2
                                    string dateTimeString = time + " " + date; // Kết hợp giờ và phút với ngày, tháng và năm
                                    TimeOrde.dateNhan = dateTimeString;

                                     //MessageBox.Show(dateTimeString);
                                    mainViewCustomer.ActivateButton(iconButton2, RGBColors.color2);
                                    mainViewCustomer.OpenChildForm(new OrderFood((ui as UserControl1).TableName));
                                }
                                this.Close();
                            }
                        };
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Rất tiếc, Chúng tôi không có bàn với số lượng người lớn như vậy. Bạn có muốn ghép bàn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        List<tb_DiningTable> sortedList = list.OrderByDescending(table => table.NumberPerson).ToList();

                        if (sortedList.Any())
                        {
                            int requiredPersons = Convert.ToInt32(txtNumber.Text.Trim());
                            int totalPersons = 0;
                            int minTables = 0;
                            string selectedTables = "";

                            foreach (var table in sortedList)
                            {
                                if (totalPersons >= requiredPersons)
                                {
                                    break;
                                }

                                selectedTables += table.TableID + ", ";
                                totalPersons += table.NumberPerson;
                                minTables++;
                            }

                            selectedTables = selectedTables.TrimEnd(',', ' ');

                            if (totalPersons >= requiredPersons)
                            {
                                int minDifference = int.MaxValue;
                                int minTotal = 0;
                                string minSelectedTables = "";

                                for (int i = 0; i <= sortedList.Count - minTables; i++)
                                {
                                    int currentTotal = 0;
                                    string currentSelectedTables = "";
                                    for (int j = 0; j < minTables; j++)
                                    {
                                        currentTotal += sortedList[i + j].NumberPerson;
                                        currentSelectedTables += sortedList[i + j].TableID.Trim() + ", ";
                                    }
                                    currentSelectedTables = currentSelectedTables.TrimEnd(',', ' ').Trim();

                                    int difference = Math.Abs(currentTotal - requiredPersons);

                                    if (difference < minDifference)
                                    {
                                        minDifference = difference;
                                        minTotal = currentTotal;
                                        minSelectedTables = currentSelectedTables;
                                    }
                                }

                                DialogResult re = MessageBox.Show("Đã ghép bàn phù hợp với số lượng người bạn cung cấp. Bạn có muốn đặt không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (re == DialogResult.Yes)
                                {
                                    MainViewCustomer mainViewCustomer = this.ParentForm as MainViewCustomer;
                                    if (mainViewCustomer != null)
                                    {
                                        mainViewCustomer.ActivateButton(iconButton2, RGBColors.color2);
                                        mainViewCustomer.OpenChildForm(new OrderFood(minSelectedTables));
                                    }
                                    this.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không thể ghép bàn nào lớn hơn hoặc bằng giá trị bạn nhập.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không có bàn nào trong danh sách.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn đã chọn không ghép bàn.");
                    }
                }
            }
        }





    


        }
    
}

    

