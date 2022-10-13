using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.Models
{
    public class UserMesaj
    {
        [Key]
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Konu { get; set; }
        public string Description { get; set; }
        public string Mail { get; set; }
    }
}
