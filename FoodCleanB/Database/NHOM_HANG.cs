//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodCleanB.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class NHOM_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHOM_HANG()
        {
            this.HANGs = new HashSet<HANG>();
        }
    
        public string MaNhomHang { get; set; }
        public string TenNhomHang { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public Nullable<System.DateTime> NgayXuat { get; set; }
        public Nullable<double> DonGia { get; set; }
        public Nullable<double> SoLuong { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HANG> HANGs { get; set; }
    }
}
