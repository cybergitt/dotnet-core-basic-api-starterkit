using Microsoft.Extensions.Configuration;

namespace BAS.Application.Security.Authentication
{
    public class ApiKeyValidation : IApiKeyValidation
    {
        private readonly IConfiguration _configuration;

        public ApiKeyValidation(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool IsValidApiKey(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                return false;
            }
            var configuredApiKey = _configuration.GetValue<string>("ApiKey");
            if (string.IsNullOrEmpty(configuredApiKey) || apiKey != configuredApiKey)
            {
                return false;
            }
            return true;
        }
    }
}
