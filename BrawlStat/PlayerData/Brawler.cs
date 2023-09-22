using BrawlStat.Data;
using System.Text.Json.Serialization;

namespace BrawlStat.PlayerData
{
    public class Brawler
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("power")]
        public int Power { get; set; }
        [JsonPropertyName("rank")]
        public int Rank { get; set; }
        [JsonPropertyName("trophies")]
        public int Trophies { get; set; }
        [JsonPropertyName("highestTrophies")]
        public int HighestTrophies { get; set; }
        [JsonPropertyName("gears")]
        public List<Gear>? Gears { get; set; }
        [JsonPropertyName("starPowers")]
        public List<StarPower>? StarPowers { get; set; }
        [JsonPropertyName("gadgets")]
        public List<Gadget>? Gadgets { get; set; }
        public Bitmap? Image;
        public Rare Rare { get; set; }

        public int SeasonEndTrophies
        {
            get => Trophies switch
            {
                >= 501 and <= 524 => 500,
                >= 525 and <= 549 => 524,
                >= 550 and <= 574 => 549,
                >= 575 and <= 599 => 574,
                >= 600 and <= 624 => 599,
                >= 625 and <= 674 => 624,
                >= 675 and <= 724 => 674,
                >= 725 and <= 799 => 724,
                >= 800 and <= 899 => 799,
                >= 900 and <= 999 => 899,
                >= 1000 and <= 1099 => 999,
                >= 1100 and <= 1199 => 1099,
                >= 1200 and <= 1299 => 1199,
                >= 1300 and <= 1399 => 1249,
                >= 1400 and <= 1499 => 1349,
                >= 1500 => 1449,
                _ => Trophies
            };
        }
        public int SeasonEndBlings
        {
            get => Trophies switch
            {
                >= 501 and <= 524 => 1,
                >= 525 and <= 549 => 2,
                >= 550 and <= 574 => 3,
                >= 575 and <= 599 => 4,
                >= 600 and <= 624 => 5,
                >= 625 and <= 674 => 6,
                >= 675 and <= 724 => 7,
                >= 725 and <= 799 => 8,
                >= 800 and <= 899 => 9,
                >= 900 and <= 999 => 10,
                >= 1000 and <= 1099 => 11,
                >= 1100 and <= 1199 => 12,
                >= 1200 and <= 1299 => 13,
                >= 1300 and <= 1399 => 14,
                >= 1400 and <= 1499 => 15,
                >= 1500 => 16,
                _ => 0
            };
        }
        public (int, int) CurrentRankTrophiesRange
        {
            get
            {
                return Rank switch
                {
                    1 => (0, 10),
                    2 => (10, 20),
                    3 => (20, 30),
                    4 => (30, 40),
                    5 => (40, 60),
                    6 => (60, 80),
                    7 => (80, 100),
                    8 => (100, 120),
                    9 => (120, 140),
                    10 => (140, 160),
                    11 => (160, 180),
                    12 => (180, 220),
                    13 => (220, 260),
                    14 => (260, 300),
                    15 => (300, 340),
                    16 => (340, 380),
                    17 => (380, 420),
                    18 => (420, 460),
                    19 => (460, 500),
                    < 35 => ((Rank - 20) * 50 + 500, (Rank - 20) * 50 + 550),
                    _ => (1500, 1500)
                };
            }
        }
        public int TrophiesToANewRank
        {
            get
            {
                int trophiesToANewRank = CurrentRankTrophiesRange.Item2 - Trophies;
                return trophiesToANewRank > 0 ? trophiesToANewRank : 0;
            }
        }
        public Rare GetRare()
        {
            if (BrawlersRare.Starting.Contains(Id)) Rare = Rare.Starting;
            else if (BrawlersRare.Rare.Contains(Id)) Rare = Rare.Rare;
            else if (BrawlersRare.SuperRare.Contains(Id)) Rare = Rare.SuperRare;
            else if (BrawlersRare.Epic.Contains(Id)) Rare = Rare.Epic;
            else if (BrawlersRare.Mythic.Contains(Id)) Rare = Rare.Mythic;
            else if (BrawlersRare.Legendary.Contains(Id)) Rare = Rare.Legendary;
            else if (BrawlersRare.Chromatic.Contains(Id)) Rare = Rare.Chromatic;
            else Rare = Rare.None;
            return Rare;
        }
    }
    public enum Rare
    {
        None,
        Starting,
        Rare,
        SuperRare,
        Epic,
        Mythic,
        Legendary,
        Chromatic
    }
}
