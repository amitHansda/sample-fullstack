using CustomerDemo.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerDemo.Web.Data
{
    public class ApplicationDbContext: DbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Employee> Employees{get;set;}
        public DbSet<Department> Departments{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Employee>().ToTable("Employee","OrgStructure"); 
            modelBuilder.Entity<Department>().ToTable("Department","OrgStructure");
        }
    }
}
