public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SurveyDbContext>
{
    public SurveyDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SurveyDbContext>();
        optionsBuilder.UseNpgsql(string.Empty);

        return new SurveyDbContext(optionsBuilder.Options);
    }
}