//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Report
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Report()
        {
            this.Revenue = 0D;
            this.NetIncome = 0D;
            this.Assets = 0D;
            this.Equity = 0D;
        }
    
        public int Id { get; set; }
        public int PeriodId { get; set; }
        public int CompanyId { get; set; }
        public double Revenue { get; set; }
        public double NetIncome { get; set; }
        public double Assets { get; set; }
        public double Equity { get; set; }
        public string CEO { get; set; }
        public bool Overwrite { get; set; }
        public int CreatedByUserId { get; set; }
    
        public virtual Period Period { get; set; }
        public virtual User User { get; set; }
        public virtual Company Company { get; set; }
    }
}
