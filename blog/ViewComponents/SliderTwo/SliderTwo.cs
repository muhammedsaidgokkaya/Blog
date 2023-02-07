using blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace blog.ViewComponents.SliderTwo
{
    public class SliderTwo : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var a = c.Blogs.ToList();
            return View(a);
        }
    }
}