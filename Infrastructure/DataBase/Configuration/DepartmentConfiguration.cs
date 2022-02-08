using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataBase.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(nameof(Department.Address), nameof(Department.DNumber))
                .HasName("PK_Department");

            builder.Property(k => k.Address)
                .HasColumnName("address");

            builder.HasMany(k => k.Employees)
                .WithOne(k => k.Department)
                .HasForeignKey(nameof(Employee.DepartmentAddress), nameof(Employee.DepartmentNumber));
        }
    }
}
