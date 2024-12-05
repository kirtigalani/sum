using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sum.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace sum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ans = TempData.Peek("ans");
            return View();
        }

        [HttpPost]   
        public IActionResult Index(Usermodel um,string sum)
        {
            int a = um.a;
            int b = um.b;
            int c = um.ans;
            if(sum == "add")
            {
                c = a + b;
            }
            if (sum == "mul")
            {
                c = a * b;
            }
            if (sum == "sub")
            {
                c = a - b;
            }
            if (sum == "div")
            {
                c = a / b;
            }
            TempData["ans"] = c;
            return RedirectToAction();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
