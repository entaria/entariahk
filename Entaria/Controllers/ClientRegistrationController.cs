using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entaria.Controllers
{
    [Authorize(Roles = "admin, client")]
    public class ClientRegistrationController : Controller
    {
        //
        // GET: /ClientRegistration/

        public ActionResult Index()
        {
            return View();
        }

    }
}
