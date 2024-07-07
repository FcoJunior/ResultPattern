namespace ResultPattern;

public readonly record struct Result<TValue>
{
    private readonly TValue? _value = default;
    private readonly List<Error>? _errors = null;

    public Result()
    {
        throw new InvalidOperationException();
    }

    private Result(Error error)
    {
        _errors = [error];
    }
    
    private Result(List<Error> errors)
    {
        if (errors is null)
        {
            throw new ArgumentNullException(nameof(errors));
        }

        if (errors is null || errors.Count == 0)
        {
            throw new ArgumentException("Cannot create an Resut<TValue> from an empty collection of errors. Provide at least one error.", nameof(errors));
        }

        _errors = errors;
    }

    private Result(TValue value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        _value = value;
    }
    
    public bool IsError => _errors is not null;
    
    public TValue Value
    {
        get
        {
            if (IsError)
            {
                throw new InvalidOperationException("The Value property cannot be accessed when errors have been recorded. Check IsError before accessing Value.");
            }

            return _value;
        }
    }
    
    public static implicit operator Result<TValue>(TValue value)
    {
        return new Result<TValue>(value);
    }
    
    public static implicit operator Result<TValue>(Error error)
    {
        return new Result<TValue>(error);
    }
    
    public static implicit operator Result<TValue>(List<Error> errors)
    {
        return new Result<TValue>(errors);
    }
    
    public static Result<TValue> From(List<Error> errors)
    {
        return errors;
    }
}