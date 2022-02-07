using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataBase.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(k => k.OUI);

            builder.Property(k => k.OUI)
                .HasColumnName("id");
            builder.Property(p => p.CName)
                .HasColumnName("company_name");

            builder.HasMany(k => k.Departments)
                .WithOne(k => k.Company);

            builder.HasMany(k => k.Customers)
                .WithOne(k => k.Company);
        }
    }
}
