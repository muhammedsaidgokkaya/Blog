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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        Context c = new Context();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }

        public IActionResult Iletisim()
        {
            var list = c.Iletisims.FirstOrDefault();
            ViewBag.Adres = list.Adres.ToString();
            ViewBag.Eposta = list.Eposta.ToString();
            ViewBag.Phone = list.Phone.ToString();
            ViewBag.Saatler = list.Saatler.ToString();
            return View();
        }

        public IActionResult Referanslar()
        {
            return View();
        }

        public IActionResult ReferansDetay()
        {
            return View();
        }

        public IActionResult DestekPortali()
        {
            return View();
        }

        public IActionResult ContactUs()
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
