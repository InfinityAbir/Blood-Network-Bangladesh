using BloodNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodNetwork.Infrastructure.Data.Configurations;

public class DonationRecordConfiguration : IEntityTypeConfiguration<DonationRecord>
{
    public void Configure(EntityTypeBuilder<DonationRecord> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.DonationLocation).HasMaxLength(300);
        builder.Property(d => d.Notes).HasMaxLength(1000);

        builder.HasOne(d => d.Donor)
            .WithMany(u => u.DonationRecords)
            .HasForeignKey(d => d.DonorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.BloodRequest)
            .WithMany()
            .HasForeignKey(d => d.BloodRequestId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
