using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    // ProductDTO.cs
    public class ProductDTO
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string Description { get; set; }
        public string CategoryID { get; set; }
    }

}
