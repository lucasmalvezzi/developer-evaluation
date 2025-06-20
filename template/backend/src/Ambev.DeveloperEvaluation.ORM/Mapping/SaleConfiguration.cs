using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedOnAdd();

        builder.Property(s => s.Branch).IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.IsCancelled).HasDefaultValue(false);

        builder.Property(s => s.SaleDate)
            .IsRequired();

        builder.HasOne(s => s.Customer).WithMany()
            .HasForeignKey(x => x.CustomerId);

        builder.HasMany(s => s.SaleItems).WithOne(si=> si.Sale)
            .HasForeignKey(si => si.SaleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Ignore(s => s.TotalAmount);
    }
}
