using BloodNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodNetwork.Infrastructure.Data.Configurations;

public class DonorProfileConfiguration : IEntityTypeConfiguration<DonorProfile>
{
    public void Configure(EntityTypeBuilder<DonorProfile> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.BloodGroup).HasConversion<string>().HasMaxLength(10);
        builder.Property(d => d.Gender).HasMaxLength(20);
        builder.Property(d => d.Area).HasMaxLength(200);
        builder.Property(d => d.AvailabilityStatus).HasConversion<string>().HasMaxLength(20);
        builder.Property(d => d.VerificationStatus).HasConversion<string>().HasMaxLength(20);

        builder.HasOne(d => d.User)
            .WithOne(u => u.DonorProfile)
            .HasForeignKey<DonorProfile>(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.District)
            .WithMany()
            .HasForeignKey(d => d.DistrictId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Upazila)
            .WithMany()
            .HasForeignKey(d => d.UpazilaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(d => d.BloodGroup);
        builder.HasIndex(d => d.DistrictId);
        builder.HasIndex(d => d.UpazilaId);
        builder.HasIndex(d => d.AvailabilityStatus);
        builder.HasIndex(d => d.VerificationStatus);
        builder.HasIndex(d => d.LastDonationDate);
    }
}
