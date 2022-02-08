using Infrastructure.DataBase;
using Infrastructure.Models;
using System.Linq;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository(DataBaseContext context)
        {
            _dbContext = context;
        }
        private readonly DataBaseContext _dbContext;

        public IQueryable<Customer> GetAll()
        {
            return _dbContext.Customers.AsQueryable();
        }
    }
}
