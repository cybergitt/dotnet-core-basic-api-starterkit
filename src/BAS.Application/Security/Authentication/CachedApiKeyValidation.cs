using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace BAS.Application.Security.Authentication
{
    public class CachedApiKeyValidation : ICachedApiKeyValidation
    {
        private readonly IDistributedCache _cache;
        private const string CacheKeyPrefix = "ApiKeyValidation";
        private readonly ILogger<CachedApiKeyValidation> _logger;

        public CachedApiKeyValidation(IDistributedCache cache, ILogger<CachedApiKeyValidation> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public bool IsValidApiKey(string apiKey)
        {
            var cacheKey = $"{CacheKeyPrefix}:{apiKey}";
            var cachedApiKey = _cache.GetStringAsync(cacheKey);
            if (cachedApiKey != null)
            {
                _logger.LogInformation("API Key found in cache.");
                return true;
            }
            return false;
        }
    }
}
