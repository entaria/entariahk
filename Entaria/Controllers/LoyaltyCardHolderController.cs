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
    public class LoyaltyCardHolderController : Controller
    { 
        private EntariaContext db = new EntariaContext();

        //
        // GET: /LoyaltyCardHolder/
        [Authorize(Roles = "admin, LCH")]
        public ActionResult Index()
        {
            return View(db.LoyaltyCardHolders.ToList());
        }

        //
        // GET: /LoyaltyCardHolder/Details/5

        [Authorize (Roles="admin, LCH")]
        public ActionResult Details(int id = 0)
        {
            LoyaltyCardHolder loyaltycardholder = db.LoyaltyCardHolders.Find(id);
            if (loyaltycardholder == null )
            {
                return HttpNotFound();
            }
            if (User.IsInRole("admin") || loyaltycardholder.UserName.Equals(User.Identity.Name))
            {
                return View(loyaltycardholder);
            }
            else
            {
                return HttpNotFound();
            }
        }

        //
        // GET: /LoyaltyCardHolder/Create

        [Authorize (Roles="admin, LCH")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /LoyaltyCardHolder/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles="admin, LCH")]
        public ActionResult Create(LoyaltyCardHolder loyaltycardholder)
        {
            if (ModelState.IsValid)
            {
                db.LoyaltyCardHolders.Add(loyaltycardholder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loyaltycardholder);
        }

        //
        // GET: /LoyaltyCardHolder/Edit/5

        [Authorize (Roles="admin, LCH")]
        public ActionResult Edit(int id = 0)
        {
            LoyaltyCardHolder loyaltycardholder = db.LoyaltyCardHolders.Find(id);
            if (loyaltycardholder == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("admin") || loyaltycardholder.UserName.Equals(User.Identity.Name))
            {
                return View(loyaltycardholder);
            }
            else
            {
                return HttpNotFound();
            }
        }

        //
        // POST: /LoyaltyCardHolder/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles="admin, LCH")]
        public ActionResult Edit(LoyaltyCardHolder loyaltycardholder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loyaltycardholder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loyaltycardholder);
        }

        //
        // GET: /LoyaltyCardHolder/Delete/5

        [Authorize (Roles="admin")]
        public ActionResult Delete(int id = 0)
        {
            LoyaltyCardHolder loyaltycardholder = db.LoyaltyCardHolders.Find(id);
            if (loyaltycardholder == null)
            {
                return HttpNotFound();
            }
            return View(loyaltycardholder);
        }

        //
        // POST: /LoyaltyCardHolder/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            LoyaltyCardHolder loyaltycardholder = db.LoyaltyCardHolders.Find(id);
            db.LoyaltyCardHolders.Remove(loyaltycardholder);
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