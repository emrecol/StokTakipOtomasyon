﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StokTakip.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StokOtomasyonDbEntities : DbContext
    {
        public StokOtomasyonDbEntities()
            : base("name=StokOtomasyonDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ItemTB> ItemTB { get; set; }
        public virtual DbSet<PersonelTB> PersonelTB { get; set; }
        public virtual DbSet<StokTB> StokTB { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TransactionTB> TransactionTB { get; set; }
        public virtual DbSet<TransactionTypeAdTB> TransactionTypeAdTB { get; set; }
        public virtual DbSet<TransactionTypePerTB> TransactionTypePerTB { get; set; }
        public virtual DbSet<WarehouseTB> WarehouseTB { get; set; }
    }
}
