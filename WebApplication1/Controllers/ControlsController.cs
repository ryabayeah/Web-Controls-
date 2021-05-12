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
    public class ControlsController : Controller
    {

        private readonly ILogger<ControlsController> _logger;

        public ControlsController(ILogger<ControlsController> logger) { _logger = logger; }

        public IActionResult Index() { return View(); }
        public IActionResult TextBox() { return View(); }
        public IActionResult TextArea() { return View(); }
        public IActionResult Radio() { return View(); }
        public IActionResult ListBox() { return View(); }
        public IActionResult DropDownList() { return View(); }
        public IActionResult CheckBox() { return View(); }
        [HttpPost]
        public IActionResult ShowResult(string first, string second)
        {
            Console.WriteLine(second+"***********************");
            ViewBag.first = first;
            ViewBag.second = second;
            
            if (first == "isSelected") { ViewBag.second = second == "isSelected" ? "True" : "False"; };
            return View("Result");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
