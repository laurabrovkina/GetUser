using Microsoft.EntityFrameworkCore;
using TickerQ.EntityFrameworkCore.Configurations;

namespace User.Api.Scheduler;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // apply manually
        builder.ApplyConfiguration(new TimeTickerConfigurations());
        builder.ApplyConfiguration(new CronTickerConfigurations());
        builder.ApplyConfiguration(new CronTickerOccurrenceConfigurations());
        
        //builder.ApplyConfigurationsFromAssembly(typeof(TimeTickerConfigurations).Assembly);
    }
}