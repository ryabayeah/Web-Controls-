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
        public IActionResult SignUp() { ViewBag.secondPage = false; return View(); }

        [HttpPost]
        public IActionResult SignUp(SignUpModel model)
        {
            if (model.Email == null)
            {
                ViewBag.secondPage = true;
                return View("SignUp");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.secondPage = true;
                    return View("SignUp");
                }
                else 
                {
                    user.Email = model.Email;
                    user.Password = model.Password;
                    return View("SignUpResult", model); 
                }
            }
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            ViewBag.MessageState = "Email";
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(string action )
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
                    ViewBag.MessageState = "Email";
                    ViewBag.Message = "Check your email";
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
