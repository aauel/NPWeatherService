using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NPWeatherService.Data;
using NPWeatherService.Models;

namespace NPWeatherService.Controllers
{
    public class SurveysController : Controller
    {
        private readonly NPDbContext _context;

        public SurveysController(NPDbContext context)
        {
            _context = context;
        }

        // GET: Surveys
        // Displays each park where survey count > 0, in descending order of survey count
        // Tying parks are listed in alphabetical order.
        public async Task<IActionResult> Index()
        {
            var parks = from p in _context.Parks.Include(p => p.Surveys) select p;
            parks = parks.OrderBy(p => p.ParkName).OrderByDescending(p => p.Surveys.Count);
            return View(await parks.ToListAsync());
        }


        // GET: Surveys/Create
        public IActionResult Create()
        {
            ViewData["ParkCode"] = new SelectList(_context.Parks, "ParkCode", "ParkName");
            return View();
        }

        // POST: Surveys/Create
        // Save new survey results to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParkCode,EmailAddress,State,ActivityLevel")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(survey);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParkCode"] = new SelectList(_context.Parks, "ParkCode", "ParkName", survey.ParkCode);
            return View(survey);
        }


        private bool SurveyExists(int id)
        {
            return _context.Surveys.Any(e => e.Id == id);
        }
    }
}
