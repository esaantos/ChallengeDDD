using Challenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Globalization;

namespace Challenge.Infrastructure.Persistence.Configurations;

public class AssociateConfigurations : IEntityTypeConfiguration<Associate>
{
    public void Configure(EntityTypeBuilder<Associate> builder)
    {
        builder
            .HasKey(a => a.Id);
        builder
            .Property(a => a.Id)
            .UseIdentityColumn();

        builder
            .Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder
            .Property(a => a.Cpf)
            .IsRequired()
            .HasMaxLength(11)
            .IsFixedLength();

        builder
            .HasIndex(a => a.Cpf)
            .IsUnique();

        builder
            .HasMany(a => a.Companies)
            .WithMany(c => c.Associates)
            .UsingEntity(j => j.ToTable("AssociateCompany"));
        
    }
}
