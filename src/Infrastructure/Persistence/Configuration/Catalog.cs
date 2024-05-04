using Finbuckle.MultiTenant.EntityFrameworkCore;
using TemplateProject.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;

namespace TemplateProject.Infrastructure.Persistence.Configuration;

public class BrandConfig : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.IsMultiTenant();

        builder
            .Property(b => b.Name)
                .HasMaxLength(256);
    }
}

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.IsMultiTenant();

        builder
            .Property(b => b.Name)
                .HasMaxLength(1024);

        builder
            .Property(p => p.ImagePath)
                .HasMaxLength(2048);
    }
}

public class UserRequestConfig : IEntityTypeConfiguration<UserRequest>
{
    public void Configure(EntityTypeBuilder<UserRequest> builder)
    {
        builder.IsMultiTenant();

        //builder
        //    .Property(b => b.Name)
        //        .HasMaxLength(256);
    }
}

public class InsuranceCoveragedConfig : IEntityTypeConfiguration<InsuranceCoverage>
{
    public void Configure(EntityTypeBuilder<InsuranceCoverage> builder)
    {
        builder.IsMultiTenant();

        builder.HasMany(e => e.UserRequest)
        .WithMany(e => e.InsuranceCoverage)
        .UsingEntity(
            nameof(UserRequestInsuranceCoverage),
            l => l.HasOne(typeof(UserRequest)).WithMany().HasForeignKey(nameof(UserRequestInsuranceCoverage.UserRequestId)).HasPrincipalKey(nameof(UserRequest.Id)),
            r => r.HasOne(typeof(InsuranceCoverage)).WithMany().HasForeignKey(nameof(UserRequestInsuranceCoverage.InsuranceCoverageId)).HasPrincipalKey(nameof(InsuranceCoverage.InsurenceCover)),
            j => j.HasKey(nameof(UserRequestInsuranceCoverage.UserRequestId), nameof(UserRequestInsuranceCoverage.InsuranceCoverageId)));
    }
}