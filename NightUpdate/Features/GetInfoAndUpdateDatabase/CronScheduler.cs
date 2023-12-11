using Quartz;

namespace NightUpdate.Features.GetInfoAndUpdateDatabase;
public class CronScheduler
{
    private readonly IServiceCollection _services;
    public CronScheduler(IServiceCollection services)
        => _services = services ?? throw new ArgumentNullException(nameof(services));

    public void Schedule<T>(CronExpression cronExpression)
        where T : IJob
    {
        _services.AddQuartz(q =>
        {
            var jobKey = new JobKey(typeof(T).Name);
            q.AddJob<T>(jobKey);

            q.AddTrigger(opts => opts
                    .ForJob(jobKey)
                    .WithIdentity($"{typeof(T).Name}-Trigger")
                    .WithCronSchedule(cronExpression.Value));
        });
        _services.AddQuartzHostedService();
    }
}

