using Microsoft.EntityFrameworkCore;

namespace SurveyService.Infrastructure;

public class SurveyDbContext(DbContextOptions<SurveyDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SurveyDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}