using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class sickOff
    {

        private PBL3Entities db = new PBL3Entities();
        public List<tb_SickOff> GetAccountsFromTable(string tableName)
        {

            if (db != null)
            {
                var data = db.tb_SickOff.ToList();
                return data != null ? data : new List<tb_SickOff>();
            }
            else
            {
                return new List<tb_SickOff>();
            }

        }
        public List<tb_SickOff> getList(string id)
        {

            List<tb_SickOff> k = db.tb_SickOff.ToList();
            List<tb_SickOff> re = new List<tb_SickOff>();


            foreach (var i in k)
            {
                if (i.EmployeeID.Trim() == id)
                {
                    re.Add(i);
                }
            }
            return re;
        }
        public tb_SickOff getItem(string id) { return db.tb_SickOff.FirstOrDefault(x => x.ID == id); }
        public tb_SickOff AddNew(tb_SickOff customer)
        {
            try
            {
                db.tb_SickOff.Add(customer);
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
        public tb_SickOff Update(tb_SickOff customer)
        {
            try
            {
                var _dt = db.tb_SickOff.FirstOrDefault(x => x.ID == customer.ID);
                _dt.EmployeeID = customer.EmployeeID;
                _dt.SickDate = customer.SickDate;
             

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
