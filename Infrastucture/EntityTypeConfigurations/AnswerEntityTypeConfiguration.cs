
namespace SurveyService.Infrastructure.EntityTypeConfigurations;

public class AnswerEntityTypeConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder
            .Property(x => x.Id)
            .IsRequired();

        builder
            .Property(x => x.Text)
            .IsRequired();

        builder
            .Property(x => x.QuestionId)
            .IsRequired();

        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Question)
            .WithMany(x => x.AnswerList)
            .HasForeignKey(x => x.QuestionId);

        builder
            .HasMany(x => x.ResultList)
            .WithMany(x => x.AnswerList);
    }
}
