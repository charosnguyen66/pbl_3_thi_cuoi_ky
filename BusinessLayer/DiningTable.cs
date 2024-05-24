using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public void changeStatus(string id)
        {
            List<tb_DiningTable> list = GetAccountsFromTable("tb_DiningTable");
            foreach (var i in list)
            {
                if (i.TableID.Trim() == id.Trim())
                {
                    i.Description = "1";

                    Update(i);
                }
             
            }
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
                    return _dt;
                }
                else
                {
                    throw new Exception("Không tìm thấy nhân viên với EmployeeID: " + employee.TableID);
                }
            }
            
            catch (Exception ex)
            {
                throw new Exception("Đã xảy ra lỗi trong quá trình cập nhật: " + ex.Message);
            }
        }



    }
}
