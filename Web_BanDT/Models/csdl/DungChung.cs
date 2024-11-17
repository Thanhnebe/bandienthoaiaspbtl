using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_BanDT.Models.csdl
{
    public abstract class DungChung
    {
        public string CreatyBy { get; set; }
        public DateTime CreatyDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}