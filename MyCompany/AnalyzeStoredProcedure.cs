using Infrastructure.DataBase;
using Infrastructure.Enums;
using Infrastructure.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Threading.Tasks;

namespace MyCompany
{
    public class AnalyzeStoredProcedure
    {
        private readonly Customer _customer = new Customer
        {
            Id = 20,
            CompanyId = "00:00:5e:00:53:af"
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

        #region
        public async Task AddCustomer(DataBaseContext db)
        {
            var paramId = new SqlParameter($"@id", $"{_customer.Id}");
            var paramCompanyId = new SqlParameter($"@companyId", $"{_customer.CompanyId}");
            await db.Database.ExecuteSqlRawAsync("AddCustomer @name, @companyId", paramId, paramCompanyId);
        }

        public async Task ChangeName(DataBaseContext db)
        {
            SqlParameter param = new SqlParameter("@name", "Microsoft2 ");
            await db.Database.ExecuteSqlRawAsync("ChangeName @name", param);
        }

        public async Task CreateDepartment(DataBaseContext db)
        {
            var paramId = new SqlParameter($"@id", $"{_department.DNumber}");
            var paramCompanyId = new SqlParameter($"@companyId", $"{_department.CompanyId}");
            await db.Database.ExecuteSqlRawAsync("CreateDepartment @name, @companyId", paramId, paramCompanyId);
        }

        public async Task RemoveCustomer(DataBaseContext db)
        {
            var param = new SqlParameter("@id", _customer.Id);
            await db.Database.ExecuteSqlRawAsync("RemoveCustomer @id", param);
        }

        public async Task RemoveDepartment(DataBaseContext db)
        {
            var paramDNumber = new SqlParameter("@name", _department.DNumber);
            var paramAddress = new SqlParameter("@address", _department.Address);
            await db.Database.ExecuteSqlRawAsync("RemoveDepartment @dNumber, @address", paramDNumber, paramAddress);
        }

        public async Task UpdateDepartment(DataBaseContext db)
        {
            var paramDNumber = new SqlParameter("@name", _department.DNumber);
            var paramAddress = new SqlParameter("@address", _department.Address);
            await db.Database.ExecuteSqlRawAsync("UpdateDepartment @dNumber, @address", paramDNumber, paramAddress);
        }

        public async Task GetAllDepartment(DataBaseContext db)
        {
            var allDep = db.Departments.FromSqlRaw("GetAllDepartment");
        }
        #endregion
        public async Task HireEmployee(DataBaseContext db)
        {
            var paramDateOfBirth = new SqlParameter("@DateOfBirth", _employee.DateOfBirth);
            var paramEmail = new SqlParameter("@Email", _employee.Email);
            var paramPassportSerialNumber = new SqlParameter("@PassportSerialNumber", _employee.PassportSerialNumber);
            var paramFirstName = new SqlParameter("@FirstName", _employee.FirstName);
            var paramLastName = new SqlParameter("@LastName", _employee.LastName);
            var paramDepartmentNumber = new SqlParameter("@DepartmentNumber", _employee.DepartmentNumber);
            var paramSex = new SqlParameter("@Sex", _employee.Sex);
            var paramDepartmentAddress = new SqlParameter("@DepartmentAddress", _employee.DepartmentAddress);
            await db.Database.ExecuteSqlRawAsync("AddEmployeeToProject @DateOfBirth, @Email, @PassportSerialNumber, " +
                                                 "@FirstName, @LastName, @DepartmentNumber, @Sex, @DepartmentAddress",
                paramDateOfBirth, paramEmail, paramPassportSerialNumber,
                paramFirstName, paramLastName, paramDepartmentNumber,
                paramSex, paramDepartmentAddress);
        }

        public async Task DismissEmployee(DataBaseContext db)
        {
            var paramDateOfBirth = new SqlParameter("@DateOfBirth", _employee.DateOfBirth);
            var paramEmail = new SqlParameter("@Email", _employee.Email);
            var paramPassportSerialNumber = new SqlParameter("@PassportSerialNumber", _employee.PassportSerialNumber);
            await db.Database.ExecuteSqlRawAsync("DismissEmployee @DateOfBirth, @Email, @PassportSerialNumber, ",
                paramDateOfBirth, paramEmail, paramPassportSerialNumber);
        }

        public async Task FindEmployee(DataBaseContext db)
        {
            var paramPassportSerialNumber = new SqlParameter("@PassportSerialNumber", _employee.PassportSerialNumber);
            db.Employees.FromSqlRaw("FindEmployee @PassportSerialNumber",
                 paramPassportSerialNumber);
        }
        public async Task CountEmployees(DataBaseContext db)
        {
            var parameter = new SqlParameter
            {
                ParameterName = "@quantity",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output,
            };
            db.Employees.FromSqlRaw("CountEmployees @quantity OUT", parameter);
        }
        public async Task FindCurrentProject(DataBaseContext db)
        {
            var paramPassportSerialNumber = new SqlParameter("@PassportSerialNumber", _employee.PassportSerialNumber);
            var result = db.Employees.FromSqlRaw("FindCurrentProject @PassportSerialNumber",
                 paramPassportSerialNumber);
        }
    }
}
