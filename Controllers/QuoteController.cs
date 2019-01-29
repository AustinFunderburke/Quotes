using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabW12Quotes.Models.Entities;
using LabW12Quotes.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabW12Quotes.Controllers
{
    public class QuoteController : Controller
    {
        private IQuotesRepository _quotes;

        private static Random _r = new Random();

        public QuoteController(IQuotesRepository quotes)
        {
            _quotes = quotes;
        }

        public IActionResult Index()
        {
            return View(_quotes.ReadAll());
        }
        
        public IActionResult RandomQuote()
        {
            var quotes = _quotes.ReadAll().ToList();

            var quote = quotes.ElementAt(_r.Next(quotes.Count));
            return Json(new
            {
                quote.TheQuote,
                quote.WhoSaidIt
            });
        }

        private bool IsAjaxRequest()
        {
            return Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        [HttpPost]
        public IActionResult Create(Quote quote)
        {
            if (ModelState.IsValid)
            {
              
                _quotes.Create(quote);
                if (IsAjaxRequest())
                {
                    return Json("Ok");
                }
            }
            if (IsAjaxRequest())
            {
                return Json("Not Ok");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}