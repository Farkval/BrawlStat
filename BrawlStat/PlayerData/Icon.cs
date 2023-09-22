using System.Text.Json.Serialization;

namespace BrawlStat.PlayerData
{
    public class Icon
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
