﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CompanyAnalysis2.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CompanyAnalysis2Context : DbContext
    {
        public CompanyAnalysis2Context()
            : base("name=CompanyAnalysis2Context")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Estimate> Estimates { get; set; }
        public virtual DbSet<FinancialIndicator> FinancialIndicators { get; set; }
        public virtual DbSet<Period> Periods { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSetting> UserSettings { get; set; }
        public virtual DbSet<StockQuote> StockQuotes { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
    }
}
