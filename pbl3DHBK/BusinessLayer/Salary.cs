using BusinessLayer.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Salary
    {

        private PBL3Entities db = new PBL3Entities();
       
        public List<tb_Wage> GetAccountsFromTable(string tab)
        {
            return db.tb_Wage.ToList();
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
        public tb_Wage getItem(string id) { return db.tb_Wage.FirstOrDefault(x => x.EmployeeID == id); }

        public bool checkExist(string username)
        {
            List<tb_Wage> tb_Employee = GetAccountsFromTable("tb_Wage");

            foreach (var account in tb_Employee)
            {
                if (account.EmployeeID.Trim() == username)
                {
                    return true;
                }
            }

            return false;
        }
        public tb_Wage AddNew(tb_Wage customer)
        {
            try
            {
                db.tb_Wage.Add(customer);
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
        public tb_Wage Update(tb_Wage customer)
        {
            try
            {
                var _dt = db.tb_Wage.FirstOrDefault(x => x.EmployeeID == customer.EmployeeID);
                _dt.TimeStart = customer.TimeStart;
                _dt.TimeEnd = customer.TimeEnd;
                _dt.WorkingTime = customer.WorkingTime;
                _dt.Wage = customer.Wage;
              
                db.SaveChanges();

                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(string id)
        {
            try
            {
                var _dt = db.tb_Wage.FirstOrDefault(x => x.EmployeeID == id);
                db.tb_Wage.Remove(_dt);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
