using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class AppUser : IdentityUser<int>
    {
        public string namesurname { get; set; }
        public string Adres1 { get; set; }
        public string Adres2 { get; set; }
        public string Adres3 { get; set; }
    }
 
}
