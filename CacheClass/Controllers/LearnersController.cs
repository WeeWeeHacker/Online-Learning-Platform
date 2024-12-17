using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CacheClass.Models;

namespace CacheClass.Controllers
{
    public class LearnersController : Controller
    {
        private readonly Ml2Context _context;

        public LearnersController(Ml2Context context)
        {
            _context = context;
        }

        // *** BEGIN REGISTRATION FUNCTIONALITY ***
        // GET: Learners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Learners/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Gender,BirthDate,Country,CulturalBackground,Username,Password")] Learner learner)
        {
            if (ModelState.IsValid)
            {
                // Hash the password before saving
                learner.Password = PasswordHelper.HashPassword(learner.Password);
                _context.Add(learner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));  // Redirect to login after successful registration
            }
            return View(learner);
        }
        // *** END REGISTRATION FUNCTIONALITY ***

        // *** BEGIN LOGIN FUNCTIONALITY ***
        // GET: Learners/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Learners/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "Username and password are required.");
                return View();
            }

            var learner = await _context.Learners
                .FirstOrDefaultAsync(l => l.Username == username);

            if (learner == null || !PasswordHelper.VerifyPassword(learner.Password, password))
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View();
            }

            TempData["SuccessMessage"] = $"Welcome, {learner.FirstName}!";
            return RedirectToAction(nameof(Profile), new { id = learner.LearnerID });  // Redirect to learner's profile
        }
        // *** END LOGIN FUNCTIONALITY ***

        // *** BEGIN PROFILE FUNCTIONALITY ***
        // GET: Learners/Profile
        public async Task<IActionResult> Profile(int id)
        {
            var learner = await _context.Learners
                .FirstOrDefaultAsync(l => l.LearnerID == id);

            if (learner == null)
            {
                return NotFound();
            }

            return View(learner);
        }
        // *** END PROFILE FUNCTIONALITY ***

        public async Task<IActionResult> Index()
        {
            var learners = _context.Learners.ToList();
            if (learners == null)
            {
                learners = new List<Learner>();
            }
            return View(await _context.Learners.ToListAsync());
        }
        
        // GET: Learner/Index
        
    }
}