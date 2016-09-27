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
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UmRioCheckout.Models;
using UmRioCheckout.Utilities;

namespace UmRioCheckout.Controllers
{
    public class PartnersController : LanguageController
    {
        // GET: Partners/Create
        public ActionResult Create(string culture)
        {
            this.SetCulture(culture);

            var Plans = new DonationPlans();
            ViewBag.DonationPlans = Plans.Amount;

            return View();
        }

        // POST: Partners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Email, CreditCard, Plan")]Partner partner)
        {
            var Plans = new DonationPlans();
            ViewBag.DonationPlans = Plans.Amount;

            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            var partnerManager = new PartnerManager();

            var result = partnerManager.VerifyPartner(partner);

            if (result.Valid == false)
            {
                ViewBag.ErrorMessage = result.Message;
                return View("Create");
            }

            return RedirectToAction("Thank");
        }

        public ActionResult Thank()
        {
            return View();
        }

        public ActionResult Error(string errorMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            return View();
        }

        public void SetCulture(string culture)
        {
            // Validate input
            string cultureName = CultureUtility.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = cultureName;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = cultureName;
                cookie.Expires = DateTime.Now.AddYears(1);
            }

            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            Response.Cookies.Add(cookie);
        }
    }
}
