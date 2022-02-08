using Infrastructure.Enums;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataBase.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id)
                .HasName("PK_Project");

            builder.HasOne(p => p.Customer)
                .WithMany(p => p.Projects)
                .HasForeignKey(k => k.CustomerId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            builder.HasMany(p => p.Employees)
                .WithOne(p => p.CurrentProject)
                .HasForeignKey(k => k.ProjectId)
                .OnDelete(deleteBehavior: DeleteBehavior.SetNull);

            builder.Property(p => p.State)
                .HasDefaultValue(ProjectState.Develop);
        }
    }
}
