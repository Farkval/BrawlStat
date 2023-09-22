using System.Text.Json.Serialization;

namespace BrawlStat.BattleData
{
    public class BattleLog
    {
        [JsonPropertyName("battleTime")]
        public string? BattleTime { get; set; }
        [JsonPropertyName("event")]
        public Event? Event { get; set; }
        [JsonPropertyName("battle")]
        public Battle? Battle { get; set; }
    }
}
