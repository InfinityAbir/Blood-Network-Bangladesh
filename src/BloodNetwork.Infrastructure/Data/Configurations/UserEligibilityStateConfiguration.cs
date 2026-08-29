using BloodNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodNetwork.Infrastructure.Data.Configurations;

public class UserEligibilityStateConfiguration : IEntityTypeConfiguration<UserEligibilityState>
{
    public void Configure(EntityTypeBuilder<UserEligibilityState> builder)
    {
        builder.HasKey(s => s.Id);
        builder.HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(s => s.UserId).IsUnique();

        builder.Property(s => s.AnswersJson).HasColumnType("jsonb").IsRequired();
        builder.Property(s => s.ResultJson).HasColumnType("jsonb").IsRequired();
    }
}
