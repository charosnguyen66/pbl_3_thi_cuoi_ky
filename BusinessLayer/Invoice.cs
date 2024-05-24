using BusinessLayer.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
                _dt.ReserveDate = customer.ReserveDate;
                db.SaveChanges();

                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<InvoiceOfCustomer> GetAccountsFromTable12()
        {
                List<tb_Invoice> list = db.tb_Invoice.ToList();
                List<InvoiceOfCustomer> result = new List<InvoiceOfCustomer>();
                InvoiceOfCustomer kk;
                foreach (tb_Invoice e in list)
                {
                    kk = new InvoiceOfCustomer();
                var customer = db.tb_Customer.SingleOrDefault(c => c.CustomerID == e.CustomerID);
                if (customer != null)
                {
                    kk.tenKH = customer.Name;
                    kk.sdt = customer.PhoneNumber;
                    kk.address = customer.Address;
                    kk.InvoiceID = e.InvoiceID;
                    kk.maBan = e.TableID;
                    result.Add(kk);
                }
           
            }
            return result;
        }
   

        public string GetPaymentNameById(string paymentId)
        {
            if (paymentId == null)
            {
                return "No Payment"; // Hoặc giá trị mặc định nào đó
            }

            using (var context = new PBL3Entities())
            {
                var paymentName = (from p in context.tb_Payment
                                   where p.PaymentID == paymentId
                                   select p.PaymentMethod).FirstOrDefault();

                return paymentName;
            }
        }

        public List<Invoice_DTO> getInvoice()
        {
            List<tb_Invoice> list = db.tb_Invoice.ToList();
            List<Invoice_DTO> result = new List<Invoice_DTO>();

            foreach (var e in list)
            {
                var kk = new Invoice_DTO
                {
                    InvoiceID = e.InvoiceID,
                    OrderDate = e.OrderDate,
                    ReserveDate = e.ReserveDate,
                    Payment = GetPaymentNameById(e.PaymentID), // Sử dụng PaymentID để lấy PaymentName
                    Status = e.Status,
                    TableID = e.Note
                };

                result.Add(kk);
            }
            return result;
        }
        public void Delete(string id)
        {
            try
            {
                // Tìm kiếm hóa đơn trong bảng tb_Invoice
                var invoice = db.tb_Invoice.FirstOrDefault(x => x.InvoiceID.Trim() == id);

                if (invoice != null)
                {
                    var invoiceDetails = db.tb_Invoice_Detail.Where(x => x.InvoiceID == id).ToList();

                    db.tb_Invoice_Detail.RemoveRange(invoiceDetails);

                    db.tb_Invoice.Remove(invoice);

                    // Lưu các thay đổi vào cơ sở dữ liệu
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Hóa đơn không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
