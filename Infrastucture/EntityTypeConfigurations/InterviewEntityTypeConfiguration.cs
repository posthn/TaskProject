
namespace SurveyService.Infrastructure.EntityTypeConfigurations;

public class InterviewEntityTypeConfiguration : IEntityTypeConfiguration<Interview>
{
    public void Configure(EntityTypeBuilder<Interview> builder)
    {
        builder
            .Property(x => x.Id)
            .IsRequired();

        builder
            .Property(x => x.IntervieweeName)
            .IsRequired();

        builder
            .Property(x => x.CreatedAt)
            .IsRequired();

        builder
            .Property(x => x.SurveyId)
            .IsRequired();

        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Survey)
            .WithMany(x => x.InterviewList)
            .HasForeignKey(x => x.SurveyId);

        builder
            .HasMany(x => x.ResultList)
            .WithOne(x => x.Interview)
            .HasForeignKey(x => x.InterviewId);
    }
}
