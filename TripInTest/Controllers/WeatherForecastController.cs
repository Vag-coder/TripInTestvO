using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripInTest.MongoDB;

namespace TripInTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("Apalos")]
        public void Apalos()
        {
            User user = new User
            {
                FirstName = "aaa",
                LastName = "sd",
                State = "dsd",
                City = "dsdsd",
                PostCode = 32412
            };
            MongoDBGenerics db = new MongoDBGenerics("MyFirstTest");
            db.InsertRecord<User>("Triparoume", user);
        }
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
           
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
