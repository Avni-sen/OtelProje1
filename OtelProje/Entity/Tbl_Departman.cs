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
    
    public partial class Tbl_Departman
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Departman()
        {
            this.Tbl_Gorev = new HashSet<Tbl_Gorev>();
            this.Tbl_Personel = new HashSet<Tbl_Personel>();
        }
    
        public int DepartmanId { get; set; }
        public string DepartmanAd { get; set; }
        public string Telefon { get; set; }
        public Nullable<int> Durum { get; set; }
    
        public virtual Tbl_Durum Tbl_Durum { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Gorev> Tbl_Gorev { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Personel> Tbl_Personel { get; set; }
    }
}