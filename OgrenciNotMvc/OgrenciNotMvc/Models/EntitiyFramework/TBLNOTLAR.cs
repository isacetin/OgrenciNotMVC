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
    
    public partial class TBLNOTLAR
    {
        public int NOTID { get; set; }
        public Nullable<byte> DERSID { get; set; }
        public Nullable<int> OGRENCIID { get; set; }
        public Nullable<byte> ORTALAMA { get; set; }
        public Nullable<bool> DURUM { get; set; }
        public Nullable<byte> Vize { get; set; }
        public Nullable<byte> Final { get; set; }
    
        public virtual TBLDERS TBLDERS { get; set; }
        public virtual TBLOGRENCILER TBLOGRENCILER { get; set; }
    }
}