namespace BAS.Application.Security.Authentication
{
    public interface IApiKeyValidation
    {
        bool IsValidApiKey(string apiKey);
    }
}
