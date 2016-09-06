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
        [StringLength(16, MinimumLength = 16)]
        [Required]
        public string Number { get; set; }

        public struct ExpiryDateType {
            [Range(1,12)]
            public int Month { get; set; }
            [Range(00, 99)]
            public int Year { get; set; }
        }

        [Display(Name = "Expiry Date")]
        [Required]
        public ExpiryDateType ExpiryDate = new ExpiryDateType();

        [Display(Name = "Security Code")]
        [StringLength(3, MinimumLength = 3)]
        public string Cvv { get; set; }


    }
}