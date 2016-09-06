using GatewayApiClient;
using GatewayApiClient.DataContracts;
using GatewayApiClient.DataContracts.EnumTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UmRioCheckout.Models;

namespace UmRioCheckout.Controllers
{
    public class PartnersController : Controller
    {
        // GET: Partners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Partners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Email,CreditCard")] Partner partner)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Thank");


                Buyer buyer = new Buyer()
                {
                    Email = partner.Email,
                    Name = partner.Name,
                };
                // Cria a transação.
                var transaction = new CreditCardTransaction()
                {
                    AmountInCents = 1000,
                    CreditCard = new GatewayApiClient.DataContracts.CreditCard()
                    {
                        CreditCardBrand = CreditCardBrandEnum.Visa,
                        CreditCardNumber = partner.CreditCard.Number,
                        ExpMonth = partner.CreditCard.ExpiryDate.Month,
                        ExpYear = partner.CreditCard.ExpiryDate.Year,
                        HolderName = partner.Name,
                        SecurityCode = partner.CreditCard.Cvv
                    },
                    InstallmentCount = 1
                };

                // Cria requisição.
                var createSaleRequest = new CreateSaleRequest()
                {
                    // Adiciona a transação na requisição.
                    CreditCardTransactionCollection = new Collection<CreditCardTransaction>(new CreditCardTransaction[] { transaction }),
                    Order = new Order()
                    {
                        OrderReference = "NumeroDoPedido"
                    }
                };

                // Coloque a sua MerchantKey aqui.
                Guid merchantKey = Guid.Parse("d1c7c0da-7d89-472b-b0a0-bee156c79dd2");

                // Cria o client que enviará a transação.
                var serviceClient = new GatewayServiceClient(merchantKey, new Uri("https://sandbox.mundipaggone.com"));

                // Autoriza a transação e recebe a resposta do gateway.
                var httpResponse = serviceClient.Sale.Create(createSaleRequest);

                Console.WriteLine("Código retorno: {0}", httpResponse.HttpStatusCode);
                //Console.WriteLine("Chave do pedido: {0}", httpResponse.Response.OrderResult.OrderKey);
                if (httpResponse.Response.CreditCardTransactionResultCollection != null)
                {
                    Console.WriteLine("Status transação: {0}", httpResponse.Response.CreditCardTransactionResultCollection.FirstOrDefault().CreditCardTransactionStatus);
                }

            }

            return View(partner);
        }

        // PUT: Partners/Thank
        public ActionResult Thank(Partner partner)
        {
            ViewData["Name"] = partner.Name;
            return View();
        }
    }
}
