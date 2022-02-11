using Infrastructure.DataBase;
using Infrastructure.Enums;
using Infrastructure.Models;
using Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace MyCompany
{
    public class AnalyzeEfQuery
    {
        private readonly Customer _customer = new Customer
        {
            Id = 20,
            CompanyId = "00:00:5e:00:53:af",
            FullName = "google"
        };
        private readonly Department _department = new Department
        {
            DNumber = 20,
            CompanyId = "00:00:5e:00:53:af",
            Address = "NewYork",
        };
        private readonly Employee _employee = new Employee
        {
            DateOfBirth = new DateTime(1990, 12, 30),
            Email = "example@email.com",
            PassportSerialNumber = "someNumber",
            FirstName = "john",
            LastName = "smith",
            Sex = Sex.Man,
            DepartmentNumber = 20,
            DepartmentAddress = "NewYork"
        };
        private readonly Project _project = new Project
        {
            CustomerId = 20,
            ProjectName = "Some project name",
            Id = 20,
        };

        public async Task AddCustomer(DataBaseContext db)
        {
            var companyRepo = new CompanyRepository(db);
            await companyRepo.AddCustomerAsync(_customer);
        }
        public async Task ChangeName(DataBaseContext db)
        {
            var companyRepo = new CompanyRepository(db);
            await companyRepo.ChangeName("Microsoft");
        }
        public async Task CreateDepartment(DataBaseContext db)
        {
            var companyRepo = new CompanyRepository(db);
            await companyRepo.CreateDepartment(_department);
        }
        public async Task RemoveCustomer(DataBaseContext db)
        {
            var companyRepo = new CompanyRepository(db);
            await companyRepo.RemoveCustomerAsync(_customer.Id);
        }
        public async Task RemoveDepartment(DataBaseContext db)
        {
            var companyRepo = new CompanyRepository(db);
            await companyRepo.RemoveDepartment(_department);
        }
        public async Task UpdateDepartment(DataBaseContext db)
        {
            var departmentRepository = new DepartmentRepository(db);
            await departmentRepository.Update(_department);
        }
        public async Task GetAllDepartment(DataBaseContext db)
        {
            var departmentRepository = new DepartmentRepository(db);
            var all = departmentRepository.GetAll();
        }
        public async Task HireEmployee(DataBaseContext db)
        {
            var employeeRepository = new EmployeeRepository(db);
            await employeeRepository.HireEmployee(_employee, _department);
        }
        public async Task DismissEmployee(DataBaseContext db)
        {
            var employeeRepository = new EmployeeRepository(db);
            await employeeRepository.DismissEmployee(_employee);
        }
        public async Task FindEmployee(DataBaseContext db)
        {
            var employeeRepository = new EmployeeRepository(db);
            await employeeRepository.Find(_employee.Email, _employee.PassportSerialNumber, _employee.DateOfBirth);
        }
        public async Task FindCurrentProject(DataBaseContext db)
        {
            var employeeRepository = new EmployeeRepository(db);
            await employeeRepository.FindCurrentProject(_employee);
        }
        public async Task CountEmployees(DataBaseContext db)
        {
            var employeeRepository = new EmployeeRepository(db);
            await employeeRepository.CountEmployees();
        }
        #region 

        public class AnalysisProjectRepository
        {
            private Employee _employee = new Employee
            {

            };
            private Project _project = new Project
            {

            };
            public async Task CreateProject(DataBaseContext db)
            {
                var employeeRepository = new ProjectRepositories(db);
                await employeeRepository.Create(_project);
            }
            public async Task GetAllEmployeeOfProject(DataBaseContext db)
            {
                var employeeRepository = new ProjectRepositories(db);
                var allEmployee = employeeRepository.GetAllEmployeeOfProject(_project);
            }
        }

        #endregion
    }
}
