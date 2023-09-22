using System.Text.Json.Serialization;

namespace BrawlStat.PlayerData
{
    public class Club
    {
        [JsonPropertyName("tag")]
        public string? Tag { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
