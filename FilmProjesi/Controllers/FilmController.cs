using FilmProjesi.DataAccesLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmProjesi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult GetFilm()
        {
            using var c = new Context();
            var values = c.Films.ToList();
            return Ok(values);
        }
        
        [HttpGet("Filter")]
        public List<Film> sort(string Filmadı, int? yearfirst, int? yearsecond)
        {

            using var c = new Context();
            var result = c.Films.AsQueryable();
            if (!string.IsNullOrEmpty(Filmadı))
            {
                result = result.Where(x => x.Name.Contains(Filmadı));
            }
            if (yearfirst.HasValue)
            {
                result = result.Where(x => x.Year>=yearfirst);
            }

            if (yearsecond.HasValue)
            {
                result = result.Where(x => x.Year <= yearsecond);
            }
            var value = result.Select(x => new Film
            {
                Name = x.Name,
                Genre = x.Genre,
                Director=x.Director,
                Year =x.Year   

            }) ;
            return value.ToList();

        }


        [HttpPost]
        public IActionResult CreateFilm(Film film)    
        {
            using var c = new Context();
            c.Add(film);
            c.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFilm(int id)
        {
            using var c = new Context();
            var value = c.Films.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(value);
                c.SaveChanges();
                return Ok();
            }
           
        }

        [HttpPut]
        public IActionResult UpdateFilm(Film film)
        {
            using var c = new Context();
            var value = c.Find<Film>(film.ID);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                value.Name = film.Name;
                value.Genre = film.Genre;
                value.Director = film.Director;
                value.Year = film.Year;
                c.Update(value);
                c.SaveChanges();
                return Ok();
            }

        }
        
    }
}
