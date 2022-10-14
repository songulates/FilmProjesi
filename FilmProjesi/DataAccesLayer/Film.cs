using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmProjesi.DataAccesLayer
{
    public class Film
    {

        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="not empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "not empty")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "not empty")]
        public string Director { get; set; }
        
        //blog
        public int Year { get; set; }

        //public int CinemaID { get; set; }
        //public SinemaSalonu SinemaSalonu { get; set; }


    }
}
