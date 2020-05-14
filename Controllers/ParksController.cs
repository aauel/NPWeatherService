using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NPWeatherService.Data;
using NPWeatherService.Models;

namespace NPWeatherService.Controllers
{
    public class ParksController : Controller
    {
        private readonly NPDbContext _context;
        private readonly IConfiguration Configuration;
        private const string _apiEnvVar = "DarkSkyApiKey";
        private readonly string _apiKey;
        private readonly DarkSkyService darkSky;

        public ParksController(NPDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
            _apiKey = Configuration[_apiEnvVar];
            darkSky = new DarkSkyService(_apiKey);
        }

        // GET: Parks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parks.ToListAsync());
        }

        // GET: Parks/Details/{id}
        public async Task<IActionResult> Details(string id)
        {
            if (id == null) {
                return NotFound();
            } else {
                var park = await _context.Parks.FirstOrDefaultAsync(m => m.ParkCode == id);
                if (park == null) {
                    return NotFound();
                } else {
                    // Forecast - "daily" data block with 8 data points for 8 days of weather
                    Forecast forecast = await darkSky.GetForecast(park);
                    // Creates Weather objects for each day
                    park.DaysOfWeather = darkSky.GetWeatherForWeek(park, forecast);
                    return View(park);
                }
            }
        }
    }
}
