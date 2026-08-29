using BloodNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodNetwork.Infrastructure.Data.Configurations;

public class EligibilityQuestionConfiguration : IEntityTypeConfiguration<EligibilityQuestion>
{
    public void Configure(EntityTypeBuilder<EligibilityQuestion> builder)
    {
        builder.HasKey(q => q.Id);
        builder.Property(q => q.QuestionEn).HasMaxLength(500).IsRequired();
        builder.Property(q => q.QuestionBn).HasMaxLength(500).IsRequired();
        builder.Property(q => q.QuestionBanglish).HasMaxLength(500).IsRequired();
        builder.Property(q => q.QuestionType).HasMaxLength(20).IsRequired();
        builder.Property(q => q.Unit).HasMaxLength(20);
        builder.Property(q => q.PassMessageEn).HasMaxLength(500).IsRequired();
        builder.Property(q => q.PassMessageBn).HasMaxLength(500).IsRequired();
        builder.Property(q => q.FailMessageEn).HasMaxLength(500).IsRequired();
        builder.Property(q => q.FailMessageBn).HasMaxLength(500).IsRequired();

        builder.HasIndex(q => q.DisplayOrder);
    }
}
