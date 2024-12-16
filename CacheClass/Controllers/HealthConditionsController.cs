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
    public class HealthConditionsController : Controller
    {
        private readonly Ml2Context _context;

        public HealthConditionsController(Ml2Context context)
        {
            _context = context;
        }

        // GET: HealthConditions
        public async Task<IActionResult> Index()
        {
            var ml2Context = _context.HealthConditions.Include(h => h.PersonalizationProfile);
            return View(await ml2Context.ToListAsync());
        }

        // GET: HealthConditions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthCondition = await _context.HealthConditions
                .Include(h => h.PersonalizationProfile)
                .FirstOrDefaultAsync(m => m.LearnerID == id);
            if (healthCondition == null)
            {
                return NotFound();
            }

            return View(healthCondition);
        }

        // GET: HealthConditions/Create
        public IActionResult Create()
        {
            ViewData["LearnerID"] = new SelectList(_context.PersonalizationProfiles, "LearnerID", "LearnerID");
            return View();
        }

        // POST: HealthConditions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LearnerID,ProfileId,Condition")] HealthCondition healthCondition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(healthCondition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LearnerID"] = new SelectList(_context.PersonalizationProfiles, "LearnerID", "LearnerID", healthCondition.LearnerID);
            return View(healthCondition);
        }

        // GET: HealthConditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthCondition = await _context.HealthConditions.FindAsync(id);
            if (healthCondition == null)
            {
                return NotFound();
            }
            ViewData["LearnerID"] = new SelectList(_context.PersonalizationProfiles, "LearnerID", "LearnerID", healthCondition.LearnerID);
            return View(healthCondition);
        }

        // POST: HealthConditions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LearnerID,ProfileId,Condition")] HealthCondition healthCondition)
        {
            if (id != healthCondition.LearnerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(healthCondition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthConditionExists(healthCondition.LearnerID))
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
            ViewData["LearnerID"] = new SelectList(_context.PersonalizationProfiles, "LearnerID", "LearnerID", healthCondition.LearnerID);
            return View(healthCondition);
        }

        // GET: HealthConditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthCondition = await _context.HealthConditions
                .Include(h => h.PersonalizationProfile)
                .FirstOrDefaultAsync(m => m.LearnerID == id);
            if (healthCondition == null)
            {
                return NotFound();
            }

            return View(healthCondition);
        }

        // POST: HealthConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var healthCondition = await _context.HealthConditions.FindAsync(id);
            if (healthCondition != null)
            {
                _context.HealthConditions.Remove(healthCondition);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HealthConditionExists(int id)
        {
            return _context.HealthConditions.Any(e => e.LearnerID == id);
        }
    }
}
