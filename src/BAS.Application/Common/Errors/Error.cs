using Microsoft.AspNetCore.Http;

namespace BAS.Application.Common.Errors
{
    public class Error(string code, string message) : IEquatable<Error>
{
    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "The specified result value is null.");

    public string Code { get; } = code;
    public string Message { get; } = message;

    public static Error Combine(params Error[] errors)
    {
        var combinedMessage = string.Join("; ", errors.Select(e => e.Message));
        return new Error("Multiple.Errors", combinedMessage);
    }

    public static implicit operator string(Error error) => error.Code;

    public static bool operator ==(Error? a, Error? b) => a?.Equals(b) ?? b is null;
    public static bool operator !=(Error? a, Error? b) => !Equals(a, b);

    public virtual bool Equals(Error? other) =>
        other is not null && Code == other.Code && Message == other.Message;

    public override bool Equals(object? obj) => obj is Error error && Equals(error);
    public override int GetHashCode() => HashCode.Combine(Code, Message);
    public override string ToString() => Code;
}
}
