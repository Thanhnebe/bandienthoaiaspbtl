//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_BanDT.Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Order()
        {
            this.tb_orderDeTail = new HashSet<tb_orderDeTail>();
        }
    
        public int ID { get; set; }
        public string MaSanPham { get; set; }
        public string Tenkh { get; set; }
        public string Phone { get; set; }
        public string address { get; set; }
        public Nullable<decimal> tongTien { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Craetedby { get; set; }
        public Nullable<int> idKhacHang { get; set; }
        public string Email { get; set; }
    
        public virtual KHACHHANG KHACHHANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_orderDeTail> tb_orderDeTail { get; set; }
    }
}
