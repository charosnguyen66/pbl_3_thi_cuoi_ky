using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Invoice_Detail
    {
        private PBL3Entities db = new PBL3Entities();


        public List<tb_Invoice_Detail> GetAccountsFromTable(string tableName)
        {

            return db.tb_Invoice_Detail.ToList();

        }
        public string GetLastInvoiceID()
        {
            var lastInvoice = db.tb_Invoice_Detail.OrderByDescending(i => i.ID).FirstOrDefault();
            return lastInvoice?.ID;
        }
        public tb_Invoice_Detail getItem(string id) { return db.tb_Invoice_Detail.FirstOrDefault(x => x.ID == id); }
        public bool checkExist(string username)
        {
            List<tb_Invoice_Detail> tb_Employee = GetAccountsFromTable("tb_Invoice_Detail");

            foreach (var account in tb_Employee)
            {
                if (account.InvoiceID.Trim() == username)
                {
                    return true;
                }
            }

            return false;
        }
        public tb_Invoice_Detail AddNew(tb_Invoice_Detail customer)
        {
            try
            {
                db.tb_Invoice_Detail.Add(customer);
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
        public tb_Invoice_Detail Update(tb_Invoice_Detail customer)
        {
            try
            {
                var _dt = db.tb_Invoice_Detail.FirstOrDefault(x => x.ID == customer.ID);
                //_dt.ID = customer.ID;
                _dt.InvoiceID = customer.InvoiceID;
                _dt.ProductID = customer.ProductID;
                _dt.Quanlity = customer.Quanlity;
                _dt.Discount = customer.Discount;
            
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
                var _dt = db.tb_Invoice_Detail.FirstOrDefault(x => x.ID == id);
                db.tb_Invoice_Detail.Remove(_dt);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
