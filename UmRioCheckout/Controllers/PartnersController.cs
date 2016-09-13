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
            var Plans = new DonationPlans();
            ViewBag.DonationPlans = Plans.Amount;
            return View();
        }

        // POST: Partners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Email, CreditCard")]Partner partner)
        {
            if (ModelState.IsValid)
            {
                var partnerManager = new PartnerManager();

                partnerManager.VerifyPartner(partner);

                return RedirectToAction("Thank");

            }

            return View(partner);
        }

        public ActionResult Thank()
        {
            return View();
        }
    }
}
