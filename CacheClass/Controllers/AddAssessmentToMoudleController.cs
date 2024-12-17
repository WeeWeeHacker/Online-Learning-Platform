using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using CacheClass.Models;
using System.Threading.Tasks;
using System.Linq;

namespace CacheClass.Controllers
{
    public class AddAssessmentToMoudleController : Controller
    {
        private readonly Ml2Context _context;

        public AddAssessmentToMoudleController(Ml2Context context)
        {
            _context = context;
        }

        // GET: AddAssessmentToMoudle/Index
        public async Task<IActionResult> Index()
        {
            var assessments = await _context.Assessments
                .Include(a => a.Module)
                .ToListAsync();
            return View(assessments);
        }

        // GET: AddAssessmentToMoudle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments
                .Include(a => a.Module)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (assessment == null)
            {
                return NotFound();
            }

            return View(assessment);
        }

        // GET: AddAssessmentToMoudle/Create
        public IActionResult Create()
        {
            ViewData["ModuleID"] = new SelectList(_context.Modules, "ModuleID", "Name");
            return View();
        }

        // POST: AddAssessmentToMoudle/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,ModuleID")] Assessment assessment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assessment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModuleID"] = new SelectList(_context.Modules, "ModuleID", "Name", assessment.ModuleId);
            return View(assessment);
        }

        // GET: AddAssessmentToMoudle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments.FindAsync(id);
            if (assessment == null)
            {
                return NotFound();
            }
            ViewData["ModuleID"] = new SelectList(_context.Modules, "ModuleID", "Name", assessment.ModuleId);
            return View(assessment);
        }

        // POST: AddAssessmentToMoudle/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssessmentID,Title,Description,ModuleID")] Assessment assessment)
        {
            if (id != assessment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assessment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssessmentExists(assessment.Id))
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
            ViewData["ModuleID"] = new SelectList(_context.Modules, "ModuleID", "Name", assessment.ModuleId);
            return View(assessment);
        }

        // GET: AddAssessmentToMoudle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments
                .Include(a => a.Module)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (assessment == null)
            {
                return NotFound();
            }

            return View(assessment);
        }

        // POST: AddAssessmentToMoudle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assessment = await _context.Assessments.FindAsync(id);
            _context.Assessments.Remove(assessment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssessmentExists(int id)
        {
            return _context.Assessments.Any(e => e.Id == id);
        }
    }
}