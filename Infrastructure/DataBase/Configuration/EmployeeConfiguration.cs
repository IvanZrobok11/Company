using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataBase.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(
                    nameof(Employee.INN),
                    nameof(Employee.PassportSerialNumber),
                    nameof(Employee.Id))
                .HasName("PK_Employee");

            builder.HasOne(p => p.CurrentProject)
                .WithMany(p => p.Employees);
        }
    }
}
