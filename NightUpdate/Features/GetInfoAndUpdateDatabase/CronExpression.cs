using NightUpdate.Utilities;

namespace NightUpdate.Features.GetInfoAndUpdateDatabase;
public class CronExpression
{
    private readonly string value;
    private CronExpression(string expression)
    {
        value = expression;
    }

    public string Value { get => value; }

    public static Result<CronExpression> Create(string cronExpression)
    {
        var isValid = Quartz.CronExpression.IsValidExpression(cronExpression);

        if (isValid)
            return new Result<CronExpression>(true, new CronExpression(cronExpression), null);
        else
            return new Result<CronExpression>(false, null, "Cron expression is not valid");
    }
}

