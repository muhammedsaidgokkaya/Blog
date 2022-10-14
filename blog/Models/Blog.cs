using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace blog.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Konu { get; set; }
        public string Description { get; set; }
        public string Tarih { get; set; }
        public bool Popular { get; set; }
        public bool Trend { get; set; }
        public string ResimYol { get; set; }
        [NotMapped]
        public IFormFile Resim { get; set; }
        public int CategoryId { get; set; }
        public string CategoryBaslik { get; set; }
        public Category Category { get; set; }
    }
}
