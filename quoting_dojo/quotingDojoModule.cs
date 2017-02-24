using System;
using Nancy;
using ApiCaller;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using DbConnection;

namespace quotingDojoModule
{
    public class quotingDojoModule : NancyModule
    {
        public quotingDojoModule()
        {
            Get("/", args =>
            {
                return View["quotingDojo"];
            });
            Post("/quotes", args => 
            {
                string new_name = Request.Form["name"];
                string new_quote = Request.Form["quote"];
                string Query = $"INSERT INTO quotes (name, quote, created_at) Values ('{new_name}', '{new_quote}', NOW())"; 
                DbConnector.ExecuteQuery(Query);
                return Response.AsRedirect("~/quotes");
            });
            Get("/quotes", args =>
            {
                string Query = "SELECT * FROM quotes order by -id";
                List<Dictionary<string, object>> quotes = DbConnector.ExecuteQuery(Query);
                foreach(var key in quotes)
                {
                Console.WriteLine(key);
                }
                return View["quotingPage.sshtml", quotes];
            });
        }
    }
}