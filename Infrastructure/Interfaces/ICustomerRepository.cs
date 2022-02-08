using Infrastructure.Models;
using System.Linq;

namespace Infrastructure.Interfaces
{
    public interface ICustomerRepository
    {
        public IQueryable<Customer> GetAll();
    }
}
