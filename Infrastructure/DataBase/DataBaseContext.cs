using Infrastructure.DataBase.Configuration;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataBase
{
    public class DataBaseContext : DbContext
    {
        public const string DbName = "MyCompany";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Database.EnsureCreated();
            optionsBuilder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database={DbName};Trusted_Connection=True;");
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Project> Projects { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());

        }
    }
}
