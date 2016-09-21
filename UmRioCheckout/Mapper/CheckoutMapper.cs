using GatewayApiClient.DataContracts;
using GatewayApiClient.DataContracts.EnumTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UmRioCheckout.Models;
using UmRioCheckout.Utilities;

namespace UmRioCheckout.Models
{
    public class CheckoutMapper
    {
        public struct ExpiryDateStruct
        {
            [StringLength(2, MinimumLength = 2)]
            public string Month { get; set; }

            [StringLength(4, MinimumLength = 2)]
            public string Year { get; set; }
        };

        public CreateSaleRequest MapSaleRequest(Partner partner)
        {
            var buyer = new Buyer();
            var transaction = new CreditCardTransaction();
            var createSaleRequest = new CreateSaleRequest();

            buyer.Email = partner.Email;
            buyer.Name = partner.Name;

            ExpiryDateStruct expiryDate = new ExpiryDateStruct();
            expiryDate.Month = partner.CreditCard.ExpiryDate.Substring(0, 2); // MONTH_LENTH = 2
            expiryDate.Year = partner.CreditCard.ExpiryDate.Substring(2 + 3); // MONTH_LENTH+1 + space + /

            var computedBrand = CreditCardUtility.GetBrandByNumber(partner.CreditCard.Number);

            // Cria a transação
            transaction.AmountInCents = partner.Plan;
            transaction.CreditCard = new GatewayApiClient.DataContracts.CreditCard();
            transaction.CreditCard.CreditCardBrand = computedBrand;
            transaction.CreditCard.CreditCardNumber = partner.CreditCard.Number;
            transaction.CreditCard.ExpMonth = Convert.ToInt16(expiryDate.Month);
            transaction.CreditCard.ExpYear = Convert.ToInt16(expiryDate.Year);
            transaction.CreditCard.HolderName = partner.Name;
            transaction.CreditCard.SecurityCode = partner.CreditCard.Cvv;
            transaction.InstallmentCount = 1;

            // Adiciona a transação na requisição.
            createSaleRequest.CreditCardTransactionCollection = new Collection<CreditCardTransaction>(new CreditCardTransaction[] { transaction });
            createSaleRequest.Order = new Order();
            createSaleRequest.Order.OrderReference = "NumeroDoPedido";

            return createSaleRequest;
        }
    }
}