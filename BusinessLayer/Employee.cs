using BusinessLayer.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    
    public class Employee
    {
        private PBL3Entities db = new PBL3Entities();
        public int LoginAs(string username, string password)
        {
            // Hash the input password
            string hashedPassword = HashCode.HashPassword(password.Trim());

            // Fetch the employee and check password in memory
            var employee = db.tb_Employee.FirstOrDefault(e => e.EmployeeID.Trim() == username);
            if (employee != null && employee.Password.Trim() == hashedPassword)
            {
                Console.WriteLine("User is an employee");
                return 1;
            }

            // Fetch the customer and check password in memory
            var customer = db.tb_Customer.FirstOrDefault(c => c.CustomerID.Trim() == username);
            if (customer != null && customer.Password.Trim() == hashedPassword)
            {
                Console.WriteLine("User is a customer");
                return 2;
            }

            // Fetch the admin and check password in memory
            var admin = db.tb_Admin.FirstOrDefault(a => a.Username.Trim() == username);
            if (admin != null && admin.Password.Trim() == hashedPassword)
            {
                Console.WriteLine("User is an admin");
                return 3;
            }

            // If not an employee, customer, or admin
            return 0;
        }


        public List<tb_Employee> GetAccountsFromTable(string tab)
        {
            return db.tb_Employee.ToList();
        }

        public  List<NhanVien_DTO> GetAccountsFromTable1()
        {
            List<tb_Employee> list = db.tb_Employee.ToList();
            List<NhanVien_DTO> result = new List<NhanVien_DTO>();
            NhanVien_DTO kk;
            foreach (tb_Employee e in list)
            {
                 kk = new NhanVien_DTO();
                kk.EmployeeID = e.EmployeeID;
                kk.Name = e.Name;
                kk.BirthDate = e.BirthDate;
                kk.Gender = e.Gender==true ? "Nữ" : "Nam";
                kk.TypeEmployee = e.TypeEmployee;
                kk.PhoneNumber = e.PhoneNumber;
                kk.Password = e.Password;
                result.Add(kk);
            }
                return result;
        }

      

        //public List<NhanVien_DTO> getListEmployee(string tableName)
        //{

        //    var lstNV = db.tb_Employee.ToList();

        //    List<NhanVien_DTO> listNVDTO = new List<NhanVien_DTO>();
        //    NhanVien_DTO nv;
        //    foreach (var e in lstNV)
        //    {
        //        nv = new NhanVien_DTO();
        //        nv.EmployeeID = e.EmployeeID.Trim();
        //        nv.Name = e.Name.Trim();
        //        nv.PhoneNumber = e.PhoneNumber.Trim();
        //        nv.BirthDate = e.BirthDate;
        //        nv.Gender = e.Gender;
        //        nv.WorkingTime = e.WorkingTime;
        //        nv.Wage = e.Wage;
        //        nv.TypeEmployee = e.TypeEmployee;
        //        nv.Password = e.Password;
        //        var ngay = db.tb_OverTime.FirstOrDefault(b => b.EmployeeID == e.EmployeeID);
        //        if (ngay != null)
        //        {
        //            nv.overDate = (DateTime)ngay.OvertimeDate;
        //            nv.coeffWage = (double)ngay.coeffSalary;
        //            nv.overTimerHours = (int)ngay.OvertimeHours;
        //        }
        //        else
        //        {
        //            // Xử lý khi không tìm thấy tb_OverTime với EmployeeID tương ứng
        //            // Ví dụ: gán giá trị mặc định cho nv.overDate
        //            nv.overDate = DateTime.MinValue; // hoặc bất kỳ giá trị nào thích hợp khác
        //            nv.coeffWage = 0;
        //            nv.overTimerHours = (int)ngay.OvertimeHours;
        //        }



        //        listNVDTO.Add(nv);
        //    }
        //    return listNVDTO;

        //}
        public tb_Employee getItem(string id) { return db.tb_Employee.FirstOrDefault(x => x.EmployeeID == id); }
        public bool CheckLogin(string username, string password)
        {
            List<tb_Employee> tb_Employee = GetAccountsFromTable("tb_Employee");

            foreach (var account in tb_Employee)
            {
                if (account.EmployeeID.Trim() == username && account.Password.Trim() == password)
                {
                    return true;
                }
            }

            return false;
        }
        public bool checkExist(string username)
        {
            List<tb_Employee> tb_Employee = GetAccountsFromTable("tb_Employee");

            foreach (var account in tb_Employee)
            {
                if (account.EmployeeID.Trim() == username)
                {
                    return true;
                }
            }

            return false;
        }
        public tb_Employee AddNew(tb_Employee customer)
        {
            try
            {
                db.tb_Employee.Add(customer);
                db.SaveChanges();
                return customer;
            }
            catch (DbUpdateException ex)
            {
                // Check if there is an inner exception
                if (ex.InnerException != null)
                {
                    // Log or handle the inner exception
                    Console.WriteLine("Inner Exception Message: " + ex.InnerException.Message);
                }

                // Rethrow the original exception to preserve the stack trace
                throw;
            }

        }
        public tb_Employee Update(tb_Employee employee)
        {
            try
            {
                var _dt = db.tb_Employee.FirstOrDefault(x => x.EmployeeID == employee.EmployeeID);

                if (_dt != null)
                {
                    _dt.BirthDate = employee.BirthDate;
                    _dt.Gender = employee.Gender;
                    _dt.Name = employee.Name;
                    _dt.Address = employee.Address;
                    _dt.PhoneNumber = employee.PhoneNumber;
                    _dt.Password = employee.Password;
                    _dt.TypeEmployee = employee.TypeEmployee;
                    _dt.image = employee.image;
                    db.SaveChanges();

                    // Trả về đối tượng đã được cập nhật từ cơ sở dữ liệu
                    return _dt;
                }
                else
                {
                    throw new Exception("Không tìm thấy nhân viên với EmployeeID: " + employee.EmployeeID);
                }
            }
            catch (DbEntityValidationException ex)
            {
                // Lấy danh sách các lỗi kiểm tra dữ liệu cụ thể
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Tạo một thông điệp lỗi từ các thông điệp kiểm tra dữ liệu
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Tạo một exception mới với thông điệp lỗi tổng hợp
                var exceptionMessage = string.Concat("Lỗi khi kiểm tra dữ liệu: ", fullErrorMessage);

                throw new Exception(exceptionMessage, ex);
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ khác
                throw new Exception("Đã xảy ra lỗi trong quá trình cập nhật: " + ex.Message);
            }
        }


        
            public void Delete(string employeeId)
            {
                using (var context = new PBL3Entities())
                {
                    // Xóa các bản ghi trong tb_Wage
                    var wages = context.tb_Wage.Where(w => w.EmployeeID == employeeId).ToList();
                    context.tb_Wage.RemoveRange(wages);

                    // Xóa các bản ghi trong tb_Overtime
                    var overtimes = context.tb_OverTime.Where(o => o.EmployeeID == employeeId).ToList();
                    context.tb_OverTime.RemoveRange(overtimes);

                    // Xóa các bản ghi trong tb_SickOff
                    var sickoffs = context.tb_SickOff.Where(s => s.EmployeeID == employeeId).ToList();
                    context.tb_SickOff.RemoveRange(sickoffs);

                    // Xóa bản ghi trong tb_Employee
                    var employee = context.tb_Employee.SingleOrDefault(e => e.EmployeeID == employeeId);
                    if (employee != null)
                    {
                        context.tb_Employee.Remove(employee);
                    }

                    // Lưu các thay đổi
                    context.SaveChanges();
                }
        }

    }
}
