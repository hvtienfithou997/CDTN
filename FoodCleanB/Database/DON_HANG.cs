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
    
    public partial class DON_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DON_HANG()
        {
            this.CTDHs = new HashSet<CTDH>();
        }
    
        public string MaDH { get; set; }
        public string MaTaiKhoan { get; set; }
        public string MaKH { get; set; }
        public byte[] AnhSanPham { get; set; }
        public string TenSanPham { get; set; }
        public Nullable<double> DonGia { get; set; }
        public Nullable<double> SoLuong { get; set; }
        public Nullable<double> TongTien { get; set; }
        public Nullable<System.DateTime> NgayLap { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDH> CTDHs { get; set; }
        public virtual KHACH_HANG KHACH_HANG { get; set; }
        public virtual TAI_KHOAN TAI_KHOAN { get; set; }
    }
}
