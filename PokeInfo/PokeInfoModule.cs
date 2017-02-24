using System;
using Nancy;
using ApiCaller;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace PokeInfoModule
{
    public class PokeInfoModule : NancyModule
    {
        public PokeInfoModule()
        {
            Get("/", args =>
            {
                // string name = "";
                // string type = "";
                ViewBag.name = "";
                ViewBag.type = "";
                ViewBag.height = "";
                ViewBag.weight = "";

                // Our anonymous function is a parameter of type Action that returns a Dictionary
               
                return View["PokeInfo"];
            });
            Get("/{id}", async args => 
            {
                await WebRequest.SendRequest($"http://pokeapi.co/api/v2/pokemon/{args.id}", new Action<Dictionary<string, object>>( JsonResponse =>
                    {
                        ViewBag.name = (string)JsonResponse["name"];
                        ViewBag.type = (string)((JObject)((JArray)JsonResponse["types"])[0])["type"]["name"];
                        ViewBag.height = (Int64)JsonResponse["height"];
                        ViewBag.weight = (Int64)JsonResponse["weight"];
                    }
                ));
                return View["PokeInfo"];
            });
        }
    }
}