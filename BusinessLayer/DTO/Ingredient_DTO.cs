using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class Ingredient_DTO
    {
        public string IngredientID { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string ProductName{ get; set; }
        public string ProductID{ get; set; }
        public string Note{ get; set; }
    }
}
