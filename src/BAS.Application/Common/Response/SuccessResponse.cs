namespace BAS.Application.Common.Response
{
    public class SuccessResponse<T>
    {
        public bool Success => true;
        public T Data { get; }

        public SuccessResponse(T data)
        {
            Data = data;
        }
    }
}
