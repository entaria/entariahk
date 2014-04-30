using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Entaria
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            config.Routes.MapHttpRoute(
             name: "ApigetCARDTEST",
             routeTemplate: "api/{controller}/{action}/{client}/{card}",
             defaults: null //new { controller = "Default1", action = "GetCard"}
         );
            config.Routes.MapHttpRoute(
              name: "ApigetCCB",
              routeTemplate: "api/{controller}/{action}/{client}/{card}",
              defaults: null //new { controller = "cws", action = "getCCB"}
          );

            config.Routes.MapHttpRoute(
              name: "ApiputCCB",
              routeTemplate: "api/{controller}/{action}/{id}/{ClientCardBalance}",
              defaults: new { controller = "cws", action = "PutClientCardBalance", ClientCardBalance = RouteParameter.Optional, id = RouteParameter.Optional }
          );
            config.Routes.MapHttpRoute(
               name: "ApipostCHD",
               routeTemplate: "api/{controller}/{action}/{firstname}/{lastname}/{email}/{phoneno}",
               defaults: new { controller = "chd", action = "PostCardHolderDetails", firstname = "", lastname = "", email = "", phoneno = "09876543" }
           );
            config.Routes.MapHttpRoute(
                 name: "ApipostTRANSACTION",
                 routeTemplate: "api/{controller}/{action}/{client}/{card}/{locationId}/{readerid}/{receiptNo}/{transactionTypeId}/{transactionTime}",
                 defaults: new { controller = "cws", action = "PostTRANSACTION", client = 0, card = 0, locationId = 0, readerid = 0, receiptNo = "1234567890", transactionTypeId = 0, transactionTime = System.DateTime.Now }
             );
            config.Routes.MapHttpRoute(
                name: "ApiFindRfid",
                routeTemplate: "api/{controller}/{action}/{value}",
                defaults: null
            );
            

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

                             
            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();
        }
    }
}