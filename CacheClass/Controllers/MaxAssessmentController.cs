using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CacheClass.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CacheClass.Controllers
{
    public class MaxAssessmentController : Controller
    {
        private readonly Ml2Context _context;

        public MaxAssessmentController(Ml2Context context)
        {
            _context = context;
        }

        // GET: MaxAssessment/Index
        public async Task<IActionResult> Index()
        {
            var assessments = await _context.Assessments
                .Include(a => a.Module)
                .ToListAsync();
            return View(assessments);
        }

        // GET: MaxAssessment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments
                .Include(a => a.Module)
                .FirstOrDefaultAsync(m => m.ModuleId == id);

            if (assessment == null)
            {
                return NotFound();
            }

            return View(assessment);
        }

        // GET: MaxAssessment/Create
        public IActionResult Create()
        {
            ViewData["ModuleID"] = new SelectList(_context.Modules, "ModuleID", "Name");
            return View();
        }

        // POST: MaxAssessment/Create
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

        // GET: MaxAssessment/Edit/5
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
return View(assessment);
        }
    }
}