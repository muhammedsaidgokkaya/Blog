using blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace blog.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MesajKutusu()
        {
            return View();
        }

        public IActionResult Profilim()
        {
            return View();
        }

        public IActionResult Bloglarim()
        {
            return View();
        }

        public IActionResult BlogEkle()
        {
            return View();
        }

        public IActionResult BlogDuzenle()
        {
            return View();
        }

        public IActionResult BlogSil()
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
