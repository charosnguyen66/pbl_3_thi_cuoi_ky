using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class Invoice_DTO
    {
        public string InvoiceID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public string PaymentID { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public string TableID { get; set; }
        public string EmployeeID { get; set; }
    }
}
