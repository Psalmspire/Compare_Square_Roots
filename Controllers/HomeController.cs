using System.Collections.Specialized;
using System.Text;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CompSqrt.Models;

namespace CompSqrt.Controllers
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
            return View();
        }

         [HttpGet]
        public ActionResult Compare()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Compare( string firstNumber, string secondNumber)
        {
          
            int numberOne = int.Parse(firstNumber);
            int numberTwo = int.Parse(secondNumber);

            double firstSqrt = Math.Sqrt(numberOne);
            double secondSqrt = Math.Sqrt(numberTwo);



             if (numberOne < 0 || numberTwo < 0 )
            {
               ViewBag.Result = "Please enter a non-negative number";
            }
            if (firstNumber = "" || secondNumber = "")
            {
                ViewBag.Result = "One of the inputs is not a number. Inputs should be numbers."; 
            }

            if (firstSqrt > secondSqrt){
                ViewBag.Result = "The number " + numberOne + " with Square root " + firstSqrt + " has a higher square root than the number " + numberTwo + " with square root "+secondSqrt;
            }
            else if (firstSqrt < secondSqrt)
            {
                 ViewBag.Result = "The number " + numberTwo + " with Square root " + secondSqrt + " has a higher square root than the number " + numberOne + " with square root "+firstSqrt;
            }
            else if (firstSqrt == secondSqrt)
            {
                ViewBag.Result = "Both numbers have the same Square root. Please enter another set of numbers";
            }

            /*
            bool inputCompare = InputCompare(numberOne, numberTwo);
            bool compareSqrt = CompareSqrt(firstSqrt, secondSqrt);

            ViewBag.InputCompare = inputCompare;
            ViewBag.CompareSqrt = compareSqrt;
            */
            return View();
        
            
        }
/*
         bool InputCompare(int numberOne, int numberTwo)
         {
           
        }

        bool CompareSqrt(double firstSqrt, double secondSqrt){
        }
*/
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
