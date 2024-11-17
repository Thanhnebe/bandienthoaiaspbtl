using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_BanDT.Models.csdl
{
    public class ProductImage:DungChung
    {
        public int id { get; set; }
        public int ProductId { get; set; }
        public string image { get; set; }
        public bool idDefault { get; set; }
    }
}