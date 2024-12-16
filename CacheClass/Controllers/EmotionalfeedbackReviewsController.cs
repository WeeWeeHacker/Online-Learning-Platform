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
    public class EmotionalfeedbackReviewsController : Controller
    {
        private readonly Ml2Context _context;

        public EmotionalfeedbackReviewsController(Ml2Context context)
        {
            _context = context;
        }

        // GET: EmotionalfeedbackReviews
        public async Task<IActionResult> Index()
        {
            var ml2Context = _context.EmotionalfeedbackReviews.Include(e => e.FeedbackNavigation).Include(e => e.Instructor);
            return View(await ml2Context.ToListAsync());
        }

        // GET: EmotionalfeedbackReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emotionalfeedbackReview = await _context.EmotionalfeedbackReviews
                .Include(e => e.FeedbackNavigation)
                .Include(e => e.Instructor)
                .FirstOrDefaultAsync(m => m.FeedbackId == id);
            if (emotionalfeedbackReview == null)
            {
                return NotFound();
            }

            return View(emotionalfeedbackReview);
        }

        // GET: EmotionalfeedbackReviews/Create
        public IActionResult Create()
        {
            ViewData["FeedbackId"] = new SelectList(_context.EmotionalFeedbacks, "FeedbackId", "FeedbackId");
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "InstructorId", "InstructorId");
            return View();
        }

        // POST: EmotionalfeedbackReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeedbackId,InstructorId,Feedback")] EmotionalfeedbackReview emotionalfeedbackReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emotionalfeedbackReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FeedbackId"] = new SelectList(_context.EmotionalFeedbacks, "FeedbackId", "FeedbackId", emotionalfeedbackReview.FeedbackId);
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "InstructorId", "InstructorId", emotionalfeedbackReview.InstructorId);
            return View(emotionalfeedbackReview);
        }

        // GET: EmotionalfeedbackReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emotionalfeedbackReview = await _context.EmotionalfeedbackReviews.FindAsync(id);
            if (emotionalfeedbackReview == null)
            {
                return NotFound();
            }
            ViewData["FeedbackId"] = new SelectList(_context.EmotionalFeedbacks, "FeedbackId", "FeedbackId", emotionalfeedbackReview.FeedbackId);
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "InstructorId", "InstructorId", emotionalfeedbackReview.InstructorId);
            return View(emotionalfeedbackReview);
        }

        // POST: EmotionalfeedbackReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeedbackId,InstructorId,Feedback")] EmotionalfeedbackReview emotionalfeedbackReview)
        {
            if (id != emotionalfeedbackReview.FeedbackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emotionalfeedbackReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmotionalfeedbackReviewExists(emotionalfeedbackReview.FeedbackId))
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
            ViewData["FeedbackId"] = new SelectList(_context.EmotionalFeedbacks, "FeedbackId", "FeedbackId", emotionalfeedbackReview.FeedbackId);
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "InstructorId", "InstructorId", emotionalfeedbackReview.InstructorId);
            return View(emotionalfeedbackReview);
        }

        // GET: EmotionalfeedbackReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emotionalfeedbackReview = await _context.EmotionalfeedbackReviews
                .Include(e => e.FeedbackNavigation)
                .Include(e => e.Instructor)
                .FirstOrDefaultAsync(m => m.FeedbackId == id);
            if (emotionalfeedbackReview == null)
            {
                return NotFound();
            }

            return View(emotionalfeedbackReview);
        }

        // POST: EmotionalfeedbackReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emotionalfeedbackReview = await _context.EmotionalfeedbackReviews.FindAsync(id);
            if (emotionalfeedbackReview != null)
            {
                _context.EmotionalfeedbackReviews.Remove(emotionalfeedbackReview);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmotionalfeedbackReviewExists(int id)
        {
            return _context.EmotionalfeedbackReviews.Any(e => e.FeedbackId == id);
        }
    }
}
