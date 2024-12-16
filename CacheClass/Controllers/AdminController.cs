using CacheClass.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace CacheClass.Controllers
{
    public class AdminController : Controller
    {
        // Hardcoded list of admin usernames and passwords
        private static readonly List<(string Username, string Password)> Admins = new()
        {
            ("admin1", "Lana_05"),
            ("admin2", "Nour_05"),
            ("admin3", "Ahmed_05"),
            ("admin4", "Moaz_05"),
            ("admin5", "Youssef_05")
        };

        public AdminController()
        {
            // You can remove the _context dependency as it's no longer required
        }

        // Create action to handle adding admin with role
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Admin admin)
        {
            // In this case, we won't be adding admins to the database
            // You can remove database-related operations here
            return RedirectToAction(nameof(Index));
        }

        // Index action to display hardcoded admins
        public IActionResult Index()
        {
            // Return the hardcoded list of admins instead of querying the database
            var admins = Admins.Select(a => new Admin { Username = a.Username }).ToList();
            return View(admins);
        }

        // Login action - GET
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Login action - POST
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Check if the provided username and password match any admin in the hardcoded list
            var admin = Admins.FirstOrDefault(a => a.Username == username && a.Password == password);

            if (admin == default)
            {
                // If credentials are invalid, show an error message
                ViewBag.Error = "Invalid credentials. Please try again.";
                return View();
            }

            // If login is successful, redirect to the Index page (or dashboard, as needed)
            return RedirectToAction(nameof(Index));
        }
    }
}
