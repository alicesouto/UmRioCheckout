using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace UmRioCheckout.Models
{
    public class Partner : CreditCard
    {
        public CreditCard CreditCard { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}