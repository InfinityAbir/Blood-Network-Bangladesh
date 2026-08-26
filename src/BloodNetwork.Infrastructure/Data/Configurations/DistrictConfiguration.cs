using BloodNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodNetwork.Infrastructure.Data.Configurations;

public class DistrictConfiguration : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name).HasMaxLength(100).IsRequired();
        builder.Property(d => d.NameBn).HasMaxLength(100).IsRequired();

        builder.HasOne(d => d.Division)
            .WithMany(div => div.Districts)
            .HasForeignKey(d => d.DivisionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
