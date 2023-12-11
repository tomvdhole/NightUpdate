using Quartz;

namespace NightUpdate.Features.GetInfoAndUpdateDatabase;
public class BackgroundJob : IJob
{
    private readonly ILogger<BackgroundJob> _logger;
    private readonly NightUpdateContext _nightUpdateContext;
    public BackgroundJob(ILogger<BackgroundJob> logger, NightUpdateContext nightUpdateContext)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _nightUpdateContext = nightUpdateContext ?? throw new ArgumentNullException(nameof(nightUpdateContext));
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var test = new Test($"Test info {Guid.NewGuid()}");

        _logger.LogInformation($"Saving to database {test.Message}");

        //_nightUpdateContext.Add(test);
        //await _nightUpdateContext.SaveChangesAsync();
        await Task.CompletedTask;
    }
}

