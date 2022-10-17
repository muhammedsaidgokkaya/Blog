using blog.Models;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var a = c.Categories.ToList();
            return View(a);
        }

        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAdd(Category category)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHost.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(category.Resim.FileName);
                string extension = Path.GetExtension(category.Resim.FileName);
                category.ResimYol = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Resimler/Category/", filename);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await category.Resim.CopyToAsync(filestream);
                }
                c.Categories.Add(category);
                c.SaveChanges();
            }
            return RedirectToAction("Category", "Admin");
        }

        public IActionResult CategoryUpdate(int id)
        {
            var guncelle = c.Categories.Find(id);
            return View(guncelle);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryUpdate(Category category)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHost.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(category.Resim.FileName);
                string extension = Path.GetExtension(category.Resim.FileName);
                category.ResimYol = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Resimler/Category/", filename);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await category.Resim.CopyToAsync(filestream);
                }
                c.Categories.Update(category);
                c.SaveChanges();
            }
            return RedirectToAction("Category", "Admin");
        }

        public IActionResult CategoryDelete(int id)
        {
            var sil = c.Categories.Find(id);
            c.Categories.Remove(sil);
            c.SaveChanges();
            return RedirectToAction("Category", "Admin");
        }

        public IActionResult Blog()
        {
            var a = c.Blogs.ToList();
            return View(a);
        }

        public IActionResult BlogEkle()
        {
            var value = c.Categories.ToList();
            List<SelectListItem> CategoryList = (from x in value
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Baslik,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.Category = CategoryList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BlogEkle(Blog blog)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHost.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(blog.Resim.FileName);
                string extension = Path.GetExtension(blog.Resim.FileName);
                blog.ResimYol = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Resimler/Blog/", filename);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await blog.Resim.CopyToAsync(filestream);
                }
                c.Blogs.Add(blog);
                c.SaveChanges();
            }
            return RedirectToAction("Blog", "Admin");
        }

        public IActionResult BlogDuzenle(int id)
        {
            var value = c.Categories.ToList();
            List<SelectListItem> CategoryList = (from x in value
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Baslik,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.Category = CategoryList;
            var guncelle = c.Blogs.Find(id);
            return View(guncelle);
        }
        [HttpPost]
        public async Task<IActionResult> BlogDuzenle(Blog blog)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHost.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(blog.Resim.FileName);
                string extension = Path.GetExtension(blog.Resim.FileName);
                blog.ResimYol = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Resimler/Blog/", filename);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await blog.Resim.CopyToAsync(filestream);
                }
                c.Blogs.Update(blog);
                c.SaveChanges();
            }
            return RedirectToAction("Blog", "Admin");
        }

        public IActionResult BlogSil(int id)
        {
            var sil = c.Blogs.Find(id);
            c.Blogs.Remove(sil);
            c.SaveChanges();
            return RedirectToAction("Blog", "Admin");
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
