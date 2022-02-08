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
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade); ;
        }
    }
}
