using blog.Models;
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
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IWebHostEnvironment _webHost;

        Context c = new Context();

        public UserController(ILogger<UserController> logger, IWebHostEnvironment webHost)
        {
            _logger = logger;
            _webHost = webHost;
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
            return RedirectToAction("Bloglarim", "User");
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
            return RedirectToAction("Bloglarim", "User");
        }

        public IActionResult BlogSil(int id)
        {
            var sil = c.Blogs.Find(id);
            c.Blogs.Remove(sil);
            c.SaveChanges();
            return RedirectToAction("Bloglarim", "User");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
