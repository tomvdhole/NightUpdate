using Microsoft.EntityFrameworkCore;
using NightUpdate.Features.GetInfoAndUpdateDatabase;
using Quartz;
using CronExpression = NightUpdate.Features.GetInfoAndUpdateDatabase.CronExpression;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDbContext<NightUpdateContext>(options
                       => options.UseSqlServer(hostContext.Configuration.GetConnectionString("NightUpdate")));

        var result = CronExpression.Create("*/5 * * * * ?");
        if (!result.IsOk)
        {
            Console.WriteLine(result.Error);
            return;
        }

        var scheduler = new CronScheduler(services);
        scheduler.Schedule<BackgroundJob>(result.Value!);
    })
    .Build();

await host.RunAsync();

//"data source=db-design-prod.tucrail.local,50112;Database=PLANLIB;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"