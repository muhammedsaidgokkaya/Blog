using blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        // GET: api/<BlogController>
        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            List<Blog> blogs = new List<Blog>();
            using (Context c = new Context())
            {
                blogs = c.Blogs.ToList();
            }
            return blogs;
        }

        // GET api/<BlogController>/5
        [HttpGet("{id}")]
        public Blog Get(int id)
        {
            Blog blog = new Blog();
            using (Context c = new Context())
            {
                blog = c.Blogs.Find(id);
            }
            return blog;
        }
        
    }
}
