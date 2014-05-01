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
    public class ClientController : Controller
    {
        private EntariaContext db = new EntariaContext();

        //
        // GET: /Client/
        [Authorize(Roles = "admin, client")]
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        //
        // GET: /Client/Details/5
        [Authorize(Roles = "admin, client")]
        public ActionResult Details(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("admin") || client.CompanyName.Equals(User.Identity.Name))
            {
                return View(client);
            }
            else
            {
                return HttpNotFound();
            }
        }

        //
        // GET: /Client/Create

        [Authorize(Roles = "admin, client")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Client/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, client")]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        //
        // GET: /Client/Edit/5
        [Authorize(Roles = "admin, client")]
        public ActionResult Edit(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("admin") || client.CompanyName.Equals(User.Identity.Name))
            {
                return View(client);
            }
            else
            {
                return HttpNotFound();
            }
        }

        //
        // POST: /Client/Edit/5
        [Authorize(Roles = "admin, client")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        //
        // GET: /Client/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("admin") || client.CompanyName.Equals(User.Identity.Name))
            {
                return View(client);
            }
            else
            {
                return HttpNotFound();
            }
        }

        //
        // POST: /Client/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}