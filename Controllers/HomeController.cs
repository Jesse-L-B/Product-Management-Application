using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ProductManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;


namespace ProductManagementSystem.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            //try
            //{
            //    int i, j;
            //    i = 5;
            //    j = 0;
            //    int k = i / j;
            //    //throw new CustomException();
            //}

            //catch
            //{
            //    return RedirectToAction("Error");
            //}
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
