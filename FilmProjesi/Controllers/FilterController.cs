using FilmProjesi.DataAccesLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmProjesi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     public class FilterController : ControllerBase
    {
       

            

            [HttpGet("Filter")]
            public List<Film> Filter(string Filmadı, string director, string filmturu, int? yearfirst, int? yearsecond, int? belirliyil)
            {

                using var c = new Context();
                var result = c.Films.AsQueryable();

                if (!string.IsNullOrEmpty(Filmadı))
                {
                    result = result.Where(x => x.Name.Contains(Filmadı));
                }
                if (!string.IsNullOrEmpty(director))
                {
                    result = result.Where(x => x.Director.Contains(director));
                }
                if (!string.IsNullOrEmpty(filmturu))
                {
                    result = result.Where(x => x.Genre.Contains(filmturu));
                }
                if (yearfirst.HasValue)
                {
                    result = result.Where(x => x.Year >= yearfirst);
                }

                if (yearsecond.HasValue)
                {
                    result = result.Where(x => x.Year <= yearsecond);
                }
                if (belirliyil.HasValue)
                {
                    result = result.Where(x => x.Year == belirliyil);
                }
                var value = result.Select(x => new Film
                {
                    Name = x.Name,
                    Genre = x.Genre,
                    Director = x.Director,
                    Year = x.Year

                });
                return value.ToList();

            }


            

            

        
    }
}
