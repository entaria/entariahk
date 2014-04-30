using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entaria.Models;
using Entaria.Abstract;

namespace Entaria.Controllers
{
    public class CardController : Controller
    {
        //private EntariaContext db = new EntariaContext();
        private ICardRepository objContext;
        public CardController(ICardRepository cardRepository)
        {
            this.objContext = cardRepository;
        }

        //
        // GET: /Card/

        public ActionResult Index()
        {
            //return View(db.Cards.ToList());
            return View(objContext.Cards);
        }

        //
        // GET: /Card/Details/5

        public ActionResult Details(int id = 0)
        {
            //Card card = db.Cards.Find(id);
            Card card = objContext.Cards.Where(x => x.CardId == id).SingleOrDefault();
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        //
        // GET: /Card/Create

        public ActionResult Create()
        {
            //return View();
            return View(new Card());
        }

        //
        // POST: /Card/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Card card)
        {
            if (ModelState.IsValid)
            {
                //db.Cards.Add(card);
                //db.SaveChanges();
                objContext.SaveCard(card);
                return RedirectToAction("Index");
            }

            return View(card);
        }

        //
        // GET: /Card/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //Card card = db.Cards.Find(id);
            Card card = objContext.Cards.Where(
                x => x.CardId == id).SingleOrDefault();
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        //
        // POST: /Card/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Card card)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(card).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(card);

            if (ModelState.IsValid)
            {
                objContext.SaveCard(card);
                return RedirectToAction("Index");
            }
            else                    
            {                       
                return View(card);  
            }                        
        }

        //
        // GET: /Card/Delete/5

        public ActionResult Delete(int id = 0)
        {
            //Card card = db.Cards.Find(id);
            Card card = objContext.DeleteCard(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        //
        // POST: /Card/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Card card = db.Cards.Find(id);
            //db.Cards.Remove(card);
            //db.SaveChanges();
            Card card = objContext.DeleteCard(id);
            return RedirectToAction("Index");
        }

        /*
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        */
    }
}