using blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace blog.ViewComponents.FooterLeft
{
    public class FooterLeft : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var liste = c.Iletisims.ToList();
            var list = c.Iletisims.FirstOrDefault();
            ViewBag.Facebook = list.Facebook.ToString();
            ViewBag.LinkedIn = list.LinkedIn.ToString();
            ViewBag.Twitter = list.Twitter.ToString();
            ViewBag.Instagram = list.Instagram.ToString();
            ViewBag.Youtube = list.Youtube.ToString();
            return View(liste);
        }
    }
}    