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
    [Authorize]
    public class TransactionController : Controller
    {
        private EntariaContext db = new EntariaContext();

        //
        // GET: /Transaction/

        public ActionResult Index()
        {
            /*
            if (User.IsInRole("admin"))
            {
            */
 
                return View(db.Transactions.ToList());
            /*
            }
            else
            {                
                if (User.IsInRole("LCH")) {
                    IEnumerable<Transaction> transaction = db.Transactions.Where(       x => x.CardId == 
                                                          (db.Cards.Where(              y => y.LoyaltyCardHolderId == 
                                                          (db.LoyaltyCardHolders.Where( z => z.UserName.Equals(User.Identity.Name)).Single().LoyaltyCardHolderId)).Single().CardId)).ToList();
                    if (transaction == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        return View(transaction);
                    }
                }
                else {
                    return HttpNotFound();
                }
            } */       
        }

        //
        // GET: /Transaction/Details/5

        public ActionResult Details(int id = 0)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        //
        // GET: /Transaction/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Transaction/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transaction);
        }

        //
        // GET: /Transaction/Edit/5

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        //
        // POST: /Transaction/Edit/5

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }

        //
        // GET: /Transaction/Delete/5

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id = 0)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        //
        // POST: /Transaction/Delete/5

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
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