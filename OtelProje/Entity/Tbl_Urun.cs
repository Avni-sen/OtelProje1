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
    
    public partial class Tbl_Urun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Urun()
        {
            this.Tbl_UrunHareket = new HashSet<Tbl_UrunHareket>();
        }
    
        public int UrunId { get; set; }
        public string UrunAd { get; set; }
        public Nullable<int> UrunGrup { get; set; }
        public Nullable<int> UrunBirim { get; set; }
        public Nullable<decimal> UrunFiyat { get; set; }
        public Nullable<decimal> Toplam { get; set; }
        public Nullable<byte> KDV { get; set; }
        public Nullable<int> Durum { get; set; }
    
        public virtual Tbl_Durum Tbl_Durum { get; set; }
        public virtual Tbl_UrunGrup Tbl_UrunGrup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UrunHareket> Tbl_UrunHareket { get; set; }
    }
}