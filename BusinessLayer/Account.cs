using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Account
    {
        private PBL3Entities db = new PBL3Entities();
        public List<tb_Customer> GetAccountsFromTable(string tableName)
        {

            return db.tb_Customer.ToList();

        }
        public tb_Customer getItem(string id) { return db.tb_Customer.FirstOrDefault(x => x.CustomerID == id); }
        public bool CheckLogin(string username, string password)
        {
            List<tb_Customer> tb_Customer = GetAccountsFromTable("tb_Customer");

            foreach (var account in tb_Customer)
            {
                if (account.CustomerID.Trim() == username && account.Password.Trim() == password)
                {
                    return true;
                }
            }

            return false;
        }
        public bool checkExist(string username)
        {
            List<tb_Customer> tb_Customer = GetAccountsFromTable("tb_Customer");

            foreach (var account in tb_Customer)
            {
                if (account.CustomerID.Trim() == username)
                {
                    return true;
                }
            }

            return false;
        }
        public tb_Customer AddNew(tb_Customer customer)
        {
            try
            {
                db.tb_Customer.Add(customer);
                db.SaveChanges();
                return customer;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception Message: " + ex.InnerException.Message);
                }

                throw;
            }

        }
        public tb_Customer Update(tb_Customer customer)
        {
            try
            {
                var _dt = db.tb_Customer.FirstOrDefault(x => x.CustomerID == customer.CustomerID);
                _dt.Birthdate = customer.Birthdate;
                _dt.Gender = customer.Gender;
                _dt.Address = customer.Address;
                _dt.PhoneNumber = customer.PhoneNumber;
                _dt.Password = customer.Password;
                _dt.Name = customer.Name;
                _dt.image = customer.image;
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
                var _dt = db.tb_Customer.FirstOrDefault(x => x.CustomerID == id);
                db.tb_Customer.Remove(_dt);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
