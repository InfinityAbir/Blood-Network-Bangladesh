using BloodNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodNetwork.Infrastructure.Data.Configurations;

public class UpazilaConfiguration : IEntityTypeConfiguration<Upazila>
{
    public void Configure(EntityTypeBuilder<Upazila> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Name).HasMaxLength(100).IsRequired();
        builder.Property(u => u.NameBn).HasMaxLength(100).IsRequired();

        builder.HasOne(u => u.District)
            .WithMany(d => d.Upazilas)
            .HasForeignKey(u => u.DistrictId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
