using System;
using System.IO;
using System.Threading.Tasks;
using Infrastructure.DataBase.Configuration;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.DataBase
{
    public class DataBaseContext : DbContext
    {
        public const string DbName = "MyCompany";
        public static string LogFile = $"C:\\Users\\VanyaPc\\source\\repos\\MyCompany\\Infrastructure\\Logs\\DbLog_{DateTime.Now:yy-MM-dd_HH-mm-ss}.txt";
        private readonly StreamWriter _logStream = new StreamWriter(LogFile, append: true);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Database.EnsureCreated();
            optionsBuilder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database={DbName};Trusted_Connection=True;");
            optionsBuilder.LogTo(_logStream.WriteLine)
                .EnableDetailedErrors(false)
                .EnableSensitiveDataLogging(false)
                .EnableServiceProviderCaching(false)
                .ConfigureWarnings(w => w.Ignore());

            optionsBuilder.UseLoggerFactory(new LoggerFactory());
        }

        public override void Dispose()
        {
            base.Dispose();
            _logStream.Dispose();
        }
        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await _logStream.DisposeAsync();
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
