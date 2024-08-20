using CodeFirstApproachSahil.Data;
using CodeFirstApproachSahil.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApproachSahil.Controllers
{
    public class AjaxController : Controller
    {
        private readonly ApplicationDbContext db;
        public AjaxController(ApplicationDbContext db) 
        {
            this.db = db;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmp(Emp e)
        {
            db.emps.Add(e);
            db.SaveChanges();
            return Json("");
        }

        public IActionResult GetEmp()
        {
            var data =db.emps.ToList();
            return Json(data);
        }

        public IActionResult DeleteEmp(int eid)
        {
            var data = db.emps.Find(eid);
            db.emps.Remove(data);
            db.SaveChanges();
            return Json("");
        }
        public IActionResult EditEmp(int eid)
        {
            var data = db.emps.Find(eid);
            return Json(data);
        }
        
    }
}
