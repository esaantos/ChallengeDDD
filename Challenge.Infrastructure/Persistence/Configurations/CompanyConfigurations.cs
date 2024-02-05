using Challenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Infrastructure.Persistence.Configurations;

public class CompanyConfigurations : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder
            .HasKey(c => c.Id);
        builder
            .Property(c => c.Id)
            .UseIdentityColumn();

        builder
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder
            .Property(c => c.Cnpj)
            .IsRequired()
            .HasMaxLength(14)
            .IsFixedLength();

        builder
            .HasIndex(c => c.Cnpj)
            .IsUnique();

        builder
            .HasMany(c => c.Associates)
            .WithMany(a => a.Companies)
            .UsingEntity(j => j.ToTable("AssociateCompany"));
    }
}
