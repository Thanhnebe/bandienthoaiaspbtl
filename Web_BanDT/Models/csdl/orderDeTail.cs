using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_BanDT.Models.csdl
{
    public class orderDeTail:DungChung
    {

        public int id { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public decimal price { get; set; }
        public int Quantity { get; set; }
    }
}