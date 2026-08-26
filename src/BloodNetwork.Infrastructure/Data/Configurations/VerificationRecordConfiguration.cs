using BloodNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodNetwork.Infrastructure.Data.Configurations;

public class VerificationRecordConfiguration : IEntityTypeConfiguration<VerificationRecord>
{
    public void Configure(EntityTypeBuilder<VerificationRecord> builder)
    {
        builder.HasKey(v => v.Id);
        builder.Property(v => v.Type).HasConversion<string>().HasMaxLength(15);
        builder.Property(v => v.Status).HasConversion<string>().HasMaxLength(15);
        builder.Property(v => v.Notes).HasMaxLength(1000);

        builder.HasOne(v => v.User)
            .WithMany()
            .HasForeignKey(v => v.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
