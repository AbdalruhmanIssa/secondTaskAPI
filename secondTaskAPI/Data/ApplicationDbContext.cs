using Microsoft.EntityFrameworkCore;
using secondTaskAPI.Models;

namespace secondTaskAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
      public  DbSet<Employee>Employees {  get; set; }
       public DbSet<Department>Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=ASP11;Trusted_Connection=True;TrustServerCertificate=True");

        }
    }
}
