using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.Models
{
    public class Iletisim
    {
        [Key]
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Adres { get; set; }
        public string Eposta { get; set; }
        public string Saatler { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string LinkedIn { get; set; }
        public string Youtube { get; set; }
    }
}
