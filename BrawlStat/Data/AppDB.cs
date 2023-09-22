namespace BrawlStat.Data
{
    public static class AppDB
    {
        public static string MainDir { get; private set; }
        public static string BrawlersDir { get; private set; }
        public static string GadgetsDir { get; private set; }
        public static string StarPowersDir { get; private set; }
        public static string RanksDir { get; private set; }
        public static string PowerDir { get; private set; }
        public static string TrophyDir { get; private set; }
        public static string PlayersDir { get; private set; }
        public static string FormsData { get; private set; }

        static AppDB()
        {
            MainDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            BrawlersDir = Path.Combine(MainDir, "Brawlers");
            GadgetsDir = Path.Combine(MainDir, "Gadgets");
            StarPowersDir = Path.Combine(MainDir, "StarPowers");
            RanksDir = Path.Combine(MainDir, "Ranks");
            PowerDir = Path.Combine(MainDir, "Power");
            TrophyDir = Path.Combine(MainDir, "Trophy");
            PlayersDir = Path.Combine(MainDir, "Players");
            FormsData = Path.Combine(MainDir, "FormsData");
        }
        public static void SavePlayerJsonToFile(string tag, string json)
        {
            string path = Path.Combine(PlayersDir, tag);
            DirectoryInfo playerDir = new(path);
            if (!playerDir.Exists) Directory.CreateDirectory(path);

            bool createNewFileFlag = true;
            foreach (FileInfo file in playerDir.GetFiles())
            {
                if ((DateTime.Now - file.CreationTime).TotalMinutes < 30)
                {
                    createNewFileFlag = false;
                }
            }
            if (createNewFileFlag)
            {
                path = Path.Combine(path, $"{DateTime.Now:dd.MM.yyyy.HH.mm}.txt");
                File.WriteAllText(path, json);
            }
        }
        public static void SavePlayersNameAndTagForTagsComboBox(Dictionary<string, string> playersNamesAndTags)
        {
            string path = Path.Combine(PlayersDir, "PlayersTags.txt");
            if (!new FileInfo(path).Exists) File.Create(path).Close();

            using StreamWriter writer = new(path, false);
            foreach(KeyValuePair<string, string> kvp in playersNamesAndTags)
            {
                writer.WriteLine($"{kvp.Key}:{kvp.Value}");
            }
        }
        public static Dictionary<string, string> GetSavedPlayersNameAndTags()
        {
            Dictionary<string, string> result = new();

            string path = Path.Combine(PlayersDir, "PlayersTags.txt");
            if (!new FileInfo(path).Exists) return result;

            string[] data = File.ReadAllLines(path);
            foreach (string line in data)
            {
                string[] keyValue = line.Split(':');
                if (keyValue.Length == 2)
                {
                    result.Add(keyValue[0], keyValue[1]);
                }
            }
            return result;
        }
    }
}
