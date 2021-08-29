using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripIn.Core.Base.Services;
using TripIn.Core.Interfaces;
using TripIn.Core.Models;

namespace TripInTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IUserBusinessServiceAsync _userBusinessService;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserBusinessServiceAsync userBusinessService)
        {
            _logger = logger;
            _userBusinessService = userBusinessService;
        }
        [HttpGet]
        [Route("Apalos")]
        public void Apalos()
        {
            User user = new User
            {
                Id = Guid.Parse("d20559b0-f04c-4ab5-b3ca-4fd817b55c88"),
                FirstName = "Oti Thelw",
                LastName = "Manou",
                State = "Argolis",
                City = "Nafplio",
                PostCode = 21100
            };

            //ADD User
            //_userBusinessService.InsertRecord<User>("Triparoume", user);

            // Load All Users (Trparoume is collection with users)
            // var users = _userBusinessService.LoadRecords("Triparoume");

            // Retrieve a User from DB with Id
            //var DbUser = _userBusinessService.LoadRecordById(Guid.Parse("d20559b0-f04c-4ab5-b3ca-4fd817b55c88"), "Triparoume");

            //Add or Update User (If Id found in Collection => Update  Else => Insert)
            //_userBusinessService.UpsertRecord<User>(Guid.Parse("d20559b0-f04c-4ab5-b3ca-4fd817b55c88"), user, "Triparoume");

            //Delete a specific User from DB with Id
            //_userBusinessService.DeleteRecord<User>(Guid.Parse("d20559b0-f04c-4ab5-b3ca-4fd817b55c88"), "Triparoume");

            // Returns Users FullName
            //var fullName =_userBusinessService.GetFullName(DbUser);
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
