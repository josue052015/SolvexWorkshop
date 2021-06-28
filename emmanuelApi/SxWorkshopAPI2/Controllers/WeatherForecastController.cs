using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SxWorkshopAPI2.Controllers
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

        [HttpGet("route/{id}")]
        public IActionResult Route([FromRoute] int id)
        {
            return Ok(id);
        }
        [HttpGet("query")]
        public IActionResult Query([FromQuery] string q, [FromQuery] int x)
        {
            return Ok(new { 
                q, x
            });
        }
        [HttpGet("header")]
        public IActionResult Header([FromHeader] int id)
        {
            return Ok(id);
        }

        [HttpPost("all/{id}")]
        public IActionResult All(
            [FromHeader] string name, 
            [FromRoute] int id, 
            [FromQuery] string description, 
            [FromBody] Data data)
        {
            return Ok(new { 
                Id = id,
                Name = name,
                Description = description,
                Data = data
            });
        }
        [HttpPost("[action]")]
        public IActionResult ReverseName(Data data)
        {
            var resersedName = data.Name.Reverse();
            data.Name = string.Join("",resersedName);
            return Ok(data);
        }
    }
}
