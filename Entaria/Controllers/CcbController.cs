﻿using System;
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
using Entaria.Abstract;

namespace Entaria.Controllers
{
    public class CcbController : ApiController
    {
    /*    public class webtu : IHttpHandler {    
    public void ProcessRequest (HttpContext context) {
        context.Response.AddHeader("Access-Control-Allow-Origin", "*");    
    }*/
        private EntariaContext db = new EntariaContext();


        // GET api/ccb
        public IEnumerable<ClientCardBalance> GetClientCardBalances()
        {
            //return db.ClientCardBalances.AsEnumerable();
            var balances = db.ClientCardBalances;
            return  balances ;
        }

        // GET api/ccb/5
        public ClientCardBalance GetClientCardBalance(int id)
        {
            ClientCardBalance clientcardbalance = db.ClientCardBalances.Find(id);
            if (clientcardbalance == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return clientcardbalance;
        }

       

        // POST api/ccb
        public HttpResponseMessage PostClientCardBalance(ClientCardBalance clientcardbalance)
        {
            if (ModelState.IsValid)
            {
                db.ClientCardBalances.Add(clientcardbalance);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, clientcardbalance);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = clientcardbalance.ClientCardBalanceId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/ccb/5
        public HttpResponseMessage DeleteClientCardBalance(int id)
        {
            ClientCardBalance clientcardbalance = db.ClientCardBalances.Find(id);
            if (clientcardbalance == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.ClientCardBalances.Remove(clientcardbalance);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, clientcardbalance);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}