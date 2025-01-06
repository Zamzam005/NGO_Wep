using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGOsPManWebApp.Data;
using NGOsPManWebApp.Models;

namespace NGOsPManWebApp.Controllers
{
    public class SignUpController : Controller
    {
        private readonly WebDbContext _context;

        public SignUpController(WebDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignUp signUp)
        {
            // Validate password match
            if (signUp.Password != signUp.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Password and confirm password are not the same.");
                return View(signUp);
            }

            // Check if the user already exists (example using email)
            var existingUser = await _context.tbl_SignUp
                                             .FirstOrDefaultAsync(u => u.Email == signUp.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "A user with this email already exists.");
                return View(signUp);
            }

            // Save the new user if the model state is valid
            if (ModelState.IsValid)
            {
                signUp.Password = HashPassword(signUp.Password);
                _context.tbl_SignUp.Add(signUp);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "SignIn");
            }

            // If any other validation fails, return to the view with the model
            return View(signUp);
        }

        private string HashPassword(string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }
    }
}
