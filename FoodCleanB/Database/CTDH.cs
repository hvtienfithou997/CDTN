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
    
    public partial class CTDH
    {
        public string MaDH { get; set; }
        public string MaHang { get; set; }
        public Nullable<double> SoLuong { get; set; }
        public Nullable<double> DonGia { get; set; }
    
        public virtual DON_HANG DON_HANG { get; set; }
        public virtual HANG HANG { get; set; }
    }
}