namespace BrawlStat.Data
{
    public static class BrawlersRare
    {
        public static HashSet<int> Starting;
        public static HashSet<int> Rare;
        public static HashSet<int> SuperRare;
        public static HashSet<int> Epic;
        public static HashSet<int> Mythic;
        public static HashSet<int> Legendary;
        public static HashSet<int> Chromatic;
        static BrawlersRare()
        {
            Starting = new()
            {
                16000000
            };
            Rare = new()
            {
                16000008, 16000001, 16000002, 16000003, 16000010, 16000006, 16000013, 16000024
            };
            SuperRare = new()
            {
                16000007, 16000009, 16000022, 16000027, 16000004, 16000018, 16000019, 16000025, 
                16000034, 16000061
            };
            Epic = new()
            {
                16000014, 16000030, 16000045, 16000015, 16000016, 16000020, 16000026, 16000029, 
                16000036, 16000043, 16000050, 16000048, 16000058, 16000069
            };
            Mythic = new()
            {
                16000011, 16000017, 16000021, 16000032, 16000031, 16000037, 16000042, 16000047, 
                16000064, 16000067, 16000071, 16000073
            };
            Legendary = new()
            {
                16000005, 16000012, 16000023, 16000028, 16000040, 16000052, 16000063
            };
            Chromatic = new()
            {
                16000035, 16000038, 16000039, 16000041, 16000044, 16000046, 16000049, 16000051,
                16000053, 16000054, 16000056, 16000057, 16000059, 16000060, 16000062, 16000065, 
                16000066, 16000068, 16000070, 16000072
            };
        }
        public static HashSet<int> BrawlersIdSortedByRare
        {
            get
            {
                HashSet<int> sortedIds = new();
                sortedIds.UnionWith(Starting);
                sortedIds.UnionWith(Rare);
                sortedIds.UnionWith(SuperRare);
                sortedIds.UnionWith(Epic);
                sortedIds.UnionWith(Mythic);
                sortedIds.UnionWith(Legendary);
                sortedIds.UnionWith(Chromatic);
                return sortedIds;
            }
        }

    }
}
