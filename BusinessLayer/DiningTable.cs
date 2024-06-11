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
<<<<<<< HEAD

        public void changeStatus1(List<string> ids)
        {
            var tables = db.tb_DiningTable.Where(t => ids.Contains(t.TableID)).ToList();
            foreach (var table in tables)
            {
                table.Description = "0";
                Update(table);
            }
        }

        public tb_DiningTable getItem(string id)
        {
            return db.tb_DiningTable.FirstOrDefault(x => x.TableID == id);
        }

=======
        public void changeStatus1(string id)
        {
            List<tb_DiningTable> list = GetAccountsFromTable("");
            foreach (var i in list)
            {
                if (i.TableID == id)
                {
                    i.Description = "0";

                    Update(i);
                }

            }
        }
        public tb_DiningTable getItem(string id) { return db.tb_DiningTable.FirstOrDefault(x => x.TableID == id); }
>>>>>>> 64de7580e291ace885cd111372303e1c5a33b3ef
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
            string[] ids = id.Split(',');

            foreach (string tableId in ids)
            {
<<<<<<< HEAD
                var table = db.tb_DiningTable.FirstOrDefault(t => t.TableID == tableId.Trim());
                if (table != null)
                {
                    table.Description = "1";
                    Update(table);
                }
                else
                {
                    Console.WriteLine("Không tìm thấy bảng với ID: " + tableId);
=======
                List<tb_DiningTable> list = GetAccountsFromTable("tb_DiningTable");

                foreach (var i in list)
                {
                    if (i.TableID.Trim() == tableId.Trim())
                    {
                        i.Description = "1";

                        Update(i);
                    }
>>>>>>> 64de7580e291ace885cd111372303e1c5a33b3ef
                }
            }
        }

<<<<<<< HEAD
        public tb_DiningTable Update(tb_DiningTable table)
=======

        public tb_DiningTable Update(tb_DiningTable employee)
>>>>>>> 64de7580e291ace885cd111372303e1c5a33b3ef
        {
            try
            {
                var _dt = db.tb_DiningTable.FirstOrDefault(x => x.TableID == table.TableID);

                if (_dt != null)
                {
                    _dt.TableID = table.TableID;
                    _dt.NumberPerson = table.NumberPerson;
                    _dt.Description = table.Description;
                    db.SaveChanges();
                    return _dt;
                }
                else
                {
                    throw new Exception("Không tìm thấy bảng với TableID: " + table.TableID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Đã xảy ra lỗi trong quá trình cập nhật: " + ex.Message);
            }
        }
    }
}
