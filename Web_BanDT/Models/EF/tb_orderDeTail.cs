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
    
    public partial class tb_orderDeTail
    {
        public int ID { get; set; }
        public Nullable<int> orderId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<int> Quantity { get; set; }
    
        public virtual tb_Order tb_Order { get; set; }
        public virtual TB_PRODUCT TB_PRODUCT { get; set; }
    }
}
