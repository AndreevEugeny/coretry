using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication5.Controllers
{   [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private IWebHostEnvironment _applicationEnvironment;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _applicationEnvironment = webHostEnvironment;
        }

        [HttpGet("Get200")]

        public IEnumerable<Address> Get200()
        {
            var rng = new Random();
            using (AdventureWorks2019Context db = new AdventureWorks2019Context())
            {
                // получаем объекты из бд и выводим на консоль
                var adresses = db.Addresses.Take(200);

                return adresses.ToArray();
              
              
            }
            
            
         
        }
        [AllowAnonymous]
        [HttpGet("Take20")]
        public IEnumerable<WebApplication5.Models.File> Take(int index, int count)
        {
            using (AdventureWorks2019Context db = new AdventureWorks2019Context())
            {
                // получаем объекты из бд и выводим на консоль
                var images = db.Files.Skip(index).Take(count);

                return images.ToArray();


            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFileCollection _files)
        {
            foreach (IFormFile _file in _files)
            {
                if (_file != null)
                {
                    Models.File file = new Models.File() { };
                    using (AdventureWorks2019Context db = new AdventureWorks2019Context())
                    {
                        db.Files.Add(file);
                        await db.SaveChangesAsync();
                    }

                    string path = "/Files/" + file.Id + System.IO.Path.GetExtension(_file.FileName);



                    using (var fileStream = new FileStream(_applicationEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await _file.CopyToAsync(fileStream);
                        using (AdventureWorks2019Context db = new AdventureWorks2019Context())
                        {
                            file.Name = _file.FileName;
                            file.Path = path;
                            db.Files.Update(file);
                            await _file.CopyToAsync(fileStream);
                            await db.SaveChangesAsync();
                        }
                    }

                }
            }
            return Redirect("/fetch-data");
        }


        [HttpPost("mpost")]
        public  void UploadFile([FromForm] string form)
        {
            
        }
        public IEnumerable<Address> Take20()
        {
            var rng = new Random();
            using (AdventureWorks2019Context db = new AdventureWorks2019Context())
            {
                // получаем объекты из бд и выводим на консоль
                var adresses = db.Addresses.Take(20);

                return adresses.ToArray();


            }



            
        }
        
    }
}
