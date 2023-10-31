using Examen_Opdracht_NET_Advanced.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Opdracht_NET_Advanced
{
    internal class MyDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Progres> Progreses { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Database=(localDB)\\DbExamenOpdrachtAdvanced;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true");
        }
    }
}
