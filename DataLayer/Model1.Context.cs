﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PBL3Entities : DbContext
    {
        public PBL3Entities()
            : base("name=PBL3Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_Admin> tb_Admin { get; set; }
        public virtual DbSet<tb_Category> tb_Category { get; set; }
        public virtual DbSet<tb_Customer> tb_Customer { get; set; }
        public virtual DbSet<tb_DiningTable> tb_DiningTable { get; set; }
        public virtual DbSet<tb_Employee> tb_Employee { get; set; }
        public virtual DbSet<tb_Invoice> tb_Invoice { get; set; }
        public virtual DbSet<tb_Invoice_Detail> tb_Invoice_Detail { get; set; }
        public virtual DbSet<tb_Ingredient> tb_Ingredient { get; set; }
        public virtual DbSet<tb_OverTime> tb_OverTime { get; set; }
        public virtual DbSet<tb_Payment> tb_Payment { get; set; }
        public virtual DbSet<tb_Product> tb_Product { get; set; }
        public virtual DbSet<tb_Rating> tb_Rating { get; set; }
        public virtual DbSet<tb_SickOff> tb_SickOff { get; set; }
        public virtual DbSet<tb_Wage> tb_Wage { get; set; }
    }
}
