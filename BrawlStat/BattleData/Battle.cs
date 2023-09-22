using System.Text.Json.Serialization;

namespace BrawlStat.BattleData
{
    public class Battle
    {
        [JsonPropertyName("mode")]
        public string? Mode { get; set; }
        [JsonPropertyName("type")]
        public string? Type { get; set; }
        [JsonPropertyName("result")]
        public string? Result { get; set; }
        [JsonPropertyName("duration")]
        public int Duration { get; set; }
        [JsonPropertyName("trophyChange")]
        public int TrophyChange { get; set; }
        [JsonPropertyName("rank")]
        public int Rank { get; set; }
        [JsonPropertyName("starPlayer")]
        public Player? StarPlayer { get; set; }
        [JsonPropertyName("teams")]
        public List<List<Player>>? Teams { get; set; }
        public List<Player>? WinningTeams
        {
            get
            {
                if (Teams == null || Teams.Count != 2) return null;
                return Teams[0];
            }
        }
        public List<Player>? LosingTeams
        {
            get
            {
                if (Teams == null || Teams.Count != 2) return null;
                return Teams[1];
            }
        }
    }
    public struct BattleResult
    {
        public string Defeat = "defeat";
        //Дописать
        public BattleResult() { }
    }
}
