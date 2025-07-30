namespace BAS.Application.Common.Errors
{
    /// <summary>
    /// Error types.
    /// </summary>
    public enum ErrorType
    {
        None,
        Null,
        MultipleStatus,
        Failure,
        Unexpected,
        Validation,
        Conflict,
        NotFound,
        Unauthorized,
        Forbidden,
    }
}
