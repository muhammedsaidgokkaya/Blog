using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;username=root;password=sonel.1234;database=blog;port=3306");
        }
        public DbSet<Iletisim> Iletisims { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public DbSet<Referanslar> Referanslars { get; set; }
        public DbSet<AdminMesaj> AdminMesajs { get; set; }
        public DbSet<UserMesaj> UserMesajs { get; set; }
    }
}