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
        public List<object> GetCustomerInfoList()
        {
            List<tb_Customer> customerList = GetAccountsFromTable("tb_Customer");

            List<object> selectedCustomerInfoList = new List<object>();

            foreach (var customer in customerList)
            {
                string gender = customer.Gender == true ? "Nữ" : "Nam";
                var customerInfo = new
                {
                    Mãkháchhàng = customer.CustomerID,
                    Tênkháchhàng = customer.Name,
                    Sốđiệnthoại = customer.PhoneNumber,
                    Giớitính = gender,
                    Ngàysinh = customer.Birthdate,
                    Địachỉ = customer.Address,
                    Điểmthưởng = customer.RewardPoints,
                    Mậtkhẩu = customer.Password
                };

                selectedCustomerInfoList.Add(customerInfo);
            }

            return selectedCustomerInfoList;
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
            using (var context = new PBL3Entities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // Remove related ratings
                        var ratings = context.tb_Rating.Where(r => r.customerID.Trim() == id.Trim()).ToList();
                        if (ratings.Any())
                        {
                            context.tb_Rating.RemoveRange(ratings);
                        }

                        // Find invoices related to the customer
                        var invoices = context.tb_Invoice.Where(i => i.CustomerID.Trim() == id.Trim()).ToList();
                        foreach (var invoice in invoices)
                        {
                            // Remove related invoice details
                            var invoiceDetails = context.tb_Invoice_Detail.Where(d => d.InvoiceID.Trim() == invoice.InvoiceID.Trim()).ToList();
                            if (invoiceDetails.Any())
                            {
                                context.tb_Invoice_Detail.RemoveRange(invoiceDetails);
                            }

                            // Remove related payments
                          

                            // Remove the invoice itself
                            context.tb_Invoice.Remove(invoice);
                        }

                        // Remove standalone payments related to the customer
                      

                        // Remove the customer record
                        var customer = context.tb_Customer.SingleOrDefault(c => c.CustomerID.Trim() == id.Trim());
                        if (customer != null)
                        {
                            context.tb_Customer.Remove(customer);
                        }

                        // Save changes and commit the transaction
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        string errorMessage = GetFullErrorMessage(ex);
                        throw new Exception("Đã xảy ra lỗi trong quá trình xóa khách hàng: " + errorMessage);
                    }
                }
            }
        }

        private string GetFullErrorMessage(Exception ex)
        {
            // A helper function to get the full error message
            if (ex.InnerException == null)
            {
                return ex.Message;
            }
            return ex.Message + " --> " + GetFullErrorMessage(ex.InnerException);
        }








    }
}
