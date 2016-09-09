using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace UmRioCheckout.Utilities
{
    public class ConfigurationUtility
    {
        public Guid MundiPaggMerchantKey
        {
            get
            {
                return Guid.Parse(ConfigurationManager.AppSettings["GatewayService.MerchantKey"]);
            }
        }

        public Uri MundiPaggApiUrl
        {
            get
            {
                return new Uri(ConfigurationManager.AppSettings["GatewayService.HostUri"]);
            }
        }
    }
}