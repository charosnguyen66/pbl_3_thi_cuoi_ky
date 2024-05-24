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
    public class DiningTable
    {
        private PBL3Entities db = new PBL3Entities();


        public List<tb_DiningTable> GetAccountsFromTable(string tableName)
        {

            return db.tb_DiningTable.ToList();

        }
        public tb_DiningTable getItem(string id) { return db.tb_DiningTable.FirstOrDefault(x => x.TableID == id); }
        public bool checkExist(string username)
        {
            List<tb_DiningTable> tb_Employee = GetAccountsFromTable("tb_Invoice");

            foreach (var account in tb_Employee)
            {
                if (account.TableID.Trim() == username)
                {
                    return true;
                }
            }

            return false;
        }

        public tb_DiningTable Update(tb_DiningTable employee)
        {
            try
            {
                var _dt = db.tb_DiningTable.FirstOrDefault(x => x.TableID == employee.TableID);

                if (_dt != null)
                {
                    _dt.TableID = employee.TableID;
                    _dt.NumberPerson = employee.NumberPerson;
                    _dt.Description = employee.Description;
                  
                    db.SaveChanges();

                    // Trả về đối tượng đã được cập nhật từ cơ sở dữ liệu
                    return _dt;
                }
                else
                {
                    throw new Exception("Không tìm thấy nhân viên với EmployeeID: " + employee.TableID);
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



    }
}
