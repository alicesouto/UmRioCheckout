using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmRioCheckout.Models
{
    // When you implement IEnumerable, you must also implement IEnumerator.
    public class DonationPlansEnum : IEnumerator
    {
        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;
        private List<double> plans;

        public DonationPlansEnum(List<double> list)
        {
            plans = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < plans.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public double Current
        {
            get
            {
                try
                {
                    return plans[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}