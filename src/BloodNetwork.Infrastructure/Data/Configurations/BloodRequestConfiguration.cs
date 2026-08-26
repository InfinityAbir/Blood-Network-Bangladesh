using BloodNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodNetwork.Infrastructure.Data.Configurations;

public class BloodRequestConfiguration : IEntityTypeConfiguration<BloodRequest>
{
    public void Configure(EntityTypeBuilder<BloodRequest> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.BloodGroup).HasConversion<string>().HasMaxLength(10);
        builder.Property(r => r.HospitalName).HasMaxLength(300).IsRequired();
        builder.Property(r => r.HospitalAddress).HasMaxLength(500).IsRequired();
        builder.Property(r => r.Area).HasMaxLength(200);
        builder.Property(r => r.ContactPhone).HasMaxLength(20).IsRequired();
        builder.Property(r => r.PatientName).HasMaxLength(200);
        builder.Property(r => r.PatientRelation).HasMaxLength(100);
        builder.Property(r => r.AdditionalInformation).HasMaxLength(2000);
        builder.Property(r => r.Urgency).HasConversion<string>().HasMaxLength(10);
        builder.Property(r => r.Status).HasConversion<string>().HasMaxLength(20);

        builder.HasOne(r => r.Requester)
            .WithMany(u => u.BloodRequests)
            .HasForeignKey(r => r.RequesterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.District)
            .WithMany()
            .HasForeignKey(r => r.DistrictId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Upazila)
            .WithMany()
            .HasForeignKey(r => r.UpazilaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(r => r.Status);
        builder.HasIndex(r => r.Urgency);
        builder.HasIndex(r => r.BloodGroup);
        builder.HasIndex(r => r.DistrictId);
        builder.HasIndex(r => r.CreatedAt);
        builder.HasIndex(r => r.RequiredBy);
    }
}
