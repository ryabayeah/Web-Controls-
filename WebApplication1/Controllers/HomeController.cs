using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        User user = new User();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger){ _logger = logger; }

        public IActionResult Index(){ return View(); }
        public IActionResult SignUpResult() { return View(); }

        [HttpGet]
        public IActionResult SignUp() { return View(); }
        public IActionResult SignUp2() { return View(); }

        [HttpPost]
        public IActionResult SignUp(SignUpModel model)
        {
            if (model.FN == null || model.LN == null)
            {
                return View("SignUp");
            }
            else if (model.Email == null)
            {
                ViewBag.Let = false;
                return View("SignUp2");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Let = true;
                    return View("SignUp2");
                }
                else if (model.Password != model.Confirm)
                {
                    ViewBag.Let = true;
                    ViewBag.Message = "Password mismatch";
                    return View("SignUp2");
                }
                else
                {
                    user.Email = model.Email;
                    user.Password = model.Password;
                    return View("SignUpResult", model);
                }
            }
            return View("SignUp2", model);
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            ViewBag.MessageState = "Email";
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(string action, string email)
        {
            if (action == "verify")
                {
                    ViewBag.MessageState = "Done";
                    
                }
            else if (action == "Have")
                {
                    ViewBag.MessageState = "Code";
                    
                }
            else
                {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    ViewBag.MessageState = "Email";
                    ViewBag.Message = "Check your email";
                }
                catch
                {
                    ViewBag.MessageState = "Email";
                    ViewBag.Message = "Email address is incorrect";
                }
  
                }
            return View("ResetPassword");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
