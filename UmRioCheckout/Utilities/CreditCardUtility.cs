using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using GatewayApiClient.DataContracts.EnumTypes;

namespace UmRioCheckout.Utilities
{
    public class CreditCardUtility
    {
        public static CreditCardBrandEnum? GetBrandByNumber(string number)
        {
            if (Regex.IsMatch(number, "^(401178|401179|431274|438935|451416|457393|457631|457632|504175|627780|636297|636368|(506699|5067[0-6]\\d|50677[0-8])|(50900\\d|5090[1-9]\\d|509[1-9]\\d{2})|65003[1-3]|(65003[5-9]|65004\\d|65005[0-1])|(65040[5-9]|6504[1-3]\\d)|(65048[5-9]|65049\\d|6505[0-2]\\d|65053[0-8])|(65054[1-9]|6505[5-8]\\d|65059[0-8])|(65070\\d|65071[0-8])|65072[0-7]|(65090[1-9]|65091\\d|650920)|(65165[2-9]|6516[6-7]\\d)|(65500\\d|65501\\d)|(65502[1-9]|6550[3-4]\\d|65505[0-8]))[0-9]{10,12}"))
            {
                return CreditCardBrandEnum.Elo;
            }
            else if (number.StartsWith("6011") || number.StartsWith("622") || number.StartsWith("64") || number.StartsWith("65"))
            {
                return CreditCardBrandEnum.Discover;
            }
            else if (number.StartsWith("301") || number.StartsWith("305") || number.StartsWith("36") || number.StartsWith("38"))
            {
                return CreditCardBrandEnum.Diners;
            }
            else if (number.StartsWith("34") || number.StartsWith("37"))
            {
                return CreditCardBrandEnum.Amex;
            }
            else if (number.StartsWith("50"))
            {
                return CreditCardBrandEnum.Aura;
            }
            else if (number.StartsWith("4"))
            {
                return CreditCardBrandEnum.Visa;
            }
            else if (number.StartsWith("5") || number.StartsWith("2"))
            {
                return CreditCardBrandEnum.Mastercard;
            }
            else
            {
                return null;
            }
        }
    }
}