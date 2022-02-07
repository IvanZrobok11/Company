using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataBase.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(nameof(Department.Id), nameof(Department.DNumber))
                .HasName("PK_Department");

            builder.Property(k => k.Location)
                .HasColumnName("location");


            builder.HasMany(k => k.Emploees)
                .WithOne(k => k.Department)
                .HasForeignKey(nameof(Employee.DepartmentId), nameof(Employee.DepartmentNumber));
        }
    }
}
