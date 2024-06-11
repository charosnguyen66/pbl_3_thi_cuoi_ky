using BusinessLayer;
using BusinessLayer.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI.Admin.Nhanvien
{
    public partial class Them : Form
    {
        private string _id;
        Employee _employee;
        Salary _salary;

        public delegate void MyDel(int ID);
        public MyDel d { get; set; }

        public Them(string id = null)
        {
            InitializeComponent();
            _employee = new Employee();
            _salary = new Salary(); // Khởi tạo đối tượng Salary để thao tác với tb_Wage
            _id = id;
            setCCB();
        }

        public void setCCB()
        {
            cbbTypeEm.Items.Add(new CBBItem
            {
                Value = 0,
                Text = "Phục vụ"
            });
            cbbTypeEm.Items.Add(new CBBItem
            {
                Value = 1,
                Text = "Đầu bếp"
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random();
                string randomNumbers = "";
                for (int i = 0; i < 3; i++)
                {
                    randomNumbers += random.Next(0, 10);
                }

                if (string.IsNullOrWhiteSpace(txtAddress.Text) ||
                    string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtPhone.Text) ||
                    cbbTypeEm.SelectedIndex < 0 ||
                    (!rdFemale.Checked && !rdMale.Checked))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                string typeEmployee = cbbTypeEm.SelectedItem.ToString();
                string uuu = "NV" + randomNumbers;

                tb_Employee q = new tb_Employee
                {
                    EmployeeID = uuu,
                    Name = txtName.Text,
                    Password = HashCode.HashPassword(uuu),
                    PhoneNumber = txtPhone.Text,
                    BirthDate = dpBirth.Value,
                    Gender = rdFemale.Checked,
                    TypeEmployee = typeEmployee,
                    Address = txtAddress.Text
                };

                _employee.AddNew(q);

                // Thêm mới một bản ghi vào bảng tb_Wage với Wage = 5000000
                tb_Wage newWage = new tb_Wage
                {
                    WageID = GenerateNextWageID(), // Gọi hàm để tạo WageID tiếp theo
                    EmployeeID = q.EmployeeID,
                    MonthWage = DateTime.Now, // Hoặc bạn có thể đặt một giá trị tháng cụ thể
                    Wage = 5000000
                };

                _salary.AddNew(newWage); // Giả sử _salary là đối tượng của lớp tương tác với bảng tb_Wage

                DialogResult result = MessageBox.Show("Thêm nhân viên thành công! " +
                    "Tên đăng nhập là: " + q.EmployeeID + "\nMật khẩu là: " + uuu +
                    "\nBạn muốn quay lại trang trước không?", "Thông báo", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    this.Dispose();
                }
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                MessageBox.Show("Đã xảy ra lỗi trong quá trình thêm mới Nhân viên: " + sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình thêm mới Nhân viên: " + ex.Message);
            }
        }

        // Hàm tạo WageID tiếp theo
        private string GenerateNextWageID()
        {
            using (var context = new PBL3Entities())
            {
                // Lấy WageID cuối cùng
                var lastWage = context.tb_Wage.OrderByDescending(w => w.WageID).FirstOrDefault();

                if (lastWage != null)
                {
                    // Lấy phần số từ WageID cuối cùng
                    string lastId = lastWage.WageID;
                    string prefix = new string(lastId.TakeWhile(char.IsLetter).ToArray());
                    int lastNumber = int.Parse(new string(lastId.SkipWhile(char.IsLetter).ToArray()));

                    // Tạo WageID mới bằng cách tăng số cuối cùng lên 1
                    string nextId = prefix + (lastNumber + 1).ToString();

                    return nextId;
                }
                else
                {
                    // Nếu không có WageID nào trong bảng, bắt đầu từ L1
                    return "L1";
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Them_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
