using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entaria.Models;

namespace Entaria.Controllers
{
    [Authorize(Roles = "admin, client")]
    public class ClientProfileController : Controller
    {
        private EntariaContext db = new EntariaContext();
        //
        // GET: /ClientProfile/

        public ActionResult Index()
        {
            return View(db.LoyaltyCardHolders.ToList());
        }

    }
}
