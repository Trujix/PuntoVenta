using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVenta.Models;

namespace PVenta.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (VerificarSessionVars())
            {
                return RedirectToAction("Principal");    
            }
            else
            {
                return View();
            }
        }

        public IActionResult Principal()
        {
            if (VerificarSessionVars())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
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

        public bool VerificarSessionVars()
        {
            return HttpContext.Session.GetString("Token") != null;
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
