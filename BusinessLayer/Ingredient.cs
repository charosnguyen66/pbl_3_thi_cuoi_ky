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
        public tb_Ingredient Update(tb_Ingredient customer)
        {
            try
            {
                var _dt = db.tb_Ingredient.FirstOrDefault(x => x.IngredientID == customer.IngredientID);
                //_dt.InvoiceID = customer.InvoiceID;
                _dt.IngredientName = customer.IngredientName;
                _dt.Number = customer.Number;
                _dt.ProductID = customer.ProductID;
                _dt.Note = customer.Note;
               
                db.SaveChanges();

                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void setIngrdient(string id, int soLuong)
        {
            List<tb_Ingredient> list = GetAccountsFromTable("tb_Ingredient");
            foreach(var i in list)
            {
                if(i.ProductID.Trim() == id.Trim())
                {
                    i.Number -= soLuong;
                    //tb_Ingredient u = new tb_Ingredient()
                    //{
                    //    IngredientID = i.IngredientID,
                    //    IngredientName=i.IngredientName,
                    //    Number = i.Number,
                    //    ProductID = i.ProductID,
                    //    Note = i.Note,
                    //};

                    Update(i);
                }
                else
                {

                }
            }
        }
    }
}