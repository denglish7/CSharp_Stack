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
        private readonly MessageRepository messageRepository;
        private readonly CommentRepository commentRepository;
        public HomeController(UserRepository user, MessageRepository message, CommentRepository comment) 
        {
            userRepository = user;
            messageRepository = message;
            commentRepository = comment;

        }
        // // GET: /Home/
        // [HttpGet]
        // [Route("login")]
        // public IActionResult Index()
        // {
            
        //     return View("Index");
        // }

        [HttpPost]
        [Route("new")]
        public IActionResult New(User user)
        {
            if(userRepository.FindByEmail(user.Email) != null)
            {
                TempData["emailExists"] = "Email is in use";
                return RedirectToAction("Success");
            }
            
            List<string> regErrors = new List<string>();
            
            if(ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                userRepository.Add(user);
                TempData["regSuccess"] = "You have been successfully registered.";
            }
            else
            {
                foreach(var error in ModelState.Values)
                {
                    if(@error.Errors.Count > 0)
                    {
                        regErrors.Add(error.Errors[0].ErrorMessage);
                    }
                }
            }
            TempData["errors"] = regErrors;
            return RedirectToAction("Success");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult LoginMethod(string loginEmail, string PasswordToCheck)
        {
            List<string> logErrors = new List<string>();

            if(ModelState.IsValid)
            {
                User user = userRepository.FindByEmail(loginEmail);
                

                if(user != null && user.Password != null)
                {

                    var Hasher = new PasswordHasher<User>();
                    if(0 != Hasher.VerifyHashedPassword(user, user.Password, PasswordToCheck))
                    {
                        HttpContext.Session.SetInt32("user_id", user.Id);
                        return RedirectToAction("Success");
                    }
                    else
                    {
                        TempData["invalid"] = "Incorrect Password";
                        return RedirectToAction("Success");
                    }
                }
                else if(user == null)
                {
                    TempData["invalid"] = "Email not found";
                }
            }
            return RedirectToAction("Success");
        }
        [HttpGet]
        [Route("")]
        public IActionResult Success()
        {
            if(HttpContext.Session.GetInt32("user_id") == null)
            {
                ViewBag.invalid = TempData["invalid"];
                ViewBag.emailExists = TempData["emailExists"];
                ViewBag.errors = TempData["errors"];
                ViewBag.regSuccess = TempData["regSuccess"];
                ViewBag.logErrors = TempData["logErrors"];
                return View("Index");
            }
            else
            {
                ViewBag.user = userRepository.FindByID((int)HttpContext.Session.GetInt32("user_id"));
                ViewBag.messageErrors = TempData["mErrors"];
                ViewBag.messages = messageRepository.MessagesForUsersByID();
                ViewBag.comments = commentRepository.CommentsForMessagesByID();
                return View("Success");
            }
        }     
        [HttpGet]
        [Route("logoff")]
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Success");
        }

        [HttpPost]
        [Route("addMessage")]
        public IActionResult AddMessage(Message newMessage)
        {
            Console.WriteLine("Daniel");
            if(ModelState.IsValid)
            {
                newMessage.user_id = (int)HttpContext.Session.GetInt32("user_id");
                messageRepository.Add(newMessage);
                return RedirectToAction("Success");
            }
            TempData["mErrors"] = "Please enter a message";
            return RedirectToAction("Success");
        }
        [HttpPost]
        [Route("addComment/{Id}")]
        public IActionResult AddComment(Comment newComment, int Id)
        {
            if(ModelState.IsValid)
            {
                newComment.user_id = (int)HttpContext.Session.GetInt32("user_id");
                newComment.message_id = Id;
                commentRepository.Add(newComment);
            }
            return RedirectToAction("Success");
        }
    }
}
