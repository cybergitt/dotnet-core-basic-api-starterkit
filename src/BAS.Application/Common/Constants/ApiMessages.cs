namespace BAS.Application.Common.Constants
{
    public static class ApiMessages
    {
        #region Successful Messages
        public const string Success = "Success.";
        public const string Created = "The request has been fulfilled, and a new resource is created.";
        public const string Accepted = "The request has been accepted for processing, but the processing has not been completed.";
        public const string NoContent = "The request has been successfully processed, but is not returning any content.";
        #endregion

        #region Redirection Messages
        public const string MovedPermanently = "The requested page has moved to a new URL.";
        #endregion

        #region Client Error Messages
        public const string BadRequest = "The request could not be understood by the server due to malformed syntax.";
        public const string Unauthorized = "The credentials are missing or invalid for the given request.";
        public const string Forbidden = "The request was a legal request, but the server is refusing to respond to it.";
        public const string NotFound = "The resource was not found.";
        public const string MethodNotAllowed = "Method not allowed.";
        public const string Conflict = "The request could not be completed because of a conflict in the request.";
        public const string Gone = "The requested page is no longer available.";
        public const string LengthRequired = "The content-length header was required, but not provided.";
        public const string PreconditionFailed = "The resource has been modified, retrieve the resource again and retry.";
        public const string RequestEntityTooLarge = "The server is refusing to process a request because the size of the request entity exceeds the server's limits.";
        public const string UnsupportedMediaType = "The server will not accept the request, because the media type is not supported.";
        public const string UnprocessableEntity = "The request was well-formed but was unable to be followed due to semantic errors.";
        public const string TooManyRequest = "Request rate limit exceeded, try again later.";
        #endregion

        #region Server Error Messages
        public const string Unexpected = "An unknown exception was thrown.";
        public const string BadGateway = "Bad gateway, The server encountered a temporary error and could not complete your request.";
        public const string Unavailable = "The service is temporarily unavailable for maintenance or is overloaded.";
        public const string GatewayTimeout = "The server acting as a gateway cannot get a response in time.";
        #endregion
    }
}
