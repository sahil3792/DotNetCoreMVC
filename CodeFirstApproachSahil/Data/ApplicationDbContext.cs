using CodeFirstApproachSahil.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproachSahil.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options ): base(options) 
        {
            
        }

        public DbSet< Emp > emps { get; set; }

    }
}
