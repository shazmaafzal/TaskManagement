using Microsoft.AspNetCore.Mvc;
using TaskManagement.InfraStructure;
using TaskManagement.Services;

namespace TaskManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ISystemTimeProvider _timeProvider;
        private readonly IMessageServices _messageService;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ISystemTimeProvider timeProvider, IMessageServices messageService)
        {
            _logger = logger;
            _timeProvider = timeProvider;
            _messageService = messageService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("external-posts(External API Integration)")]
        public async Task<IActionResult> GetExternalPosts([FromServices] ExternalPostService service)
        {
            return Ok(await service.GetPostsAsync());
        }
        [HttpGet("current-time(e.g, Singleton DI)")]
        public IActionResult GetCurrentTime()
        {
            return Ok(new { Time = _timeProvider.GetCurrentTime() });
        }

        [HttpGet("transient-message(e.g, Transient DI)")]
        public IActionResult GetMessage()
        {
            return Ok(new { Message = _messageService.GetMessage() });
        }
    }
}
