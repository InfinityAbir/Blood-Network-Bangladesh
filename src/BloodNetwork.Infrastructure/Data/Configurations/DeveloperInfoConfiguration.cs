using BloodNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodNetwork.Infrastructure.Data.Configurations;

public class DeveloperInfoConfiguration : IEntityTypeConfiguration<DeveloperInfo>
{
    public void Configure(EntityTypeBuilder<DeveloperInfo> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name).HasMaxLength(100).IsRequired();
        builder.Property(d => d.Role).HasMaxLength(100).IsRequired();
        builder.Property(d => d.Email).HasMaxLength(200);
        builder.Property(d => d.Phone).HasMaxLength(30);
        builder.Property(d => d.LinkedInUrl).HasMaxLength(300);
        builder.Property(d => d.GithubUrl).HasMaxLength(300);

        builder.HasData(new DeveloperInfo
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "Abir Hasan",
            Role = "Developer",
            Email = "abirha3896@gmail.com",
            Phone = "01701554707",
            LinkedInUrl = "https://www.linkedin.com/in/infinityabirhasan/",
            GithubUrl = "https://github.com/InfinityAbir",
            CreatedAt = new DateTime(2026, 8, 29, 0, 0, 0, DateTimeKind.Utc),
        });
    }
}
