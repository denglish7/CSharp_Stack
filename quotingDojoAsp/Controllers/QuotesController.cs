using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotingDojoAsp.Models;
using quotingDojoAsp.Factory;


namespace quotingDojoAsp.Controllers
{
    public class QuotesController : Controller
    {
        // GET: /Home/
        private readonly QuoteFactory quoteFactory;
        public QuotesController()
        {
            quoteFactory = new QuoteFactory();
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            return View();
        }
        [HttpGet]
        [Route("skipToQuotes")]
        public IActionResult skipToQuotes()
        {
            ViewBag.quotes = quoteFactory.FindAll();
            return View("allQuotes");
        }
        [HttpPost]
        [Route("addQuote")]
        public IActionResult addQuote(Quote NewQuote)
        {
            if(ModelState.IsValid)
            {
                quoteFactory.Add(NewQuote);
                return RedirectToAction("skipToQuotes");
            }
            ViewBag.errors = ModelState.Values;
            return View("Index");                    
            
        }
    }
}
