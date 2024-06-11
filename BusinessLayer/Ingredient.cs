using BusinessLayer.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BusinessLayer
{
    public class Ingredient
    {
        private PBL3Entities db = new PBL3Entities();


        public List<tb_Ingredient> GetAccountsFromTable(string tableName)
        {

            return db.tb_Ingredient.ToList();

        }
        public List<Ingredient_DTO> GetSelectedIngredients()
        {
            var selectedIngredients = db.tb_Ingredient
                .Join(
                    db.tb_Product,
                    ingredient => ingredient.ProductID,
                    product => product.ProductID,
                    (ingredient, product) => new Ingredient_DTO
                    {
                        IngredientID = ingredient.IngredientID,
                        Name = ingredient.IngredientName,
                        Number = (int)ingredient.Number,
                        ProductName = product.ProductName,
<<<<<<< HEAD
                        Price = (float)ingredient.Price
=======
                        Note = ingredient.Note
>>>>>>> 64de7580e291ace885cd111372303e1c5a33b3ef
                    })
                .ToList();

            return selectedIngredients;
        }

        public void setNumberToIngredient(string id, int number)
        {
            List<tb_Ingredient> list = GetAccountsFromTable("");
            foreach (var i in list)
            {
                if (i.IngredientID == id)
                {
                    i.Number += number;

                    Update(i);
                }

            }
        }
        public tb_Ingredient Update(tb_Ingredient customer)
        {
            try
            {
                var _dt = db.tb_Ingredient.FirstOrDefault(x => x.IngredientID == customer.IngredientID);

                if (_dt == null)
                {
                    throw new Exception("Ingredient not found");
                }

                // Add debugging information
                Console.WriteLine($"Updating IngredientID: {customer.IngredientID}");

                // _dt.InvoiceID = customer.InvoiceID; // Uncomment if needed

                if (customer.IngredientName != null)
                {
                    Console.WriteLine($"Updating IngredientName: {customer.IngredientName}");
                    _dt.IngredientName = customer.IngredientName;
                }

                if (customer.Number != null)
                {
                    Console.WriteLine($"Updating Number: {customer.Number.Value}");
                    _dt.Number = customer.Number.Value; // Assuming Number is nullable
                }

                if (customer.ProductID != null)
                {
                    Console.WriteLine($"Updating ProductID: {customer.ProductID}");
                    _dt.ProductID = customer.ProductID;
                }

                if (customer.Price != null)
                {
                    Console.WriteLine($"Updating Price: {customer.Price.Value}");
                    _dt.Price = (double)customer.Price.Value; // Assuming Price is nullable
                }

                db.SaveChanges();

                return customer;
            }
            catch (Exception ex)
            {
                // Log the exception message
                Console.WriteLine("Error: " + ex.Message);
                throw new Exception(ex.Message);
            }
        }


        public bool setIngrdient(string id, int soLuong)
        {
            List<tb_Ingredient> list = GetAccountsFromTable("tb_Ingredient");
            foreach (var i in list)
            {
                if (i.ProductID.Trim() == id.Trim())
                {
                    if (i.Number >= soLuong) // Kiểm tra xem có đủ nguyên liệu không
                    {
                        i.Number -= soLuong;
                        Update(i); // Cập nhật số lượng nguyên liệu
                        return true; // Trả về true nếu đủ nguyên liệu
                    }
                    else
                    {
                        return false; // Trả về false nếu không đủ nguyên liệu
                    }
                }
            }
            return false; // Trả về false nếu không tìm thấy sản phẩm trong danh sách nguyên liệu
        }

    }
}