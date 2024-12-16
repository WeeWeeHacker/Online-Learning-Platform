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
    public class ContentLibaraysController : Controller
    {
        private readonly Ml2Context _context;

        public ContentLibaraysController(Ml2Context context)
        {
            _context = context;
        }

        // GET: ContentLibarays
        public async Task<IActionResult> Index()
        {
            var ml2Context = _context.ContentLibarays.Include(c => c.Course).Include(c => c.Module);
            return View(await ml2Context.ToListAsync());
        }

        // GET: ContentLibarays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentLibaray = await _context.ContentLibarays
                .Include(c => c.Course)
                .Include(c => c.Module)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contentLibaray == null)
            {
                return NotFound();
            }

            return View(contentLibaray);
        }

        // GET: ContentLibarays/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId");
            return View();
        }

        // POST: ContentLibarays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModuleId,CourseId,Title,Description,Metadata,Type,ContentUrl")] ContentLibaray contentLibaray)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contentLibaray);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", contentLibaray.CourseId);
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId", contentLibaray.ModuleId);
            return View(contentLibaray);
        }

        // GET: ContentLibarays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentLibaray = await _context.ContentLibarays.FindAsync(id);
            if (contentLibaray == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", contentLibaray.CourseId);
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId", contentLibaray.ModuleId);
            return View(contentLibaray);
        }

        // POST: ContentLibarays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModuleId,CourseId,Title,Description,Metadata,Type,ContentUrl")] ContentLibaray contentLibaray)
        {
            if (id != contentLibaray.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contentLibaray);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentLibarayExists(contentLibaray.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", contentLibaray.CourseId);
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId", contentLibaray.ModuleId);
            return View(contentLibaray);
        }

        // GET: ContentLibarays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentLibaray = await _context.ContentLibarays
                .Include(c => c.Course)
                .Include(c => c.Module)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contentLibaray == null)
            {
                return NotFound();
            }

            return View(contentLibaray);
        }

        // POST: ContentLibarays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contentLibaray = await _context.ContentLibarays.FindAsync(id);
            if (contentLibaray != null)
            {
                _context.ContentLibarays.Remove(contentLibaray);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContentLibarayExists(int id)
        {
            return _context.ContentLibarays.Any(e => e.Id == id);
        }
    }
}
