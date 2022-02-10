using Infrastructure.DataBase;
using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public DepartmentRepository(DataBaseContext context)
        {
            _dbContext = context;
        }

        private readonly DataBaseContext _dbContext;

        public async Task CreateDepartment(Department department)
        {
            await _dbContext.Departments.AddAsync(department);
            await _dbContext.SaveChangesAsync();
        }
        public async Task CloseDepartment(Department department)
        {
            _dbContext.Departments.Remove(department);
            await _dbContext.SaveChangesAsync();
        }
        public async IAsyncEnumerable<Department> GetAll()
        {
            var all = _dbContext.Departments.AsAsyncEnumerable();
            await foreach (var department in all)
            {
                yield return department;
            }
        }
        public async Task Update(Department department)
        {
            _dbContext.Departments.Update(department);
            await _dbContext.SaveChangesAsync();
        }
    }
}
