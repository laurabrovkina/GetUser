using System.Drawing;
using GetUser.Api.Exceptions;
using Microsoft.EntityFrameworkCore;
using TickerQ.Dashboard.DependencyInjection;
using TickerQ.DependencyInjection;
using TickerQ.EntityFrameworkCore.DependencyInjection;
using TickerQ.Utilities;
using TickerQ.Utilities.Interfaces.Managers;
using TickerQ.Utilities.Models.Ticker;
using User.Api.Scheduler;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyDbContext>(optionsBuilder =>
    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=scheduling;Username=postgres;Password=changeme"));

builder.Services.AddTickerQ(options =>
{
    options.SetExceptionHandler<GlobalExceptionHandler>();
    options.AddOperationalStore<MyDbContext>(efCoreOptionBuilder =>
    {
        efCoreOptionBuilder.UseModelCustomizerForMigrations();
        efCoreOptionBuilder.CancelMissedTickersOnApplicationRestart();
    });
    options.AddDashboard(basePath: "/tickerq");
    options.AddDashboardBasicAuth();
});
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseTickerQ();

app.MapPost("/schedule", async (Point point, ICronTickerManager<CronTicker> tickerManager) =>
{
    await tickerManager.AddAsync(new CronTicker
    {
        Function = "CronJobWithObject",
        Description = "Cron job with an object",
        Expression = "*/1 * * * *",
        Request = TickerHelper.CreateTickerRequest(point),
        Retries = 3,
        RetryIntervals = [ 1,2,3 ]
    });
});
app.UseExceptionHandler();

app.Run();