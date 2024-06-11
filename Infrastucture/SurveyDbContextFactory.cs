namespace SurveyService.Infrastructure;

public class SurveyDbContextFactory(string connectionString)
{
    public SurveyDbContext Create()
    {
        var optionsBuilder = new DbContextOptionsBuilder<SurveyDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new SurveyDbContext(optionsBuilder.Options);
    }
}