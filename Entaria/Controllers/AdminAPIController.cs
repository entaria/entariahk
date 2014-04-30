using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Entaria.Abstract;
using Entaria.Models;
using Entaria.Concrete;

namespace Entaria.Controllers
{
    public class AdminAPIController : ApiController
    {
        //private EntariaEFContext db = new EntariaEFContext();
        private IAdminAPIRepository objContext;

        public AdminAPIController(IAdminAPIRepository adminAPIRepository)
        {
            this.objContext = adminAPIRepository;
        }

        // GET api/AdminAPI
        public IEnumerable<Admin> GetAdmins()
        {
            return objContext.Admins.AsEnumerable();
        }

        // GET api/AdminAPI/5
        public Admin GetAdmin(int id)
        {

            Admin admin = objContext.Admins.Where(x => x.AdminId == id).SingleOrDefault(); 
            if (admin == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return admin;
        }

        /*
        // PUT api/AdminAPI/5
        public HttpResponseMessage PutAdmin(int id, Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != admin.AdminId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(admin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/AdminAPI
        public HttpResponseMessage PostAdmin(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, admin);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = admin.AdminId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/AdminAPI/5
        public HttpResponseMessage DeleteAdmin(int id)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Admins.Remove(admin);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, admin);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

         */
    }
}