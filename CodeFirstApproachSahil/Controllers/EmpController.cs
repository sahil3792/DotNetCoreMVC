using CodeFirstApproachSahil.Data;
using CodeFirstApproachSahil.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApproachSahil.Controllers
{
    public class EmpController : Controller
    {
        public readonly ApplicationDbContext db;

        public EmpController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var obj=db.emps.ToList();
            return View(obj);
        }

        public IActionResult AddEmp()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult AddEmp(Emp e)
        {
            db.emps.Add(e);
            db.SaveChanges();
            TempData["Msg"] = "Emp Added Successfully";
            return RedirectToAction("Index");
        }
    }
}
