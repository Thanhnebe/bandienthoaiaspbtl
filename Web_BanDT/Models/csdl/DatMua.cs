using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_BanDT.Models.csdl
{
    public class DatMua: DungChung
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string email { get; set; }
        public DateTime craeteDate { get; set; }

    }
}