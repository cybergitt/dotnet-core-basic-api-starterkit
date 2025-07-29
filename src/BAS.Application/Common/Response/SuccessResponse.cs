namespace BAS.Application.Common.Response
{
    public class SuccessResponse<T>
    {
        public bool Success => true;
        public T Data { get; }
        public string TraceId { get; }

        public SuccessResponse(T data, string traceId)
        {
            Data = data;
            TraceId = traceId;
        }
    }
}
