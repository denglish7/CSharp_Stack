using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

namespace dojo_surveyModule.Controllers
{
    public class dojo_surveyController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("process")]
        public IActionResult Process(string name, string location, string language, string comment)
        {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;
            return View("success");
        }
        // [HttpPost]
        // [Route("goback")]
        // public IActionResult GoBack()
        // {
        //     return RedirectToAction("Index");
        // }
    }
}