using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LabW12Quotes.Models;
using LabW12Quotes.Services;

namespace LabW12Quotes.Controllers
{
    public class HomeController : Controller
    {
        private IQuotesRepository _quotes;

        public HomeController(IQuotesRepository quotes)
        {
            _quotes = quotes;
        }

        public IActionResult Index()
        {
            return View(_quotes.ReadAll());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
