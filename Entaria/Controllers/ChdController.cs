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
using Entaria.Models;

namespace Entaria.Controllers
{
    public class ChdController : ApiController
    {
        
        private EntariaContext db = new EntariaContext();

        // GET api/chd
        public IEnumerable<CardHolderDetail> GetCardHolderDetails()
        {
            return db.CardHolderDetails.AsEnumerable();
        }

        // GET api/chd/5
        public CardHolderDetail GetCardHolderDetails(int id)
        {
            CardHolderDetail cardholderdetails = db.CardHolderDetails.Find(id);
            if (cardholderdetails == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return cardholderdetails;
        }

        // PUT api/chd/5
        public HttpResponseMessage PutCardHolderDetails(int id, CardHolderDetail cardholderdetails)
        {

            // this method inserts a new cardholder record into the database
            // this is called from an aria project.
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != cardholderdetails.CardHolderDetailId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(cardholderdetails).State = EntityState.Modified;

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

        // POST api/chd
        [HttpPost]
        [ActionName("ApipostCHD3")]
        public CardHolderDetail PostCardHolderDetails(CardHolderDetail cardholderdetails)
        {

            // this method inserts a new cardholder record into the database
            // this is called from an aria project.
           
            if (ModelState.IsValid)
            {
                db.CardHolderDetails.Add(cardholderdetails);
                db.SaveChanges();

      //          HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, cardholderdetails);
      //          response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = cardholderdetails.CardHolderDetailsId }));
      //          return response;
                return cardholderdetails;
            }
            else
            {
                return cardholderdetails;
            }
        }


        [HttpPost]
        [ActionName("ApipostCHD")]
        public HttpResponseMessage PostCardHolderDetails1(CardHolderDetail chd)
        {
            if (ModelState.IsValid)
            {
                db.CardHolderDetails.Add(chd);
                db.SaveChanges();

                          HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, chd);
                          response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id =chd.CardHolderDetailId }));
                          return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/chd/5
        public HttpResponseMessage DeleteCardHolderDetails(int id)
        {
            CardHolderDetail cardholderdetails = db.CardHolderDetails.Find(id);
            if (cardholderdetails == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.CardHolderDetails.Remove(cardholderdetails);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, cardholderdetails);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}