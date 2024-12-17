using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CacheClass.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CacheClass.Controllers
{
    public class AssessmentScoresController : Controller
    {
        private readonly Ml2Context _context;

        public AssessmentScoresController(Ml2Context context)
        {
            _context = context;
        }

        // GET: AssessmentScores/Index
        public async Task<IActionResult> Index()
        {
            var scores = await _context.Scores
                .Include(s => s.Assessment)
                .Include(s => s.Learner)
                .ToListAsync();
            return View(scores);
        }

        // GET: AssessmentScores/Details/5
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

        // GET: AssessmentScores/Create
        public IActionResult Create()
        {
            ViewData["AssessmentID"] = new SelectList(_context.Assessments, "AssessmentID", "Title");
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "FullName");
            return View();
        }

        // POST: AssessmentScores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LearnerID,AssessmentID,Value")] Score score)
        {
            if (ModelState.IsValid)
            {
                _context.Add(score);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssessmentID"] = new SelectList(_context.Assessments, "AssessmentID", "Title", score.AsseessmentID);
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "FullName", score.LearnerID);
            return View(score);
        }

        // GET: AssessmentScores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var score = await _context.Scores.FindAsync(id);
            if (score == null)
            {
                return NotFound();
            }
            ViewData["AssessmentID"] = new SelectList(_context.Assessments, "AssessmentID", "Title", score.AsseessmentID);
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "FullName", score.LearnerID);
            return View(score);
        }

        // POST: AssessmentScores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScoreId,LearnerID,AssessmentID,Value")] Score score)
        {
            if (id != score.ScoreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(score);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScoreExists(score.ScoreId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssessmentID"] = new SelectList(_context.Assessments, "AssessmentID", "Title", score.AsseessmentID);
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "FullName", score.LearnerID);
            return View(score);
        }

        private bool ScoreExists(int id)
        {
            return _context.Scores.Any(e => e.ScoreId == id);
        }
    }
}