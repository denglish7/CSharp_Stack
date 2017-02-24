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
    public class HomeController : Controller
    {
        private readonly UserRepository userRepository;
        public HomeController(UserRepository user) 
        {
            userRepository = user;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.invalid = TempData["invalid"];
            ViewBag.errors = new List<string>();
            return View();
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        [Route("new")]
        public IActionResult New(User user)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                userRepository.Add(user);
            }
            ViewBag.errors = ModelState.Values;
            return View("Index");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult LoginMethod(string loginEmail, string PasswordToCheck)
        {
            User user = userRepository.FindByEmail(loginEmail);
            if(user != null && user.Password != null)
            {
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, PasswordToCheck))
                {
                    HttpContext.Session.SetInt32("user_id", user.Id);
                    return RedirectToAction("success");
                }
            }
            TempData["invalid"] = "Email or Password not found";
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            if(HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.user = userRepository.FindByID((int)HttpContext.Session.GetInt32("user_id"));
            ViewBag.quoteErrors = new List<string>();
            return View("success");
        }     
        [HttpGet]
        [Route("logoff")]
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
