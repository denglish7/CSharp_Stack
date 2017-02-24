using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

namespace time_displayModule.Controllers
{
    public class time_displayController : Controller
    {
        [HttpGet]
        [RouteAttribute("")]
        public IActionResult Index()
        {
            DateTime CurrentTime = DateTime.Now;
            Console.WriteLine(CurrentTime.ToString("MMM dd, yyyy"));
            String[] cultureNames = 
            {
                "en-US"
            };
            ViewBag.timedisplay = CurrentTime.ToString("MMM dd, yyyy h:mm tt");
            return View();
        }
    }
}