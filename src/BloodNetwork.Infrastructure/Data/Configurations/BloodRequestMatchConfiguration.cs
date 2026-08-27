using BloodNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodNetwork.Infrastructure.Data.Configurations;

public class BloodRequestMatchConfiguration : IEntityTypeConfiguration<BloodRequestMatch>
{
    public void Configure(EntityTypeBuilder<BloodRequestMatch> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.DonorResponse).HasConversion<string>().HasMaxLength(15);

        builder.HasOne(m => m.BloodRequest)
            .WithMany(r => r.Matches)
            .HasForeignKey(m => m.BloodRequestId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(m => m.Donor)
            .WithMany(u => u.DonorMatches)
            .HasForeignKey(m => m.DonorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(m => m.BloodRequestId);
        builder.HasIndex(m => m.DonorId);
        builder.HasIndex(m => new { m.BloodRequestId, m.DonorId }).IsUnique();
    }
}
