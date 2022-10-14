using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmProjesi.DataAccesLayer
{
    public class SinemaSalonu
    {
        [Key]
        
        public string Name { get; set; }
        public int CinemaID { get; set; }


        //public List<Film> Films { get; set; }
    }
}
