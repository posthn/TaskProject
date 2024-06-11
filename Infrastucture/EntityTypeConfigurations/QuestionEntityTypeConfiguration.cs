
namespace SurveyService.Infrastructure.EntityTypeConfigurations;

public class QuestionEntityTypeConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder
            .Property(x => x.Id)
            .IsRequired();

        builder
            .Property(x => x.Text)
            .IsRequired();

        builder
            .Property(x => x.SurveyId)
            .IsRequired();

        builder
            .HasKey(x => x.Id);

        builder
            .HasOne(x => x.Survey)
            .WithMany(x => x.QuestionList)
            .HasForeignKey(x => x.SurveyId);

        builder
            .HasMany(x => x.AnswerList)
            .WithOne(x => x.Question)
            .HasForeignKey(x => x.QuestionId);

        builder
            .HasMany(x => x.ResultList)
            .WithOne(x => x.Question)
            .HasForeignKey(x => x.QuestionId);
    }
}
