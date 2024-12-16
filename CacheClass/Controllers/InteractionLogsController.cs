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
    public class InteractionLogsController : Controller
    {
        private readonly Ml2Context _context;

        public InteractionLogsController(Ml2Context context)
        {
            _context = context;
        }

        // GET: InteractionLogs
        public async Task<IActionResult> Index()
        {
            var ml2Context = _context.InteractionLogs.Include(i => i.Activity).Include(i => i.Learner);
            return View(await ml2Context.ToListAsync());
        }

        // GET: InteractionLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interactionLog = await _context.InteractionLogs
                .Include(i => i.Activity)
                .Include(i => i.Learner)
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (interactionLog == null)
            {
                return NotFound();
            }

            return View(interactionLog);
        }

        // GET: InteractionLogs/Create
        public IActionResult Create()
        {
            ViewData["ActivityId"] = new SelectList(_context.LearningActivities, "ActivityId", "ActivityId");
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "LearnerID");
            return View();
        }

        // POST: InteractionLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogId,ActivityId,LearnerID,Duration,Timestamp,ActionType")] InteractionLog interactionLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interactionLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivityId"] = new SelectList(_context.LearningActivities, "ActivityId", "ActivityId", interactionLog.ActivityId);
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "LearnerID", interactionLog.LearnerID);
            return View(interactionLog);
        }

        // GET: InteractionLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interactionLog = await _context.InteractionLogs.FindAsync(id);
            if (interactionLog == null)
            {
                return NotFound();
            }
            ViewData["ActivityId"] = new SelectList(_context.LearningActivities, "ActivityId", "ActivityId", interactionLog.ActivityId);
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "LearnerID", interactionLog.LearnerID);
            return View(interactionLog);
        }

        // POST: InteractionLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LogId,ActivityId,LearnerID,Duration,Timestamp,ActionType")] InteractionLog interactionLog)
        {
            if (id != interactionLog.LogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interactionLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InteractionLogExists(interactionLog.LogId))
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
            ViewData["ActivityId"] = new SelectList(_context.LearningActivities, "ActivityId", "ActivityId", interactionLog.ActivityId);
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "LearnerID", interactionLog.LearnerID);
            return View(interactionLog);
        }

        // GET: InteractionLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interactionLog = await _context.InteractionLogs
                .Include(i => i.Activity)
                .Include(i => i.Learner)
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (interactionLog == null)
            {
                return NotFound();
            }

            return View(interactionLog);
        }

        // POST: InteractionLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var interactionLog = await _context.InteractionLogs.FindAsync(id);
            if (interactionLog != null)
            {
                _context.InteractionLogs.Remove(interactionLog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InteractionLogExists(int id)
        {
            return _context.InteractionLogs.Any(e => e.LogId == id);
        }
    }
}
