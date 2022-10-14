
using FilmWeb.FluentValidator;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FilmWeb.Controllers
{
    public class FilmWebController : Controller
    {
       
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44346/api/Film");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
           
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateFilm()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFilm(Class1 p)
        {
            FilmValid fv = new FilmValid();
            ValidationResult result = fv.Validate(p);
            if (result.IsValid)
            {
                var httpClient = new HttpClient();

                var jsonfilms = JsonConvert.SerializeObject(p);
                StringContent content = new StringContent(jsonfilms, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PostAsync("https://localhost:44346/api/Film", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
               
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(p);

        }
        

        [HttpGet]
        public async Task<IActionResult> EditFilm(int id)
        {
            Class1 class1 = new Class1();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44346/api/Film/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    class1 = JsonConvert.DeserializeObject<Class1>(apiResponse);
                }
            }
            return View(class1);
        }


        [HttpPost]
        public async Task<IActionResult> EditFilm(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonFilm = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonFilm, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44346/api/Film", content);
        
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }


       


        public async Task<IActionResult> DeleteFilm(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44346/api/Film/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

         }
           
    }
    public class Class1
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
    }
}
