namespace BAS.Application.Security.Authentication
{
    public interface ICachedApiKeyValidation
    {
        bool IsValidApiKey(string apiKey);
    }
}
