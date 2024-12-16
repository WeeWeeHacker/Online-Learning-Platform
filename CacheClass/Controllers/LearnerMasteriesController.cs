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
    public class LearnerMasteriesController : Controller
    {
        private readonly Ml2Context _context;

        public LearnerMasteriesController(Ml2Context context)
        {
            _context = context;
        }

        // GET: LearnerMasteries
        public async Task<IActionResult> Index()
        {
            var ml2Context = _context.LearnerMasteries.Include(l => l.Learner).Include(l => l.Quest);
            return View(await ml2Context.ToListAsync());
        }

        // GET: LearnerMasteries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learnerMastery = await _context.LearnerMasteries
                .Include(l => l.Learner)
                .Include(l => l.Quest)
                .FirstOrDefaultAsync(m => m.LearnerID == id);
            if (learnerMastery == null)
            {
                return NotFound();
            }

            return View(learnerMastery);
        }

        // GET: LearnerMasteries/Create
        public IActionResult Create()
        {
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "LearnerID");
            ViewData["QuestId"] = new SelectList(_context.Quests, "QuestId", "QuestId");
            return View();
        }

        // POST: LearnerMasteries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LearnerID,QuestId,CompletionStatus")] LearnerMastery learnerMastery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learnerMastery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "LearnerID", learnerMastery.LearnerID);
            ViewData["QuestId"] = new SelectList(_context.Quests, "QuestId", "QuestId", learnerMastery.QuestId);
            return View(learnerMastery);
        }

        // GET: LearnerMasteries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learnerMastery = await _context.LearnerMasteries.FindAsync(id);
            if (learnerMastery == null)
            {
                return NotFound();
            }
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "LearnerID", learnerMastery.LearnerID);
            ViewData["QuestId"] = new SelectList(_context.Quests, "QuestId", "QuestId", learnerMastery.QuestId);
            return View(learnerMastery);
        }

        // POST: LearnerMasteries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LearnerID,QuestId,CompletionStatus")] LearnerMastery learnerMastery)
        {
            if (id != learnerMastery.LearnerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learnerMastery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearnerMasteryExists(learnerMastery.LearnerID))
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
            ViewData["LearnerID"] = new SelectList(_context.Learners, "LearnerID", "LearnerID", learnerMastery.LearnerID);
            ViewData["QuestId"] = new SelectList(_context.Quests, "QuestId", "QuestId", learnerMastery.QuestId);
            return View(learnerMastery);
        }

        // GET: LearnerMasteries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learnerMastery = await _context.LearnerMasteries
                .Include(l => l.Learner)
                .Include(l => l.Quest)
                .FirstOrDefaultAsync(m => m.LearnerID == id);
            if (learnerMastery == null)
            {
                return NotFound();
            }

            return View(learnerMastery);
        }

        // POST: LearnerMasteries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learnerMastery = await _context.LearnerMasteries.FindAsync(id);
            if (learnerMastery != null)
            {
                _context.LearnerMasteries.Remove(learnerMastery);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearnerMasteryExists(int id)
        {
            return _context.LearnerMasteries.Any(e => e.LearnerID == id);
        }
    }
}
