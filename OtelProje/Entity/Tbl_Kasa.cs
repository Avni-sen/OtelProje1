//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OtelProje.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Kasa
    {
        public int KasaId { get; set; }
        public string KasaAdi { get; set; }
        public Nullable<decimal> Bakiye { get; set; }
        public Nullable<decimal> GirenTutar { get; set; }
        public Nullable<decimal> CikanTutar { get; set; }
        public Nullable<int> Durum { get; set; }
    
        public virtual Tbl_Durum Tbl_Durum { get; set; }
    }
}