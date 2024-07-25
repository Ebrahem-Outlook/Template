using Domain.Abstractions;

namespace Domain.Shared;

/// <summary>
/// Represents an error.
/// </summary>
public sealed class Error : ValueObject
{
    /// <summary>
    /// The empty error instance.
    /// </summary>
    public static readonly Error None = new(string.Empty, string.Empty);

    /// <summary>
    /// The null value error instance.
    /// </summary>
    public static readonly Error NullValue = new("Error.NullValue", "The specified result is null");

    /// <summary>
    /// The condition not met error instance.
    /// </summary>
    public static readonly Error ConditionNotMet = new("Error.ConditionNotMet", "The specified condition was not met.");

    /// <summary>
    /// Initialize a new instance of the <see cref="Error"/> class.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="message"></param>
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    /// <summary>
    /// Gets the error code.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Gets the error message.
    /// </summary>
    public string Message { get; }

    public static implicit operator string(Error error) => error.Code;

    /// <inheritdoc />
    protected override IEnumerable<object> GetAtomicValue()
    {
        yield return Code;
        yield return Message;
    }
}
