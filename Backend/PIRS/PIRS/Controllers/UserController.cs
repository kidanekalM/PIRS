using Microsoft.AspNetCore.Mvc;

namespace PIRS.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
