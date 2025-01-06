using Microsoft.AspNetCore.Mvc;

namespace NGOsPManWebApp.Controllers
{
    public class AdverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
