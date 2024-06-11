
namespace SurveyService.Infrastructure.EntityTypeConfigurations;

public class ResultEntityTypeConfiguration : IEntityTypeConfiguration<Result>
{
    public void Configure(EntityTypeBuilder<Result> builder)
    {
        builder
            .Property(x => x.Id)
            .IsRequired();

        builder
            .Property(x => x.InterviewId)
            .IsRequired();

        builder
            .Property(x => x.QuestionId)
            .IsRequired();

        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Interview)
            .WithMany(x => x.ResultList)
            .HasForeignKey(x => x.InterviewId);

        builder
            .HasOne(x => x.Question)
            .WithMany(x => x.ResultList)
            .HasForeignKey(x => x.QuestionId);

        builder
            .HasMany(x => x.AnswerList)
            .WithMany(x => x.ResultList);
    }
}
