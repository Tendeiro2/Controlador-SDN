using System.Text.Json.Serialization;

namespace LTI_Mikrotik
{
    public class LoginInterface
    {
        [JsonPropertyName("default-name")]
        public string DefaultName { get; set; } = string.Empty;

        [JsonPropertyName("mac-address")]
        public string MacAddress { get; set; } = string.Empty;

        [JsonPropertyName("running")]
        public string Running { get; set; } = string.Empty;
    }
}
