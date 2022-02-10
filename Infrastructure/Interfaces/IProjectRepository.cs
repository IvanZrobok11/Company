using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IProjectRepository
    {
        public IEnumerable<Employee> GetAllEmployeeOfProject(Project project);
        public Task Create(Project project);
        public Task Create(string name, Customer customer, double? cost);
        public Task Create(string name, Customer customer, double? cost, params Employee[] employees);
    }
}
