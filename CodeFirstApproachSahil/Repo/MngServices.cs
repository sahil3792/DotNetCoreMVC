using CodeFirstApproachSahil.Data;
using CodeFirstApproachSahil.Models;

namespace CodeFirstApproachSahil.Repo
{
    public class MngServices : MngRepo
    {
        private readonly ApplicationDbContext db;

        public MngServices(ApplicationDbContext db) 
        {
            this.db=db;
        }

        public void NewManager(Emp e)
        {
            db.emps.Add(e);
            db.SaveChanges();
        }

        public void DisplayManager(Emp e)
        {
            var obj = db.emps.ToList();

        }
    }
}
