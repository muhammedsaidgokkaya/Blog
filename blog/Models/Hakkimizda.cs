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
    public class Hakkimizda
    {
        [Key]
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Description { get; set; }
        public string MisyonumuzBaslik { get; set; }
        public string MisyonumuzDescription { get; set; }
        public string VizyonBaslik { get; set; }
        public string VizyonDescription { get; set; }
        public string NedenBizBaslik { get; set; }
        public string NedenBizDescription { get; set; }
        public string BizKimizBaslik { get; set; }
        public string BizKimizDescription { get; set; }
        public string EkibimizBaslik { get; set; }
        public string EkibimizDescription { get; set; }
    }
}
