using CodeFirstApproachSahil.Data;
using CodeFirstApproachSahil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        [HttpPost]
        public IActionResult UpdateEmp(Emp e)
        {
            db.emps.Update(e);
            db.SaveChanges ();
            return Json("");
        }

        public IActionResult SearchEmpData(string sdata)
        {
            if(sdata.IsNullOrEmpty())
            {
                var data = db.emps.ToList();
                return Json(data);
            }
            else
            {
                var data = db.emps.Where(x => x.Name.Contains(sdata)|| x.Email.Contains(sdata) || x.Salary.ToString().Contains(sdata)).ToList();
                return Json (data); 
            }
        }
        
    }
}
