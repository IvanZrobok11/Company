using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DataBase;
using Infrastructure.Models;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository
    {
        public EmployeeRepository(DataBaseContext context)
        {
            _dbContext = context;
        }

        private readonly DataBaseContext _dbContext;
        public async Task AddEmployeeToProject(Project project)
        {

        }
        public async Task AddTeamToProject(params Project[] project)
        {

        }
        public async Task RemoveEmployeeFromProject(Project project)
        {

        }
    }
}
