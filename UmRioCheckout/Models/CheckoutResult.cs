using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmRioCheckout.Models
{
    public class CheckoutResult
    {
        public string Message { get; set; }
        public bool Valid { get; set; }

        //public string RedirectUrl { get; set; }
    }
}