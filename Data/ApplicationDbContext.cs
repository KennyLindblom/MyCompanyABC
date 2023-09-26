using Microsoft.EntityFrameworkCore;
using MyCompanyABC.Models;

namespace MyCompanyABC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectList> ProjectLists { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
            .UseSqlServer("Server=REIDAR10PRO\\SQL2K19;Database=MCDb;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Employee[] employeeToSeed = new Employee[5];
            for (int i = 1; i <= 5; i++)
            {
                employeeToSeed[i - 1] = new Employee
                {
                    EmployeeId = i,
                    FirstMidName = $"Albert{i}",
                    LastName = $"Nosteen{i}"
                };
            }
            modelBuilder.Entity<Employee>().HasData(employeeToSeed);
        }
    }
}
