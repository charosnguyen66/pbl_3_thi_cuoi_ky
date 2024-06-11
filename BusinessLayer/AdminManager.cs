using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace BusinessLayer
{
    public class AdminManager
    {
        private PBL3Entities db = new PBL3Entities();

        public List<tb_Admin> GetAllAdmins()
        {
            return db.tb_Admin.ToList();
        }

        public tb_Admin GetAdminById(string id)
        {
            return db.tb_Admin.FirstOrDefault(a => a.ID == id);
        }

        public tb_Admin AddAdmin(string username, string password)
        {
            string hashedPassword = HashCode.HashPassword(password);

            var newAdmin = new tb_Admin
            {
                ID = "3", // Hoặc dùng cách tạo ID khác phù hợp
                Username = username,
                Password = hashedPassword
            };

            db.tb_Admin.Add(newAdmin);
            try
            {
                db.SaveChanges();
                return newAdmin;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
                throw; // Rethrow the original exception
            }
        }

        public bool ValidateAdmin(string username, string password)
        {
            var admin = db.tb_Admin.FirstOrDefault(a => a.Username == username);
            if (admin != null)
            {
                return HashCode.VerifyPassword(password, admin.Password);
            }
            return false;
        }

        public void UpdateAdmin(tb_Admin admin)
        {
            var existingAdmin = db.tb_Admin.FirstOrDefault(a => a.ID == admin.ID);
            if (existingAdmin != null)
            {
                existingAdmin.Username = admin.Username;
                existingAdmin.Password = HashCode.HashPassword(admin.Password); // Băm lại mật khẩu nếu cần
                db.SaveChanges();
            }
        }

        public void DeleteAdmin(string id)
        {
            var admin = db.tb_Admin.FirstOrDefault(a => a.ID == id);
            if (admin != null)
            {
                db.tb_Admin.Remove(admin);
                db.SaveChanges();
            }
        }
    }
}
