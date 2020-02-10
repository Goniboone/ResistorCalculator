using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResCalculator.Models;

namespace ResCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

        public IActionResult Index()
        {
            ViewBag.bandOne = "Select One";
            ViewBag.bandTwo = "Select One";
            ViewBag.bandThree = "Select One";
            ViewBag.bandFour = "Select One";
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(ResistorBands rb)
        {
            var C = new OhmValueCalc();
            ViewData["OhmValue"] = C.CalculateOhmValue(rb.bandA, rb.bandB, rb.bandC);
            ViewData["Tolerance"] = $"{C.GetTolerance(rb.bandD)}%";
            ViewBag.bandOne = rb.bandA;
            ViewBag.bandTwo = rb.bandB;
            ViewBag.bandThree = rb.bandC;
            ViewBag.bandFour = rb.bandD;
            return View("index", rb);
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
