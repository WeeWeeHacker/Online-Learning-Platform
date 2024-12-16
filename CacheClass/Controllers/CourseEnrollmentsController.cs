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
    public class CourseEnrollmentsController : Controller
    {
        private readonly Ml2Context _context;

        public CourseEnrollmentsController(Ml2Context context)
        {
            _context = context;
        }

        // GET: CourseEnrollments
        public async Task<IActionResult> Index()
        {
            var ml2Context = _context.CourseEnrollments.Include(c => c.Course).Include(c => c.Learner);
            return View(await ml2Context.ToListAsync());
        }

        // GET: CourseEnrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseEnrollment = await _context.CourseEnrollments
                .Include(c => c.Course)
                .Include(c => c.Learner)
                .FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (courseEnrollment == null)
            {
                return NotFound();
            }

            return View(courseEnrollment);
        }

        // GET: CourseEnrollments/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "LearnerID");
            return View();
        }

        // POST: CourseEnrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentId,CourseId,LearnerID,CompletionDate,EnrollmentDate,Status")] CourseEnrollment courseEnrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseEnrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", courseEnrollment.CourseId);
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "LearnerID", courseEnrollment.LearnerID);
            return View(courseEnrollment);
        }

        // GET: CourseEnrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseEnrollment = await _context.CourseEnrollments.FindAsync(id);
            if (courseEnrollment == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", courseEnrollment.CourseId);
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "LearnerID", courseEnrollment.LearnerID);
            return View(courseEnrollment);
        }

        // POST: CourseEnrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollmentId,CourseId,LearnerID,CompletionDate,EnrollmentDate,Status")] CourseEnrollment courseEnrollment)
        {
            if (id != courseEnrollment.EnrollmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseEnrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseEnrollmentExists(courseEnrollment.EnrollmentId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", courseEnrollment.CourseId);
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "LearnerID", courseEnrollment.LearnerID);
            return View(courseEnrollment);
        }

        // GET: CourseEnrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseEnrollment = await _context.CourseEnrollments
                .Include(c => c.Course)
                .Include(c => c.Learner)
                .FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (courseEnrollment == null)
            {
                return NotFound();
            }

            return View(courseEnrollment);
        }

        // POST: CourseEnrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseEnrollment = await _context.CourseEnrollments.FindAsync(id);
            if (courseEnrollment != null)
            {
                _context.CourseEnrollments.Remove(courseEnrollment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseEnrollmentExists(int id)
        {
            return _context.CourseEnrollments.Any(e => e.EnrollmentId == id);
        }
    }
}
