using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dapperRelations.Models;
using DapperApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;


namespace DapperApp.Controllers
{
    public class QuotesController : Controller
    {
        // GET: /Home/
        private readonly QuoteRepository quoteRepository;
        private readonly UserRepository userRepository;
        public QuotesController(QuoteRepository quote, UserRepository user)
        {
            quoteRepository = quote;
            userRepository = user;
        }
        [HttpGet]
        [Route("skipToQuotes")]
        public IActionResult skipToQuotes()
        {
            ViewBag.quotes = quoteRepository.QuotesForUserById();
            ViewBag.myquotes = HttpContext.Session.GetInt32("user_id");
            return View("allQuotes");
        }
        [HttpGet]
        [Route("delete/{Id}")]
        public IActionResult Delete(string Id)
        {
            quoteRepository.Delete(Id);
            return RedirectToAction("skipToQuotes");
        }
        [HttpGet]
        [Route("editPage/{Id}")]
        public IActionResult UpdatePage(int Id)
        {
            ViewBag.update = Id;
            ViewBag.quoteToEdit = quoteRepository.FindByID(Id);
            return View("editQuotes");
        }
        
        [HttpPost]
        [Route("edit/{Id}")]
        public IActionResult Update(string quote, string Id)
        {
            Console.WriteLine("hello");
            quoteRepository.Update(quote, Id);
            return RedirectToAction("skipToQuotes");
        }

        [HttpPost]
        [Route("addQuote")]
        public IActionResult addQuote(Quote newQuote)
        {
            Console.WriteLine(newQuote);
            if(ModelState.IsValid)
            {
                newQuote.user_id = (int)HttpContext.Session.GetInt32("user_id");
                quoteRepository.Add(newQuote);
                return RedirectToAction("skipToQuotes");
            }
            ViewBag.user = userRepository.FindByID((int)HttpContext.Session.GetInt32("user_id"));
            ViewBag.quoteErrors = ModelState.Values;
            return View("success");                
        }
    }
}
