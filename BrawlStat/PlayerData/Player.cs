using System.Text.Json.Serialization;

namespace BrawlStat.PlayerData
{
    public class Player
    {
        [JsonPropertyName("tag")]
        public string? Tag { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("nameColor")]
        public string? NameColor { get; set; }
        [JsonPropertyName("icon")]
        public Icon? Icon { get; set; }
        [JsonPropertyName("trophies")]
        public int Trophies { get; set; }
        [JsonPropertyName("highestTrophies")]
        public int HighestTrophies { get; set; }
        [JsonPropertyName("highestPowerPlayPoints")]
        public int HighestPowerPlayPoints { get; set; }
        [JsonPropertyName("expLevel")]
        public int ExpLevel { get; set; }
        [JsonPropertyName("expPoints")]
        public int ExpPoints { get; set; }
        [JsonPropertyName("isQualifiedFromChampionshipChallenge")]
        public bool IsQualifiedFromChampionshipChallenge { get; set; }
        [JsonPropertyName("3vs3Victories")]
        public int TeamVictories { get; set; }
        [JsonPropertyName("soloVictories")]
        public int SoloVictories { get; set; }
        [JsonPropertyName("duoVictories")]
        public int DuoVictories { get; set; }
        [JsonPropertyName("bestRoboRumbleTime")]
        public int BestRoboRumbleTime { get; set; }
        [JsonPropertyName("bestTimeAsBigBrawler")]
        public int BestTimeAsBigBrawler { get; set; }
        [JsonPropertyName("club")]
        public Club? Club { get; set; }
        [JsonPropertyName("brawlers")]
        public List<Brawler>? Brawlers { get; set; }
        public Sorting Sorting;

        public int SeasonEndTrophies
        {
            get
            {
                if (Brawlers == null) return 0;
                if (Sorting != Sorting.ByTrophiesDescending) SortBrawlersByTrophiesDescending();
                return Brawlers.Skip(20).Sum(brawler => brawler.Trophies) + Brawlers.Take(20).Sum(brawler => brawler.SeasonEndTrophies);
            }
        }
        public int SeasonEndBlings
        {
            get
            {
                if (Brawlers == null) return 0;
                if (Sorting != Sorting.ByTrophiesDescending) SortBrawlersByTrophiesDescending();
                return Brawlers.Take(20).Sum(brawler => brawler.SeasonEndBlings);
            }
        }
        public int PotentiallyHighestTrophies
        {
            get
            {
                if (Brawlers == null) return 0;
                return Brawlers.Sum(brawler => brawler.HighestTrophies);
            }
        }
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
        public int? GearsCount
        {
            get
            {
                if (Brawlers == null) return 0;
                return Brawlers.Sum(brawler => brawler.Gears?.Count);
            }
        }
        public double BrawlersMediumLevel
        {
            get
            {
                if (Brawlers == null) return 0;
                return Math.Round((double)Brawlers.Sum(brawler => brawler.Power) / Brawlers.Count, 1);
            }
        }
        public void SortBrawlersByTrophiesDescending()
        {
            if (Brawlers == null) return;
            Brawlers = Brawlers.Select(brawler => brawler).OrderByDescending(brawler => brawler.Trophies).ToList();
            Sorting = Sorting.ByTrophiesDescending;
        }
        public void SortBrawlersByTrophies()
        {
            if (Brawlers == null) return;
            Brawlers = Brawlers.Select(brawler => brawler).OrderBy(brawler => brawler.Trophies).ToList();
            Sorting = Sorting.ByTrophies;
        }
        public void SortBrawlersByHighestTrophies()
        {
            if (Brawlers == null) return;
            Brawlers = Brawlers.Select(brawler => brawler).OrderByDescending(brawler => brawler.HighestTrophies).ToList();
            Sorting = Sorting.ByHighestTrophies;
        }
        public void SortBrawlersByPower()
        {
            if (Brawlers == null) return;
            Brawlers = Brawlers.Select(brawler => brawler).OrderByDescending(brawler => brawler.Power).ToList();
            Sorting = Sorting.ByPower;
        }
        public void SortBrawlersByTrophiesToANewRank()
        {
            if (Brawlers == null) return;
            Brawlers = Brawlers.Select(brawler => brawler).OrderBy(brawler => brawler.TrophiesToANewRank).ToList();
            Sorting = Sorting.ByTrophiesToANewRank;
        }
        public void SortBrawlersByBlings()
        {
            if (Brawlers == null) return;
            Brawlers = Brawlers.Select(brawler => brawler).OrderByDescending(brawler => brawler.Trophies).ToList();
            Sorting = Sorting.ByBlings;
        }
        public void SortBrawlersByLosingTrophies()
        {
            if (Brawlers == null) return;
            if (Sorting != Sorting.ByTrophiesDescending)
                Brawlers = Brawlers.Select(brawler => brawler).OrderByDescending(brawler => brawler.Trophies).ToList();
            List<Brawler> top20 = Brawlers.Take(20).ToList();
            top20 = top20.OrderBy(brawler => brawler.SeasonEndTrophies - brawler.Trophies).ToList();
            for (int i = 0; i < top20.Count; i++)
            {
                Brawlers[i] = top20[i];
            }
            Sorting = Sorting.ByLosingTrophies;
        }
    }
    public enum Sorting
    {
        Default,
        ByRare,
        ByTrophies,
        ByTrophiesDescending,
        ByHighestTrophies,
        ByPower,
        ByTrophiesToANewRank,
        ByLosingTrophies,
        ByBlings
    }
}
