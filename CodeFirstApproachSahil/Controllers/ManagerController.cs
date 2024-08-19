using CodeFirstApproachSahil.Models;
using CodeFirstApproachSahil.Repo;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApproachSahil.Controllers
{
    public class ManagerController : Controller
    {

        private readonly MngRepo repo;
        public ManagerController(MngRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index(Emp emp)
        {
            repo.DisplayManager(emp);
            return View();
        }

        public IActionResult AddManager()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult AddManager(Emp emp)
        {
            repo.NewManager(emp);
            return RedirectToAction("Index");   
        }
    }
}
