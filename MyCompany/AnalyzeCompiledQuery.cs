using Infrastructure.DataBase;
using Infrastructure.Enums;
using Infrastructure.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace MyCompany
{
    internal class AnalyzeCompiledQuery
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
            var result
                = EF.CompileAsyncQuery((DataBaseContext context, Customer employee) =>
                    context.Add(employee));
            await result(db, _customer);
        }
        public async Task ChangeName(DataBaseContext db)
        {
            var myCompany = await db.Companies.FirstAsync();
            myCompany.CName = "Microsoft";
            var result
                = EF.CompileAsyncQuery((DataBaseContext context, string name) =>
                    context.Companies.Update(myCompany));
            await result(db, "Microsoft");
        }
        public async Task CreateDepartment(DataBaseContext db)
        {
            var result
                = EF.CompileAsyncQuery((DataBaseContext context, Department dep) =>
                    context.Departments.Add(dep));
            await result(db, _department);
        }
        public async Task RemoveCustomer(DataBaseContext db)
        {
            var result
                = EF.CompileAsyncQuery((DataBaseContext context, Customer employee) =>
                    context.Customers.Remove(employee));
            await result(db, _customer);
        }
        public async Task RemoveDepartment(DataBaseContext db)
        {
            var result
                = EF.CompileAsyncQuery((DataBaseContext context, Department dep) =>
                    context.Departments.Remove(dep));
            await result(db, _department);
        }
        public async Task UpdateDepartment(DataBaseContext db)
        {
            var result
                = EF.CompileAsyncQuery((DataBaseContext context, Department dep) =>
                    context.Departments.Update(dep));
            await result(db, _department);
        }
        public async Task GetAllDepartment(DataBaseContext db)
        {
            var allDepartment
                = EF.CompileAsyncQuery((DataBaseContext context) =>
                    context.Departments);
            var result = allDepartment(db);
        }
        public async Task HireEmployee(DataBaseContext db)
        {
            var result
                = EF.CompileAsyncQuery((DataBaseContext context, Employee employee) =>
                    context.Update(employee));
            await result(db, _employee);
        }
        public async Task DismissEmployee(DataBaseContext db)
        {
            var result
                = EF.CompileAsyncQuery((DataBaseContext context, Employee employee) =>
                    context.Employees.Remove(employee));
            await result(db, _employee);
        }

        public async Task FindEmployee(DataBaseContext db)
        {
            var result
                = EF.CompileAsyncQuery((DataBaseContext context, Employee e) =>
                    context.Employees.Find(e.PassportSerialNumber, e.Email, e.DateOfBirth));
            await result(db, _employee);
        }

        public async Task FindCurrentProject(DataBaseContext db)
        {
            var result
                = EF.CompileAsyncQuery((DataBaseContext context, Employee e) =>
                    context.Projects.FindAsync(e.PassportSerialNumber, e.Email, e.DateOfBirth));
            await result(db, _employee);
        }
        public async Task CountEmployees(DataBaseContext db)
        {
            var result
                = EF.CompileAsyncQuery((DataBaseContext context) =>
                    context.Employees.AsQueryable().Count());
            await result(db);
        }
    }
}
