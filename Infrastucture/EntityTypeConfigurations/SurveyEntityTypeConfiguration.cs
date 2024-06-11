namespace SurveyService.Infrastructure.EntityTypeConfigurations;

public class SurveyEntityTypeConfiguration : IEntityTypeConfiguration<Survey>
{
    public void Configure(EntityTypeBuilder<Survey> builder)
    {
        builder
            .Property(x => x.Id)
            .IsRequired();

        builder
            .Property(x => x.Name)
            .IsRequired();

        builder
            .Property(x => x.Description);

        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.QuestionList)
            .WithOne(x => x.Survey)
            .HasForeignKey(x => x.SurveyId);

        builder
            .HasMany(x => x.InterviewList)
            .WithOne(X => X.Survey)
            .HasForeignKey(x => x.SurveyId);
    }
}
