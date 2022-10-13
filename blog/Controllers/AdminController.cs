using blog.Models;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace blog.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IWebHostEnvironment _webHost;

        Context c = new Context();

        public AdminController(ILogger<AdminController> logger, IWebHostEnvironment webHost)
        {
            _logger = logger;
            _webHost = webHost;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Category()
        {
            return View();
        }

        public IActionResult CategoryAdd()
        {
            return View();
        }

        public IActionResult CategoryUpdate()
        {
            return View();
        }

        public IActionResult CategoryDelete()
        {
            return View();
        }

        public IActionResult Blog()
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

        public IActionResult MesajKutusu()
        {
            return View();
        }

        public IActionResult AdminMesajSil()
        {
            return View();
        }

        public IActionResult UserMesajSil()
        {
            return View();
        }

        public IActionResult Profilim()
        {
            return View();
        }

        // anasayfa düzenleme
        public IActionResult IletisimBilgileri()
        {
            var iletisim = c.Iletisims.FirstOrDefault();
            Iletisim dto = new Iletisim
            {
                Id = iletisim.Id,
                Adres = iletisim.Adres,
                Eposta = iletisim.Eposta,
                Facebook = iletisim.Facebook,
                Instagram = iletisim.Instagram,
                LinkedIn = iletisim.LinkedIn,
                Phone = iletisim.Phone,
                Saatler = iletisim.Saatler,
                Twitter = iletisim.Twitter,
                Youtube = iletisim.Youtube,
            };
            return View(dto);
        }

        [HttpPost]
        public IActionResult IletisimBilgileri(Iletisim dto)
        {
            Iletisim iletisim = new Iletisim
            {
                Id = dto.Id,
                Adres = dto.Adres,
                Eposta = dto.Eposta,
                Facebook = dto.Facebook,
                Instagram = dto.Instagram,
                LinkedIn = dto.LinkedIn,
                Phone = dto.Phone,
                Saatler = dto.Saatler,
                Twitter = dto.Twitter,
                Youtube = dto.Youtube,
            };
            c.Iletisims.Update(iletisim);
            c.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult FooterDuzenle()
        {
            var footer = c.Footers.FirstOrDefault();
            Footer dto = new Footer
            {
                Id = footer.Id,
                Baslik = footer.Baslik,
                Description = footer.Description,
            };
            return View(dto);
        }

        [HttpPost]
        public IActionResult FooterDuzenle(Footer dto)
        {
            Footer footer = new Footer
            {
                Id = dto.Id,
                Baslik = dto.Baslik,
                Description = dto.Description,
            };
            c.Footers.Update(footer);
            c.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
