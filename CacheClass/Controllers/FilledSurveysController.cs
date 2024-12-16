using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CacheClass.Models;

namespace CacheClass.Controllers
{
    public class FilledSurveysController : Controller
    {
        private readonly Ml2Context _context;

        public FilledSurveysController(Ml2Context context)
        {
            _context = context;
        }

        // GET: FilledSurveys
        public async Task<IActionResult> Index()
        {
            var ml2Context = _context.FilledSurveys.Include(f => f.Learner).Include(f => f.SurveyQuestion);
            return View(await ml2Context.ToListAsync());
        }

        // GET: FilledSurveys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filledSurvey = await _context.FilledSurveys
                .Include(f => f.Learner)
                .Include(f => f.SurveyQuestion)
                .FirstOrDefaultAsync(m => m.SurveyId == id);
            if (filledSurvey == null)
            {
                return NotFound();
            }

            return View(filledSurvey);
        }

        // GET: FilledSurveys/Create
        public IActionResult Create()
        {
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "LearnerID");
            ViewData["SurveyId"] = new SelectList(_context.SurveyQuestions, "SurveyId", "Question");
            return View();
        }

        // POST: FilledSurveys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SurveyId,Question,LearnerID,Answer")] FilledSurvey filledSurvey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filledSurvey);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "LearnerID", filledSurvey.LearnerID);
            ViewData["SurveyId"] = new SelectList(_context.SurveyQuestions, "SurveyId", "Question", filledSurvey.SurveyId);
            return View(filledSurvey);
        }

        // GET: FilledSurveys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filledSurvey = await _context.FilledSurveys.FindAsync(id);
            if (filledSurvey == null)
            {
                return NotFound();
            }
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "LearnerID", filledSurvey.LearnerID);
            ViewData["SurveyId"] = new SelectList(_context.SurveyQuestions, "SurveyId", "Question", filledSurvey.SurveyId);
            return View(filledSurvey);
        }

        // POST: FilledSurveys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SurveyId,Question,LearnerID,Answer")] FilledSurvey filledSurvey)
        {
            if (id != filledSurvey.SurveyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filledSurvey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilledSurveyExists(filledSurvey.SurveyId))
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
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "LearnerID", filledSurvey.LearnerID);
            ViewData["SurveyId"] = new SelectList(_context.SurveyQuestions, "SurveyId", "Question", filledSurvey.SurveyId);
            return View(filledSurvey);
        }

        // GET: FilledSurveys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filledSurvey = await _context.FilledSurveys
                .Include(f => f.Learner)
                .Include(f => f.SurveyQuestion)
                .FirstOrDefaultAsync(m => m.SurveyId == id);
            if (filledSurvey == null)
            {
                return NotFound();
            }

            return View(filledSurvey);
        }

        // POST: FilledSurveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filledSurvey = await _context.FilledSurveys.FindAsync(id);
            if (filledSurvey != null)
            {
                _context.FilledSurveys.Remove(filledSurvey);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilledSurveyExists(int id)
        {
            return _context.FilledSurveys.Any(e => e.SurveyId == id);
        }
    }
}
