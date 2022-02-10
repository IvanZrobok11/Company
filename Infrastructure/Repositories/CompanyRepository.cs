using Infrastructure.DataBase;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public CompanyRepository(DataBaseContext context)
        {
            _dbContext = context;
       
        }
        private readonly DataBaseContext _dbContext;
        public async Task ChangeName(string name)
        {
            var myCompany = await _dbContext.Companies.FirstAsync();
            myCompany.CName = name;
            _dbContext.Companies.Update(myCompany);

            await _dbContext.SaveChangesAsync();
        }
        public async Task RemoveCustomerAsync(int customerId)
        {
            var customer = await _dbContext.Customers
                .FirstOrDefaultAsync(p => p.Id == customerId);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task AddCustomerAsync(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
        }
        public async Task CreateDepartment(Department department)
        {
            await _dbContext.Departments.AddAsync(department);
            await _dbContext.SaveChangesAsync();
        }
        public async Task RemoveDepartment(Department department)
        {
            _dbContext.Departments.Remove(department);
            await _dbContext.SaveChangesAsync();
        }
    }
}
