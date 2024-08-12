using CodeFirstApproachSahil.Data;
using CodeFirstApproachSahil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        public IActionResult DltEmp(int id)
        {
            var data = db.emps.Find(id);
            db.emps.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult EditEmp(int id)
        {
            var data = db.emps.Find(id);

            return View(data);
        }
        [HttpPost]
        public IActionResult EditEmp(Emp e)
        {
            db.emps.Update(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Index(string Ename)
        {
            if(Ename.IsNullOrEmpty())
            {
                var data = db.emps.ToList();
                return View(data);
            }
            else
            {
                var data = db.emps.Where(x => x.Name.Contains(Ename) || x.Email.Contains(Ename) || x.Salary.ToString().Contains(Ename)).ToList();
                return View(data);
            }
        }
        [HttpPost]
        public IActionResult DeleteMultiple(int[] checklist)
        {
            foreach (var item in checklist)
            {
                var data = db.emps.Find(item);
                db.emps.RemoveRange(data);
                db.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }
    }
}
