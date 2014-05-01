﻿using System;
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
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        //private EntariaContext db = new EntariaContext();
        private IAdminRepository objContext;
        public AdminController(IAdminRepository adminRepository)
        {
            this.objContext = adminRepository;
        }


        //
        // GET: /Admin/
        public ActionResult Index()
        {
            //return View(db.Admins.ToList());
            return View(objContext.Admins);
        }


        //
        // GET: /Admin/Details/5
        public ActionResult Details(int id = 0)
        {
            //Admin admin = db.Admins.Find(id);
            Admin admin = objContext.Admins.Where(x => x.AdminId == id).SingleOrDefault();
            if (admin == null)
            {
                return HttpNotFound();
            }

            return View(admin);
        }


        //
        // GET: /Admin/Create
        [Authorize]
        public ActionResult Create()
        {
            //return View();
            return View(new Admin());
        }


        //
        // POST: /Admin/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                //db.Admins.Add(admin);
                //db.SaveChanges();
                objContext.SaveAdmin(admin);

                return RedirectToAction("Index");
            }

            return View(admin);
        }


        //
        // GET: /Admin/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            //Admin admin = db.Admins.Find(id);
            Admin admin = objContext.Admins.Where(
                x => x.AdminId == id).SingleOrDefault();
            //return View(admin);

            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // POST: /Admin/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Admin admin)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(admin).State = EntityState.Modified;
                //db.SaveChanges();
                objContext.SaveAdmin(admin);

                return RedirectToAction("Index");
            }
            else                     //ninject stuff
            {                        //
                return View(admin);  //
            }                        //
        }

        //
        // GET: /Admin/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            //Admin admin = db.Admins.Find(id);
            Admin admin = objContext.DeleteAdmin(id);
            if (admin == null)
            {
                return HttpNotFound();
            }

            return View(admin);
        }

        //
        // POST: /Admin/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Admin admin = db.Admins.Find(id);
            //db.Admins.Remove(admin);
            //db.SaveChanges();
            Admin admin = objContext.DeleteAdmin(id);
            return RedirectToAction("Index");
        }

        /*
        [Authorize]
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        */


    }
}