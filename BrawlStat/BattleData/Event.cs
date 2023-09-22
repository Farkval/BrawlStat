using System.Text.Json.Serialization;

namespace BrawlStat.BattleData
{
    public class Event
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("mode")]
        public string? Mode { get; set; }
        [JsonPropertyName("map")]
        public string? MapName { get; set; }
    }
}
