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
    public class Invoice
    {
        private PBL3Entities db = new PBL3Entities();


        public List<tb_Invoice> GetAccountsFromTable(string tableName)
        {

            return db.tb_Invoice.ToList();

        }
       
        public tb_Invoice getItem(string id) { return db.tb_Invoice.FirstOrDefault(x => x.InvoiceID == id); }
        public bool checkExist(string username)
        {
            List<tb_Invoice> tb_Employee = GetAccountsFromTable("tb_Invoice");

            foreach (var account in tb_Employee)
            {
                if (account.InvoiceID.Trim() == username)
                {
                    return true;
                }
            }

            return false;
        }
        public tb_Invoice AddNew(tb_Invoice customer)
        {
            try
            {
                db.tb_Invoice.Add(customer);
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
        public string GetLastInvoiceID()
        {
            var lastInvoice = db.tb_Invoice.OrderByDescending(i => i.InvoiceID).FirstOrDefault();
            return lastInvoice?.InvoiceID;
        }
        public tb_Invoice Update(tb_Invoice customer)
        {
            try
            {
                var _dt = db.tb_Invoice.FirstOrDefault(x => x.InvoiceID == customer.InvoiceID);
                //_dt.InvoiceID = customer.InvoiceID;
                _dt.CustomerID = customer.CustomerID;
                _dt.OrderDate = customer.OrderDate;
                _dt.PaymentID = customer.PaymentID;
                _dt.Status = customer.Status;
                _dt.Note = customer.Note;
                _dt.TableID = customer.TableID;
                _dt.EmployeeID = customer.EmployeeID;
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
                var _dt = db.tb_Invoice.FirstOrDefault(x => x.EmployeeID == id);
                db.tb_Invoice.Remove(_dt);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
