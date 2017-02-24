using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace dojodachi.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetObjectFromJson<Dojodachi>("myDojodachi") == null)
            {
                var myDojodachi = new Dojodachi();
                HttpContext.Session.SetObjectAsJson("myDojodachi", myDojodachi);
            }
            ViewBag.myDojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("myDojodachi");
            ViewBag.message = TempData["message"];
            return View();
        }
        [HttpPost]
        [Route("feed")]
        public IActionResult Feed()
        {
            Dojodachi myDojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("myDojodachi");
            int change = myDojodachi.feed();
            if(change != -1)
            {
                TempData["message"] = $"You fed your Dojodachi! Fullness +{change}, Meals -1";
            }
            HttpContext.Session.SetObjectAsJson("myDojodachi", myDojodachi);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("play")]
        public IActionResult Play()
        {
            Dojodachi myDojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("myDojodachi");
            int change = myDojodachi.play();
            if(change != -1)
            {
                TempData["message"] = $"You played with your Dojodachi! Happiness +{change}, Energy -5";
            }
            HttpContext.Session.SetObjectAsJson("myDojodachi", myDojodachi);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("work")]
        public IActionResult Work()
        {
            Dojodachi myDojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("myDojodachi");
            int change = myDojodachi.work();
            if(change != -1)
            {
                TempData["message"] = $"Your Dojodachi worked! Meals +{change}, Energy -5";
            }
            HttpContext.Session.SetObjectAsJson("myDojodachi", myDojodachi);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("sleep")]
        public IActionResult Sleep()
        {
            Dojodachi myDojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("myDojodachi");
            myDojodachi.sleep();
            TempData["message"] = $"Your Dojodachi slept! Energy +15 fullness -5 happiness -5";
            HttpContext.Session.SetObjectAsJson("myDojodachi", myDojodachi);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("restart")]
        public IActionResult Restart()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        public class Dojodachi
        {
            public int happiness = 20;
            public int fullness = 20;
            public int energy = 50;
            public int meals = 3;
            public int feed()
            {
                if(meals > 0)
                {
                    meals -= 1;
                    int like = new Random().Next(1,5);
                    int change = new Random().Next(5,11);
                    if(like != 1)
                    {
                        fullness += change;
                        return change;
                    }
                    return 0;
                }
                return -1;
            }
            public int play()
            {
                if(energy >= 5)
                {
                    
                    energy -= 5;
                    int like = new Random().Next(1,5);
                    if(like > 1)
                    {
                        int change = new Random().Next(5,11);
                        happiness += change;
                        return change;
                    }
                    return 0;
                }
                return -1;
            }
            public int work()
            {
                if(energy >= 5)
                {
                    int change = new Random().Next(1,4);
                    energy -= 5;
                    meals += change;
                    return change;
                }
                return -1;
            }
            public void sleep()
            {
                energy += 15;
                fullness -= 5;
                if(fullness <= 0)
                {
                    fullness = 0;
                }
                happiness -= 5;
                if(happiness <= 0)
                {
                    happiness = 0;
                }
            }
        }
    }
}
