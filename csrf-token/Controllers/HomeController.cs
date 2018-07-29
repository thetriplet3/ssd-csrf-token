﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using csrf_token.Models;
using Microsoft.AspNetCore.Http;

namespace csrf_token.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            string sessionValue = HttpContext.Session.GetString(Properties.Values.SESSION_KEY);
            if (string.IsNullOrEmpty(sessionValue))
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
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
