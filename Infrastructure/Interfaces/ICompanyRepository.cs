using Infrastructure.Models;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ICompanyRepository
    {
        public Task ChangeName(string name);
        public Task RemoveCustomers(int customerId);
        public Task AddCustomers(Customer customer);
        public Task CreateDepartment(Department department);
        public Task RemoveDepartment(Department department);
    }
}
