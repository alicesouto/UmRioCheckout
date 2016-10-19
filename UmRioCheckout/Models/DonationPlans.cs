using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UmRioCheckout.Models
{
    public class DonationPlans : IEnumerable
    {
        public DonationPlans()
        {
            Amount = new List<double>();
            Amount.Add(15.00);
            Amount.Add(30.00);
        }
        
        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public DonationPlansEnum GetEnumerator()
        {
            return new DonationPlansEnum(Amount);
        }

        public List<double> Amount { get; set; }
    }
}