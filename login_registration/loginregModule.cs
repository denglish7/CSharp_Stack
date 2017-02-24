using System;
using Nancy;
using ApiCaller;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using DbConnection;
using System.Text.RegularExpressions;
using CryptoHelper;

namespace loginregModule
{
    
    public class loginregModule : NancyModule
    {
        public loginregModule()
        {
            Get("/", args =>
            {
                ViewBag.show = Session["view"];
                ViewBag.not_valid = Session["not_valid"];
                List<string> displayErrors = (List<string>)Session["errors"];
                return View["loginreg.sshtml", displayErrors];
            });
            Post("/register", args => 
            {
                List<string> errors = new List<string>();

                string email = Request.Form["email"]; 
                string query = $"SELECT * FROM users WHERE email='{email}'";  
                List<Dictionary<string, object>> user = DbConnector.ExecuteQuery(query);
                
                if(Request.Form["email"] == "")
                {
                    errors.Add("Please enter an email address");
                }
                else if(Regex.IsMatch(Request.Form["email"],  @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$") == false)
                {
                    errors.Add("Not a valid email address");
                }
                else if (user.Count != 0)
                {
                    errors.Add("Email is in use");
                }

                if (!Request.Form["first_name"])
                {
                    errors.Add("Please enter a first name");
                }
                else if (((string)Request.Form.first_name).Length < 2)
                {
                    errors.Add("First name must be at least 2 characters");
                }   

                if (!Request.Form["last_name"])
                {
                    errors.Add("Please enter a last name");
                }
                else if (((string)Request.Form.last_name).Length < 2)
                {
                    errors.Add("Last name must be at least 2 characters");
                }   

                
                if (!Request.Form["password"])
                {
                    errors.Add("Please enter a password");
                }
                else if (((string)Request.Form.password).Length < 8)
                {
                    errors.Add("Password must be 8 characters");
                }   
                else if ((string)Request.Form["password"] != (string)Request.Form["confirm"])
                {
                    errors.Add("Password and confirm password must match");
                }
                    
                if(errors.Count != 0)
                {
                    Session["errors"] = errors;
                    bool view = true;
                    Session["view"] = view;
                    return Response.AsRedirect("~/");
                }
                else
                {
                    Console.WriteLine("hello");
                    string first_name = Request.Form["first_name"];
                    string last_name = Request.Form["last_name"];
                    string EncryptedString = Crypto.HashPassword(Request.Form["password"]);
                    string Query = $"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) Values ('{first_name}', '{last_name}', '{email}', '{EncryptedString}', NOW(), NOW())";
                    Session["user_id"] = DbConnector.ExecuteQuery(Query);
                }

                return Response.AsRedirect("~/success");
            });
            Post("/login", args =>
            {
                string email = Request.Form["email"]; 
                string password = Request.Form["password"]; 
                string query = $"SELECT * FROM users WHERE email='{email}'";  
                List<Dictionary<string, object>> user = DbConnector.ExecuteQuery(query);
                
                if(user.Count == 0)
                {
                    Session["not_valid"] = true;
                    return Response.AsRedirect("~/");
                }
                

                foreach(var entry in user)
                {
                    foreach(KeyValuePair<string, object> value in entry)
                    {
                        if (value.Key == "password")
                        {
                            Session["hashed_pw"] = value.Value.ToString();
                        }
                        
                    }
                }

                bool IsCorrectString = Crypto.VerifyHashedPassword((string)Session["hashed_pw"], (string)password);

                if(IsCorrectString)
                {
                    Session["hashed_pw"] = null;
                    Session["user_id"] = true;
                    return Response.AsRedirect("success");
                }

                return Response.AsRedirect("~/");
            });
            
            Get("/success", args =>
            {
                if((bool)Session["user_id"] != true)
                {
                    return Response.AsRedirect("~/");
                }
                return View["success.sshtml"];
            });
            Get("/logoff", args =>
            {
                Session.DeleteAll();
                return Response.AsRedirect("~/");
            });
        }
    }
}