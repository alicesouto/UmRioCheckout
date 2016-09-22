using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Resources;

namespace UmRioCheckout.Models
{
    public class CreditCard
    {
        [Display(Name = "CCNumber", ResourceType = typeof(Resources.Resources))]
        [StringLength(30, MinimumLength = 10, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "CCNumberLength")]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "Required")]
        public string Number { get; set; }

        [Display(Name = "CCExpiryDate", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "Required")]
        public string ExpiryDate { get; set; }

        [Display(Name = "CCSecurityCode", ResourceType = typeof(Resources.Resources))]
        [StringLength(4, MinimumLength = 3, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "CCCvvLength")]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "Required")]
        public string Cvv { get; set; }

        [Display(Name = "CCHolderName", ResourceType = typeof(Resources.Resources))]
        public string Name { get; set; }
    }
}