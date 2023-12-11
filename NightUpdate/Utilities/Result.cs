namespace NightUpdate.Utilities;
public class Result<T>
{
    public Result(bool isOk, T? value, string? error)
        => SetResult(isOk, value, error);

    public bool IsOk { get; private set; }
    public T? Value { get; private set; }
    public string? Error { get; private set; }

    private void SetResult(bool isOk, T? value, string? error)
    {
        if (isOk && ErrorIsEmpty(error) && value is not null)
        {
            Value = value;
            IsOk = true;
            Error = null;
        }
        else if(!isOk && !ErrorIsEmpty(error) && value is null) 
        {
            Value = default;
            IsOk = false;
            Error = error;
        }
        else
        {
            throw new InvalidOperationException(nameof(SetResult));
        }
    }

    private bool ErrorIsEmpty(string? error)
        => string.IsNullOrEmpty(error) || string.IsNullOrWhiteSpace(error);
}