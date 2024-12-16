using CacheClass.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CacheClass.Controllers
{
    public class AccountController : Controller
    {
        private readonly Ml2Context _context;

        
        
        // Constructor with Dependency Injection
        public AccountController(Ml2Context context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // GET: /Account/Index
        public IActionResult Index()
        {
            // Fetch the list of accounts from the database
            var accounts = _context.Accounts.ToList();  // Fetch from DbSet<Account>

            return View(accounts);
        }

        // GET: /Account/Details/5
        public IActionResult Details(int id)
        {
            // Fetch the account by ID from the database
            var account = _context.Accounts.FirstOrDefault(a => a.Id == id); // Fetch using Id

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: /Account/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Account/Create
        [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Account model)
{
    if (ModelState.IsValid)
    {
        if (model.Role == "Learner")
        {
            var learner = new Learner
            {
                Username = model.Username,
                // Email = model.Email,
                Password = model.Password,
                // Role = model.Role
            };
            _context.Learners.Add(learner);
        }
        else if (model.Role == "Instructor")
        {
            var instructor = new Instructor
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                PasswordHash = model.PasswordHash,
                Role = model.Role
            };
            _context.Instructors.Add(instructor);
        }
        else
        {
            _context.Accounts.Add(model);
        }

        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    return View(model);
}

        // GET: /Account/Edit/5
        public IActionResult Edit(int id)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: /Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Account model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Accounts.Any(a => a.Id == id))
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

            return View(model);
        }

        // GET: /Account/Delete/5
        public IActionResult Delete(int id)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: /Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        
        
    }
}
