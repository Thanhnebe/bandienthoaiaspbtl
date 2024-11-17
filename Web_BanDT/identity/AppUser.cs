using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Web_BanDT.identity
{
    public class AppUser:IdentityUser
    {
        public DateTime birtday { get;set;}
        public string address { get;set;}
        public string city { get;set;}
    }
}