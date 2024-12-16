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
    public class BadgesController : Controller
    {
        private readonly Ml2Context _context;

        public BadgesController(Ml2Context context)
        {
            _context = context;
        }

        // GET: Badges
        public async Task<IActionResult> Index()
        {
            return View(await _context.Badges.ToListAsync());
        }

        // GET: Badges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var badge = await _context.Badges
                .FirstOrDefaultAsync(m => m.BadgeId == id);
            if (badge == null)
            {
                return NotFound();
            }

            return View(badge);
        }

        // GET: Badges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Badges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BadgeId,Title,Description,Criteria,Points")] Badge badge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(badge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(badge);
        }

        // GET: Badges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var badge = await _context.Badges.FindAsync(id);
            if (badge == null)
            {
                return NotFound();
            }
            return View(badge);
        }

        // POST: Badges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BadgeId,Title,Description,Criteria,Points")] Badge badge)
        {
            if (id != badge.BadgeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(badge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BadgeExists(badge.BadgeId))
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
            return View(badge);
        }

        // GET: Badges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var badge = await _context.Badges
                .FirstOrDefaultAsync(m => m.BadgeId == id);
            if (badge == null)
            {
                return NotFound();
            }

            return View(badge);
        }

        // POST: Badges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var badge = await _context.Badges.FindAsync(id);
            if (badge != null)
            {
                _context.Badges.Remove(badge);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BadgeExists(int id)
        {
            return _context.Badges.Any(e => e.BadgeId == id);
        }
    }
}
