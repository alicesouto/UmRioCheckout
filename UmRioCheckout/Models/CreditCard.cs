using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace UmRioCheckout.Models
{
    public class CreditCard
    {
        [Display(Name = "Credit Card Number")]
        [StringLength(20, MinimumLength = 20)]
        [Required]
        public string Number { get; set; }

        [Display(Name = "Expiry Date")]
        [Required]
        public string ExpiryDate { get; set; }

        [Display(Name = "Security Code")]
        [StringLength(3, MinimumLength = 3)]
        public string Cvv { get; set; }


    }
}