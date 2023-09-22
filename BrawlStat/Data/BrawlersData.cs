using BrawlStat.PlayerData;
using System.Text.Json.Serialization;

namespace BrawlStat.Data
{
    public class BrawlersData
    {
        [JsonPropertyName("items")]
        public List<Brawler>? Brawlers { get; set; }
        public int? GadgetsCount
        {
            get
            {
                if (Brawlers == null) return 0;
                return Brawlers.Sum(brawler => brawler.Gadgets?.Count);
            }
        }
        public int? StarPowersCount
        {
            get
            {
                if (Brawlers == null) return 0;
                return Brawlers.Sum(brawler => brawler.StarPowers?.Count);
            }
        }
    }
}
