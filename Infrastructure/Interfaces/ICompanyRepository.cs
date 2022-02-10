using Infrastructure.Models;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ICompanyRepository
    {
        public Task ChangeName(string name);
        public Task RemoveCustomerAsync(int customerId);
        public Task AddCustomerAsync(Customer customer);
        public Task CreateDepartment(Department department);
        public Task RemoveDepartment(Department department);
    }
}
