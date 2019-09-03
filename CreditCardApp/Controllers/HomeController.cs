using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CreditCardApp.Models;
using CreditCardApp.BusinessLayer;
using Newtonsoft.Json;

namespace CreditCardApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return View();
            }
            else
            {
                var apiCardInfo = ApiHelper.GetCardInfo(userId).ConvertToCardViewModel();
                ViewData["CardData"] = apiCardInfo;
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
