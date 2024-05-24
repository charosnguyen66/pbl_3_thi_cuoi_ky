using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Overtime
    {
        private PBL3Entities db = new PBL3Entities();
        public List<tb_OverTime> GetAccountsFromTable(string tableName)
        {

            return db.tb_OverTime.ToList();

        }
        public List<tb_OverTime> getList(string id)
        {

            List<tb_OverTime> k =  db.tb_OverTime.ToList();
            List<tb_OverTime> re = new List<tb_OverTime>();


            foreach(var i in k)
            {
                if(i.EmployeeID.Trim() == id)
                {
                    re.Add(i);
                }
            }
            return re;
        }
        public tb_OverTime getItem(string id) { return db.tb_OverTime.FirstOrDefault(x => x.ID == id); }
        public tb_OverTime AddNew(tb_OverTime customer)
        {
            try
            {
                db.tb_OverTime.Add(customer);
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
        public tb_OverTime Update(tb_OverTime customer)
        {
            try
            {
                var _dt = db.tb_OverTime.FirstOrDefault(x => x.ID == customer.ID);
                _dt.OvertimeDate = customer.OvertimeDate;
                _dt.OvertimeHours = customer.OvertimeHours;
                _dt.EmployeeID = customer.EmployeeID;
                _dt.coeffSalary = customer.coeffSalary;
               
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
                var _dt = db.tb_OverTime.FirstOrDefault(x => x.ID == id);
                db.tb_OverTime.Remove(_dt);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
