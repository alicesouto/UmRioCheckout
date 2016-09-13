using GatewayApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmRioCheckout.Utilities;

namespace UmRioCheckout.Models
{
    public class PartnerManager 
    {
        public void VerifyPartner (Partner partner) {

            CheckoutMapper checkoutMapper = new CheckoutMapper();
            ConfigurationUtility configurationUtility = new ConfigurationUtility();

            // MerchantKey
            Guid merchantKey = configurationUtility.MundiPaggMerchantKey;

            // Cria o client que enviará a transação.
            var serviceClient = new GatewayServiceClient(merchantKey, configurationUtility.MundiPaggApiUrl);

            try
            {
                var httpResponse = serviceClient.Sale.Create(checkoutMapper.MapSaleRequest(partner));

                // Autoriza a transação e recebe a resposta do gateway.
                Console.WriteLine("Código retorno: {0}", httpResponse.HttpStatusCode);

                //Console.WriteLine("Chave do pedido: {0}", httpResponse.Response.OrderResult.OrderKey);
                if (httpResponse.Response.CreditCardTransactionResultCollection != null)
                {
                    Console.WriteLine("Status transação: {0}", httpResponse.Response.CreditCardTransactionResultCollection.FirstOrDefault().CreditCardTransactionStatus);
                }

            }
            catch
            {
                //Tratar excessão

            }
        }

        
    }
}