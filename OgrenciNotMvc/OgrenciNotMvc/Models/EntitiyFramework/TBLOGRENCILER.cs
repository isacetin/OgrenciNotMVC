//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OgrenciNotMvc.Models.EntitiyFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLOGRENCILER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLOGRENCILER()
        {
            this.TBLNOTLAR = new HashSet<TBLNOTLAR>();
        }
    
        public int OGRENCIID { get; set; }
        public string OGRENCIAD { get; set; }
        public string OGRENCISOYAD { get; set; }
        public string OGRENCIFOTOGRAF { get; set; }
        public string OGRENCICINSIYET { get; set; }
        public Nullable<bool> DURUM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLNOTLAR> TBLNOTLAR { get; set; }
    }
}
