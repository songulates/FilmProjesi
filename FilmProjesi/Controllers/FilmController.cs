using FilmProjesi.DataAccesLayer;
using FilmProjesi.Fluentfilm;
using FluentValidation.Results;
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
        
        


        [HttpPost]
        public IActionResult CreateFilm(Film film)    
        {
            FilmFluentValidator fv = new FilmFluentValidator();
            ValidationResult result = fv.Validate(film);
            if (result.IsValid)
            {
                using var c = new Context();
                c.Add(film);
                c.SaveChanges();
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
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
