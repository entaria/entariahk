using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entaria.Controllers
{

    public class ErrorController : Controller
    {
        public ViewResult Index()
        {
            return View("Error");
        }

        public ViewResult Unauthorized()
        {
            Response.StatusCode = 200;
            return View("Action Not Allowed");
        }

        public ViewResult NotFound()
        {
            Response.StatusCode = 404;  //you may want to set this to 200
            return View("NotFound");
        }


        //
        // GET: /Error/
        /*
        public ActionResult Index()
        {
            return View();
        }
        */
    }
}
