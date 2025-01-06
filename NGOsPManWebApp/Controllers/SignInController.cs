using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGOsPManWebApp.Data;
using NGOsPManWebApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NGOsPManWebApp.Controllers
{
    public class SignInController : Controller
    {
        private readonly WebDbContext _context;

        // Injecting WebDbContext to interact with the database
        public SignInController(WebDbContext context)
        {
            _context = context;
        }

        // GET: SignIn
        public IActionResult Index()
        {
            return View();
        }

        // POST: SignIn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(SignIn signIn)
        {
            if (ModelState.IsValid)
            {

                // Check if the user exists in the database

                var user = await _context.tbl_SignUp
                    .Where(u => u.UserName == signIn.UserName && u.Password == signIn.Password)
                    .FirstOrDefaultAsync();

                if (User != null)
                {
                    TempData["Username"] = signIn.UserName; // Store in TempData                  
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }

            // If invalid, return the view with error messages
            return View(signIn);
        }
    }
}
