using Microsoft.AspNetCore.Mvc;

namespace TopDownHeist.Controllers
{
    public class DebugController : Controller
    {
        public IActionResult RedirectToHome()
        {
            return RedirectToAction(string.Empty, "Home");
        }
    }
}
