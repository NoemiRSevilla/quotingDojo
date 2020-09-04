using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using quotingDojo.Models;
using DbConnection;

namespace quotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpGet("quotes")]
        public IActionResult Quotes()
        {
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM Quote ORDER BY created_at DESC");
            ViewBag.AllQuotes = AllQuotes;
            return View ("Quotes");
        }
        [HttpPost("addquote")]
        public IActionResult AddQuote(Quote newQuote)
        {
            if (ModelState.IsValid)
            {
                string query=$"INSERT INTO Quote (Name, _Quote, created_at) VALUES ('{newQuote.Name}', '{newQuote._Quote}', Now())";
                DbConnector.Execute(query);
                return RedirectToAction("Quotes", newQuote);
            }
            else
            {
                return View("Index");
            }
        }
    }
}