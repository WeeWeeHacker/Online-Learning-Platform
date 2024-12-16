using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CacheClass.Models;


namespace CacheClass.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly Ml2Context _context;

        public InstructorsController(Ml2Context context)
        {
            _context = context;
        }

        // *** BEGIN REGISTRATION FUNCTIONALITY ***
        // GET: Instructors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instructors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstructorId,Name,LastestQualification,ExpertiseArea,Email,Password")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(instructor.Password))
                {
                    ModelState.AddModelError("Password", "Password cannot be null or empty.");
                    return View(instructor);
                }

                // instructor.Password = PasswordHelper.HashPassword(instructor.Password);
                _context.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instructor);
        }
        // *** END REGISTRATION FUNCTIONALITY ***

        // *** BEGIN LOGIN FUNCTIONALITY ***
        // GET: Instructors/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Instructors/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "Username and password are required.");
                return View();
            }

            var instructor = await _context.Instructors
                .FirstOrDefaultAsync(i => i.Username == username);

            if (instructor == null || !PasswordHelper.VerifyPassword(instructor.Password, password))
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View();
            }

            TempData["SuccessMessage"] = $"Welcome, {instructor.Name}!";
            return RedirectToAction(nameof(Profile), new { id = instructor.InstructorId });  // Redirect to instructor's profile
        }
        // *** END LOGIN FUNCTIONALITY ***

        // *** BEGIN PROFILE FUNCTIONALITY ***
        // GET: Instructors/Profile
        public async Task<IActionResult> Profile(int id)
        {
            var instructor = await _context.Instructors
                .FirstOrDefaultAsync(i => i.InstructorId == id);

            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

            public IActionResult Index()
        {
            return View();
        }
    }
        // *** END PROFILE FUNCTIONALITY ***
    }
