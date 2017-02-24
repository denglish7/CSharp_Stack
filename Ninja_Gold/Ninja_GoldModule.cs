using System;
using Nancy;
using System.Collections.Generic;

namespace Ninja_GoldNancy
{
    public class Ninja_GoldModule : NancyModule
    {
        public static List<string> ActivityLog;
        public Ninja_GoldModule()
        {
            Get("/", args =>
            {
                if(Session["your_gold"] == null)
                {
                    Session["your_gold"] = 0;
                }
                if(Session["activity_log"] == null)
                {
                    ActivityLog = new List<string>();
                    Session["activity_log"] = ActivityLog;
                }

                ViewBag.your_gold = Session["your_gold"];

                return View["Ninja_Gold", ActivityLog];
            });
            Post("/process_money", args =>
            {
                var building = Request.Form["building"];

                if(building == "farm")
                {
                    int new_gold = new Random().Next(10,20);
                    Session["new_gold"] = new_gold;
                    Session["your_gold"] = (int)Session["your_gold"] + new_gold;
                }
                else if(building == "casino")
                {
                    int new_gold = new Random().Next(-50,50);
                    Session["new_gold"] = new_gold;
                    Session["your_gold"] = (int)Session["your_gold"] + new_gold;
                }
                else if(building == "cave")
                {
                    int new_gold = new Random().Next(5,10);
                    Session["new_gold"] = new_gold;
                    Session["your_gold"] = (int)Session["your_gold"] + new_gold;
                }
                else
                {
                    int new_gold = new Random().Next(2,5);
                    Session["new_gold"] = new_gold;
                    Session["your_gold"] = (int)Session["your_gold"] + new_gold;
                }

                if((int)Session["new_gold"]>0)
                {
                    Session["new_activity"] = $"<p class='green'>Earned {Session["new_gold"]} from the {building}</p>";
                }
                else
                {
                    Session["new_activity"] = $"<p class='red'>Lost {Math.Abs((int)Session["new_gold"])} from the {building}</p>";
                }

                ActivityLog.Insert(0, (string)Session["new_activity"]);
                Session["activity_log"] = ActivityLog;

                return Response.AsRedirect("~/");
            });

            Post("/reset", args =>
            {
                Session.DeleteAll();
                return Response.AsRedirect("~/");
            });
        }
    }
}