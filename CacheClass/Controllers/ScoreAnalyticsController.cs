using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CacheClass.Models;
using System.Threading.Tasks;
using System.Linq;

namespace CacheClass.Controllers
{
    public class ScoreAnalyticsController : Controller
    {
        private readonly Ml2Context _context;

        public ScoreAnalyticsController(Ml2Context context)
        {
            _context = context;
        }

        // GET: ScoreAnalytics/AverageScore/5
        public async Task<IActionResult> AverageScore(int? courseId)
        {
            if (courseId == null)
            {
                return NotFound();
            }

            var averageScore = await _context.Scores
                .Where(s => s.Assessment.Module.CourseId == courseId)
                .AverageAsync(s => s.Value);

            return View(averageScore);
        }

        // GET: ScoreAnalytics/TopPerformers/5
        public async Task<IActionResult> TopPerformers(int? courseId)
        {
            if (courseId == null)
            {
                return NotFound();
            }

            var topPerformers = await _context.Scores
                .Where(s => s.Assessment.Module.CourseId == courseId)
                .OrderByDescending(s => s.Value)
                .Take(10)
                .Include(s => s.Learner)
                .ToListAsync();

            return View(topPerformers);
        }

        // GET: ScoreAnalytics/ScoreDistribution/5
        public async Task<IActionResult> ScoreDistribution(int? courseId)
        {
            if (courseId == null)
            {
                return NotFound();
            }

            var scoreDistribution = await _context.Scores
                .Where(s => s.Assessment.Module.CourseId == courseId)
                .GroupBy(s => s.Value)
                .Select(g => new { Score = g.Key, Count = g.Count() })
                .ToListAsync();

            return View(scoreDistribution);
        }
    }
}