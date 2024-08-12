using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApproachSahil.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Mail()
        {
            return View();
        }

        

    }
}
