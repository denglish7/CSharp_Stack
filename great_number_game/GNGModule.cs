using System;
using Nancy;

namespace GNGNancy
{
    public class GNGModule : NancyModule
    {
        public GNGModule()
        {
            Get("/", args =>
            {
                int RandNum = new Random().Next(1,101);
                Session["rand"] = RandNum; 
                ViewBag.gotit = true;
                return View["GNG"];
            });
            Post("/guess", args =>
            {
                int guess = (int)Request.Form["guess"];
                
                if((int)guess < (int)Session["rand"])
                {
                    ViewBag.tooLow = true;
                    ViewBag.gotit = true;
                }
                else if((int)guess > (int)Session["rand"])
                {
                    ViewBag.tooHigh = true;
                    ViewBag.gotit = true;
                }
                else if((int)guess == (int)Session["rand"])
                {
                    ViewBag.correct = true;
                    ViewBag.correct_num = (int)Session["rand"];
                    ViewBag.gotit = false;
                }

                return View["GNG"];
            });
            Post("/reset", args =>
            {
                Session.DeleteAll();
                return Response.AsRedirect("~/");
            });
        }
    }
}