using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IDepartmentRepository
    {
        public Task CreateDepartment(Department department);

        public Task CloseDepartment(Department department);

        public IAsyncEnumerable<Department> GetAll();

        public Task Update(Department department);
    }
}
