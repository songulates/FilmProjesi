using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmProjesi.DataAccesLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-1TE9E4I;database=FilmsinemaDB; integrated security=true;");

        }
        //şimdi burda contextlerimizi yazalım. Entityleri çağırazağız.
        public DbSet<Film> Films { get; set; }
        public DbSet<SinemaSalonu> SinemaSalonus { get; set; }
        
    }
}
