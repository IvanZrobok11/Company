using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DataBase;
using Infrastructure.Models;

namespace Infrastructure.Repositories
{
    public class CompanyRepository
    {
        public CompanyRepository(DataBaseContext context)
        {
            _dbContext = context;
        }

        private readonly DataBaseContext _dbContext;
        public async Task DeleteCustomers(Customer customer)
        {

        }

        public async Task ChangeName(string name)
        {

        }

        public async Task CreateDepartment(Department department)
        {

        }
    }
}
