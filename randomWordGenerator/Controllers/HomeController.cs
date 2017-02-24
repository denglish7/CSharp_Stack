using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace randomWordGenerator.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("counter") == null)
            {
                HttpContext.Session.SetInt32("counter", 0);
            }
            
            if(HttpContext.Session.GetString("randomWord") == null)
            {
                HttpContext.Session.SetString("randomWord", "");
            }
            
            ViewBag.randomWord = HttpContext.Session.GetString("randomWord");
            ViewBag.counter = HttpContext.Session.GetInt32("counter");
            return View();
        }
        [HttpPost]
        [RouteAttribute("generate")]
        public IActionResult Generate()
        {
            int counter = (int)HttpContext.Session.GetInt32("counter"); 
            counter+=1;
            HttpContext.Session.SetInt32("counter", counter);
            
            string numletters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            if((string)HttpContext.Session.GetString("randomWord") !=null)
            {
                HttpContext.Session.SetString("randomWord", "");
            }
            
            string randomWord = (string)HttpContext.Session.GetString("randomWord");

            Random rand = new Random();
            char ch;
            for(var i=0; i<14; i++)
            {
                ch = numletters[rand.Next(0,numletters.Length)];
                // Console.WriteLine(ch);
                randomWord+=ch;
            }
            Console.WriteLine(randomWord);
            HttpContext.Session.SetString("randomWord", randomWord);
            return RedirectToAction("Index");
        }
    }
}
