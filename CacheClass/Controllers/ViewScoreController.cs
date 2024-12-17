using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CacheClass.Models;
using System.Threading.Tasks;
using System.Linq;

namespace CacheClass.Controllers
{
    public class ViewScoreController : Controller
    {
        private readonly Ml2Context _context;

        public ViewScoreController(Ml2Context context)
        {
            _context = context;
        }

        // GET: ViewScore/Index
        public async Task<IActionResult> Index()
        {
            var scores = await _context.Scores
                .Include(s => s.Assessment)
                .Include(s => s.Learner)
                .ToListAsync();
            return View(scores);
        }

        // GET: ViewScore/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var score = await _context.Scores
                .Include(s => s.Assessment)
                .Include(s => s.Learner)
                .FirstOrDefaultAsync(m => m.ScoreId == id);

            if (score == null)
            {
                return NotFound();
            }

            return View(score);
        }

        // GET: ViewScore/ScoreBreakdown/5
        public async Task<IActionResult> ScoreBreakdown(int? learnerId)
        {
            if (learnerId == null)
            {
                return NotFound();
            }

            var scores = await _context.Scores
                .Include(s => s.Assessment)
                .Where(s => s.LearnerID == learnerId)
                .ToListAsync();

            if (scores == null || !scores.Any())
            {
                return NotFound();
            }

            return View(scores);
        }

        // GET: ViewScore/HighestScore/5
        public async Task<IActionResult> HighestScore(int? courseId)
        {
            if (courseId == null)
            {
                return NotFound();
            }

            var highestScoreAssessment = await _context.Assessments
                .Include(a => a.Module)
                .Where(a => a.Module.CourseId == courseId)
                .OrderByDescending(a => a.Scores.Max(s => s.Value))
                .FirstOrDefaultAsync();

            if (highestScoreAssessment == null)
            {
                return NotFound();
            }

            return View(highestScoreAssessment);
        }
    }
}