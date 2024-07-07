namespace ResultPattern;

public readonly record struct Error
{
    private Error(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description;
        Type = type;
    }
    public string Code { get; }
    public string Description { get; }
    public ErrorType Type { get; }
    
    public static Error Failure(
        string code = "General.Failure",
        string description = "A failure has occurred.") =>
        new(code, description, ErrorType.Failure);
};