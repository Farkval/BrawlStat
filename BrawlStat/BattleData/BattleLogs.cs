using System.Text.Json.Serialization;

namespace BrawlStat.BattleData
{
    public class BattleLogs
    {
        [JsonPropertyName("items")]
        public List<BattleLog>? Logs { get; set; }
    }
}
