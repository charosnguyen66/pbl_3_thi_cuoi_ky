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
        public List<tb_SickOff> getList1(string employeeID)
        {
            return db.tb_SickOff.Where(x => x.EmployeeID == employeeID).ToList();
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
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => $"{x.PropertyName}: {x.ErrorMessage}");

                var fullErrorMessage = string.Join("; ", errorMessages);
                var exceptionMessage = $"Validation failed for one or more entities. Details: {fullErrorMessage}";

                // Log the validation errors
                Console.WriteLine(exceptionMessage);

                // Throw a new DbEntityValidationException with the improved exception message
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
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

        public string GetNextID()
        {
            var lastID = db.tb_SickOff.OrderByDescending(x => x.ID).FirstOrDefault()?.ID;
            if (lastID == null)
            {
                return "S1"; // Bắt đầu từ S1 nếu chưa có ID nào
            }

            // Tách phần số và phần chữ trong ID cuối cùng
            var numericPart = new string(lastID.SkipWhile(c => !char.IsDigit(c)).ToArray());
            var alphaPart = new string(lastID.TakeWhile(c => !char.IsDigit(c)).ToArray());

            if (int.TryParse(numericPart, out int number))
            {
                return $"{alphaPart}{number + 1}";
            }

            throw new InvalidOperationException("ID format is invalid");
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
