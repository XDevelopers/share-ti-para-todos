using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TiParaTodos.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

    [ApiController]
    [Route("[controller]")]
    public class TiParaTodosController : ControllerBase
    {
        private static readonly List<Contact> Contacts = new List<Contact>();

        private readonly ILogger<TiParaTodosController> _logger;

        public TiParaTodosController(ILogger<TiParaTodosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return Contacts.ToArray();
        }

        [HttpPost]
        public IEnumerable<Contact> Post(Contact contact)
        {
            Contacts.Add(contact);

            return Contacts.ToArray();
        }
    }

    public class Contact 
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }

    }

}
