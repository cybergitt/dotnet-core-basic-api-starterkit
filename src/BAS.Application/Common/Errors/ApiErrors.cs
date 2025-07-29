using BAS.Application.Common.Constants;

namespace BAS.Application.Common.Errors
{
    public static class ApiErrors
    {
        public static readonly Error Unavailable = new(
                code: "unavailable",
                message: ApiMessages.Unavailable
            );

        public static readonly Error GatewayTimeout = new(
                code: "gateway_timeout",
                message: ApiMessages.GatewayTimeout
            );

        public static readonly Error BadGateway = new(
                code: "bad_gateway",
                message: ApiMessages.BadGateway
            );

        public static readonly Error Unexpected = new(
                code: "internal_server_error",
                message: ApiMessages.Unexpected
            );

        public static readonly Error TooManyRequest = new(
                code: "rate_limit_exceeded",
                message: ApiMessages.TooManyRequest
            );

        public static readonly Error UnprocessableEntity = new(
                code: "unprocessable_entity",
                message: ApiMessages.UnprocessableEntity
            );

        public static readonly Error UnsupportedMediaType = new(
                code: "unsupported_media_type",
                message: ApiMessages.UnsupportedMediaType
            );

        public static readonly Error RequestEntityTooLarge = new(
                code: "request_entity_too_large",
                message: ApiMessages.RequestEntityTooLarge
            );

        public static readonly Error PreconditionFailed = new(
                code: "precondition_failed",
                message: ApiMessages.PreconditionFailed
            );

        public static readonly Error LengthRequired = new(
                code: "length_required",
                message: ApiMessages.LengthRequired
            );

        public static readonly Error Gone = new(
                code: "session_expired",
                message: ApiMessages.Gone
            );

        public static readonly Error Conflict = new(
                code: "conflict",
                message: ApiMessages.Conflict
            );

        public static readonly Error MethodNotAllowed = new(
                code: "method_not_allowed",
                message: ApiMessages.MethodNotAllowed
            );

        public static readonly Error NotFound = new(
                code: "not_found",
                message: ApiMessages.NotFound
            );

        public static readonly Error Forbidden = new(
                code: "forbidden",
                message: ApiMessages.Forbidden
            );

        public static readonly Error Unauthorized = new(
                code: "unauthorized",
                message: ApiMessages.Unauthorized
            );

        public static readonly Error BadRequest = new(
                code: "bad_request",
                message: ApiMessages.BadRequest
            );
    }
}
