using Laboratorium_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace Laboratorium_1.Controllers
{
    public enum Operators
    {
        UNKNOWN,ADD,SUB,MUL,DIV,POW
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Calculator(Operators op, double? a, double? b)
        {
            if(a== null || b == null)
            {
                return View("Error");
            }
           
            switch (op)
            {
                case Operators.ADD:
                    ViewBag.op =$"Wynik dodawania {a} + {b} = {a + b}";
                    break;
                case Operators.SUB:
                    ViewBag.op = $"Wynik odejmowania {a} - {b} = {a-b}";
                    break;
                case Operators.MUL:
                    ViewBag.op = $"Wynik mnożenia {a} * {b} = {a * b}";
                    break;
                case Operators.DIV:
                    ViewBag.op = $"Wynik dzielenia {a} / {b} = {a / b}";
                    break;
                case Operators.POW:
                    ViewBag.op = $"Wynik Potęgowania {a} ^ {b} = {Math.Pow(a.Value,b.Value)}";
                    break;
                case Operators.UNKNOWN:
                    return View("Error");
                    
               
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}