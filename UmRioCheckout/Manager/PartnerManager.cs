﻿using GatewayApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmRioCheckout.Utilities;

namespace UmRioCheckout.Models
{
    public class PartnerManager
    {
        public CheckoutResult VerifyPartner(Partner partner)
        {
            var result = new CheckoutResult();
            var checkoutMapper = new CheckoutMapper();
            var configurationUtility = new ConfigurationUtility();

            // MerchantKey
            Guid merchantKey = configurationUtility.MundiPaggMerchantKey;
            if (merchantKey == null)
            {
                result.Message = Resources.Resources.InvalidMerchantKey;
                result.Valid = false;
                
                return result;
            }
            
            // Cria o client que enviará a transação.
            var serviceClient = new GatewayServiceClient(merchantKey, configurationUtility.MundiPaggApiUrl);

            try
            {
                // Autoriza a transação e recebe a resposta do gateway.
                var httpResponse = serviceClient.Sale.Create(checkoutMapper.MapSaleRequest(partner));

                if (httpResponse.Response.CreditCardTransactionResultCollection != null)
                {
                    result.Message = httpResponse.HttpStatusCode.ToString();
                    result.Valid = true;
                }
                else
                {
                    //#region Error Log

                    //var customData = new Dictionary<string, object>();

                    //customData.Add("MerchantKey", merchantKey);
                    //customData.Add("TransactionStatus", httpResponse.Response.CreditCardTransactionResultCollection.FirstOrDefault().CreditCardTransactionStatus);

                    //RollbarDotNet.Rollbar.Report("VerifyPartner Error!", RollbarDotNet.ErrorLevel.Error, customData);

                    //#endregion

                    result.Message = httpResponse.HttpStatusCode.ToString();
                    result.Valid = false;
                    return result;
                } 
            }
            catch (Exception ex)
            {
                //#region Exception Log

                //var customData = new Dictionary<string, object>();

                //customData.Add("MerchantKey", merchantKey);
                //customData.Add("Exception", ex);

                //RollbarDotNet.Rollbar.Report("VerifyPartner Exception!", RollbarDotNet.ErrorLevel.Critical, customData);

                //#endregion

                result.Message = @Resources.Resources.ExceptionError;
                result.Valid = false;
            }

            return result;
        }
    }
}