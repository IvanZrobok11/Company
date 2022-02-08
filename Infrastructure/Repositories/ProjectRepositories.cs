using Infrastructure.DataBase;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProjectRepositories
    {
        public ProjectRepositories(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        private readonly DataBaseContext _dbContext;
        public IEnumerable<Employee> GetAllEmployeeOfProject(Project project)
        {
            return _dbContext.Employees.Include(p => p.CurrentProject)
                .Where(e => e.CurrentProject.Id == project.Id);
        }
        public async Task Create(Project project)
        {
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Create(string name, Customer customer, double? cost)
        {
            await _dbContext.Projects.AddAsync(new Project
            {
                Customer = customer,
                ProjectName = name,
                Cost = cost
            });
            await _dbContext.SaveChangesAsync();
        }
        public async Task Create(string name, Customer customer, double? cost, params Employee[] employees)
        {
            await _dbContext.Projects.AddAsync(new Project
            {
                Customer = customer,
                ProjectName = name,
                Cost = cost,
                Employees = employees
            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task FindCurrentProject(Employee employee)
        {
            
        }
    }
} 
