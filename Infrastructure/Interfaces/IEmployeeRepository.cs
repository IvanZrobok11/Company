using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<Employee> Find(params object[] keys);
        public IAsyncEnumerable<Employee> GetAll();
        public Task AddEmployeeToProject(Employee employee, Project project);
        public Task AddTeamToProject(Project project, params Employee[] employees);
        public Task RemoveEmployeeFromProject(Project project);
        public Task HireEmployee(Employee employee, Department department);
        public Task TransferEmployee(Employee employee, Department newDepartment);
        public Task DismissEmployee(Employee employee);
    }
}
