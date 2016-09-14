using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace UmRioCheckout.Models
{
    public class Partner 
    {
        [Required]
        public CreditCard CreditCard { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Display(Name = "Donation plan:")]
        [Required]
        public int Plan { get; set; } //Amount in Cents
    }
}