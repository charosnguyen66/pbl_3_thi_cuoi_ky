//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_Invoice_Detail
    {
        public string ID { get; set; }
        public string InvoiceID { get; set; }
        public string ProductID { get; set; }
        public Nullable<int> Quanlity { get; set; }
        public Nullable<decimal> Discount { get; set; }
    
        public virtual tb_Invoice tb_Invoice { get; set; }
        public virtual tb_Product tb_Product { get; set; }
    }
}
