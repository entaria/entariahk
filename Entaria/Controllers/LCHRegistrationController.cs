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
    [Authorize(Roles = "admin, LCH")]
    public class LCHRegistrationController : Controller
    {
        //
        // GET: /LCHRegistration/

        public ActionResult Index()
        {
            return View();
        }

    }
}
