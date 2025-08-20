using System.Drawing;
using TickerQ.Utilities.Base;
using TickerQ.Utilities.Models;

namespace User.Api.Scheduler;

public class MyJobs
{
    private readonly ILogger<MyJobs> _logger;

    public MyJobs(ILogger<MyJobs> logger)
    {
        _logger = logger;
    }

    [TickerFunction("CleanUpLogs")]
    public void CleanUpLogs()
    {
        _logger.LogInformation("Cleaning up logs");
    }
    
    // cron job expression sets it up to run every 1 min
    [TickerFunction("CleanUpLogsWithCron", "*/1 * * * *")]
    public void CleanUpLogsWithCron()
    {
        _logger.LogInformation("Cleaning up logs");
    }
    
    [TickerFunction("WithObject")]
    public void WithObject(TickerFunctionContext<Point> context)
    {
        _logger.LogInformation("Method called {Point}", context.Request);
    }
}