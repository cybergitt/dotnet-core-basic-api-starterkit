using BAS.Application.Common.Errors;

namespace BAS.Application.Common.Result
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T? Data { get; }
        public List<Error>? Errors { get; }
        public int? StatusCode { get; }

        private Result(bool isSuccess, T? data, List<Error>? errors, int? statusCode)
        {
            IsSuccess = isSuccess;
            Data = data;
            Errors = errors;
            StatusCode = statusCode;
        }

        public static Result<T> Success(T data) => new(true, data, null, null);
        public static Result<T> Failure(Error error, int statusCode = 400) => new(false, default, [error], statusCode);
        public static Result<T> Failure(Error[] errors, int statusCode = 400) => new(false, default, [.. errors], statusCode);
    }
}
