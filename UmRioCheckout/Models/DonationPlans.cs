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
            Amount = new List<int>();
            Amount.Add(1000);
            Amount.Add(3000);
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

        public List<int> Amount { get; set; }
    }
}