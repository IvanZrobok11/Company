using Infrastructure.DataBase;
using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository(DataBaseContext context)
        {
            _dbContext = context;
        }

        private readonly DataBaseContext _dbContext;
        public async Task<Employee> Find(params object[] keys)
        {
            return await _dbContext.Employees.FindAsync(keys);
        }
        public IAsyncEnumerable<Employee> GetAll()
        {
            return _dbContext.Employees.AsAsyncEnumerable();
        }
        public async Task AddEmployeeToProject(Employee employee, Project project)
        {
            employee.CurrentProject = project;
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }
        public async Task AddTeamToProject(Project project, params Employee[] employees)
        {
            foreach (var employee in employees)
            {
                employee.CurrentProject = project;
            }
            await _dbContext.Employees.AddRangeAsync(employees);
            await _dbContext.SaveChangesAsync();
        }
        public async Task RemoveEmployeeFromProject(Project project)
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task HireEmployee(Employee employee, Department department)
        {
            employee.Department = department;
            await _dbContext.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task TransferEmployee(Employee employee, Department newDepartment)
        {
            employee.Department = newDepartment;
            _dbContext.Update(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DismissEmployee(Employee employee)
        {
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }
    }
}
