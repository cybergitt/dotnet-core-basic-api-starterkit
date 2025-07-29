using System.Text.Json;
using System.Text.Json.Serialization;

namespace BAS.Application.Common.Request
{
    public abstract class AdditionalRequest
    {
        [JsonExtensionData] // using System.Text.Json.Serialization;
        public IDictionary<string, JsonElement>? UnknownProperties { get; set; }
    }
}
