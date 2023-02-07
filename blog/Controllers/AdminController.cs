using blog.Enums;
using blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace blog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IWebHostEnvironment _webHost;
        private readonly UserManager<AppUser> _usermanager;

        Context c = new Context();

        public AdminController(ILogger<AdminController> logger, IWebHostEnvironment webHost, UserManager<AppUser> usermanager)
        {
            _logger = logger;
            _webHost = webHost;
            _usermanager = usermanager;
        }

        public IActionResult Index()
        {
            var username = User.Identity.Name;
            var userid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var usernamesurname = c.Users.Where(x => x.UserName == username).Select(y => y.namesurname).FirstOrDefault();
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userSayisi = c.Users.Count().ToString();
            var uyeidleri = c.Users.Select(y => y.Id).ToList();
            var telefon = c.Iletisims.FirstOrDefault();

            ViewBag.Phone = telefon.Phone;
            ViewBag.Eposta = telefon.Eposta;
            ViewBag.Saatler = telefon.Saatler;
            ViewBag.kullaniciAdi = username;
            ViewBag.adsoyad = usernamesurname;
            ViewBag.mail = usermail;
            ViewBag.userSayisi = userSayisi;
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

        public IActionResult AdminMesajDetails(int? id)
        {
            var a = c.AdminMesajs.Find(id);
            return View(a);
        }
        
        public IActionResult UserMesajDetails(int? id)
        {
            var a = c.UserMesajs.Find(id);
            return View(a);
        }

        public IActionResult AdminMesajSil(int id)
        {
            var sil = c.AdminMesajs.Find(id);
            c.AdminMesajs.Remove(sil);
            c.SaveChanges();
            return RedirectToAction("MesajKutusu", "Admin");
        }

        public IActionResult UserMesajSil(int id)
        {
            var sil = c.UserMesajs.Find(id);
            c.UserMesajs.Remove(sil);
            c.SaveChanges();
            return RedirectToAction("MesajKutusu", "Admin");
        }

        public IActionResult Profilim()
        {
            var username = User.Identity.Name;
            var namesurname = c.Users.Where(x => x.UserName == username).Select(y => y.namesurname).FirstOrDefault();
            var pass = c.Users.Where(x => x.UserName == username).Select(y => y.PasswordHash).FirstOrDefault();
            var mail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var adress1 = c.Users.Where(x => x.UserName == username).Select(y => y.Adres1).FirstOrDefault();
            var adress2 = c.Users.Where(x => x.UserName == username).Select(y => y.Adres2).FirstOrDefault();
            var adress3 = c.Users.Where(x => x.UserName == username).Select(y => y.Adres3).FirstOrDefault();
            KullaniciGuncelleDto dto = new KullaniciGuncelleDto
            {
                namesurname = namesurname,
                username = username,
                password = pass,
                email = mail,
                Adres1 = adress1,
                Adres2 = adress2,
                Adres3 = adress3,

            };

            return View(dto);
        }

        public IActionResult ProfilDuzenle()
        {
            var username = User.Identity.Name;
            var namesurname = c.Users.Where(x => x.UserName == username).Select(y => y.namesurname).FirstOrDefault();
            var pass = c.Users.Where(x => x.UserName == username).Select(y => y.PasswordHash).FirstOrDefault();
            var mail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var adress1 = c.Users.Where(x => x.UserName == username).Select(y => y.Adres1).FirstOrDefault();
            var adress2 = c.Users.Where(x => x.UserName == username).Select(y => y.Adres2).FirstOrDefault();
            var adress3 = c.Users.Where(x => x.UserName == username).Select(y => y.Adres3).FirstOrDefault();
            KullaniciGuncelleDto dto = new KullaniciGuncelleDto
            {
                namesurname = namesurname,
                username = username,
                password = pass,
                email = mail,
                Adres1 = adress1,
                Adres2 = adress2,
                Adres3 = adress3,

            };
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> ProfilDuzenle(KullaniciGuncelleDto model)
        {
            AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
            user.namesurname = model.namesurname;
            user.UserName = model.username;
            user.PasswordHash = _usermanager.PasswordHasher.HashPassword(user, model.password);
            user.Email = model.email;
            user.Adres1 = model.Adres1;
            user.Adres2 = model.Adres2;
            user.Adres3 = model.Adres3;
            IdentityResult result = await _usermanager.UpdateAsync(user);
            return RedirectToAction("Profilim", "Admin");
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
