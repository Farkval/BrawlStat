using BrawlStat.BattleData;
using BrawlStat.BrawlDataResources;
using BrawlStat.BrawlPainter;
using BrawlStat.Data;
using BrawlStat.Forms;
using System.Text.Json;
using Player = BrawlStat.PlayerData.Player;

namespace BrawlStat
{
    public partial class Form1 : Form
    {
        Player? player;
        BrawlersData? brawlersData;
        Dictionary<string, string> SavedPlayersNamesAndTags;
        SettingsForm settingsForm;
        BattleLogs? PlayerBattleLogs;
        public Form1()
        {
            InitializeComponent();
            SavedPlayersNamesAndTags = new();
            settingsForm = new(this);
            FormClosing += (s, e) =>
            {
                AppDB.SavePlayersNameAndTagForTagsComboBox(SavedPlayersNamesAndTags);
                BrawlAPI.Dispose();
            };
            Load += async (s, e) => await TryGetBrawlersData();
            sortingBrawlersComboBox.SelectedIndex = visualizationStyleComboBox.SelectedIndex = 0;
            tagTextBox.Text = "#";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SavedPlayersNamesAndTags = AppDB.GetSavedPlayersNameAndTags();
            AddTagsToTagsTextBox();

            string formsColorsDataFilePath = Path.Combine(AppDB.FormsData, $"ColorsData.txt");
            if (!new FileInfo(formsColorsDataFilePath).Exists) return;

            string[] colors = File.ReadAllLines(formsColorsDataFilePath);
            if (colors.Length != 2) return;

            for (int i = 0; i < colors.Length; i++)
            {
                string[] rgb = colors[i].Split(':');
                if (rgb.Length != 3) return;
                if (int.TryParse(rgb[0], out int r) && int.TryParse(rgb[1], out int g) && int.TryParse(rgb[2], out int b))
                {
                    if (i == 0) BackColor = Color.FromArgb(r, g, b);
                    else if (i == 1) settingsForm.BackColor = Color.FromArgb(r, g, b);
                }
            }
        }
        private void AddTagsToTagsTextBox()
        {
            tagsComboBox.Items.Clear();
            foreach (string key in SavedPlayersNamesAndTags.Keys)
            {
                tagsComboBox.Items.Add(key);
            }
            tagsComboBox.Items.Add("Очистить");
        }

        private async void FindPlayerBtn_Click(object sender, EventArgs e)
        {
            player = null;
            sortingBrawlersComboBox.SelectedIndex = 0;
            findPlayerBtn.Enabled = false;
            await BrawlAPI.TrySetToken();
            if (brawlersData == null) await TryGetBrawlersData();
            string json = await BrawlAPI.GetPlayerJson(tagTextBox.Text[1..]);
            if (json == string.Empty)
            {
                findPlayerBtn.Enabled = true;
                return;
            }
            AppDB.SavePlayerJsonToFile(tagTextBox.Text[1..], json);
            player = JsonSerializer.Deserialize<Player>(json);
            if (player == null || player.Brawlers == null)
            {
                findPlayerBtn.Enabled = true;
                return;
            }

            SetLabelsDefault();
            SetLabelsForPlayer();

            player.Brawlers.ForEach(b => b.Image = BrawlerPainter.CreateBrawlerImage(b));
            ShowBrawlers();

            if (!SavedPlayersNamesAndTags.ContainsKey(player.Name!))
            {
                SavedPlayersNamesAndTags.Add(player.Name!, player.Tag![1..]);
                AddTagsToTagsTextBox();
            }

            string battleLogJson = await BrawlAPI.GetPlayerBattlesLogJson(tagTextBox.Text[1..]);
            if (battleLogJson == string.Empty)
            {
                findPlayerBtn.Enabled = true;
                return;
            }
            PlayerBattleLogs = JsonSerializer.Deserialize<BattleLogs>(battleLogJson);
            ShowLastBattleTime(battleLogJson.Remove(battleLogJson.IndexOf("\"event") - 7).Remove(0, 25));

            findPlayerBtn.Enabled = true;
        }

        private void SetLabelsDefault()
        {
            nameLbl.Text = "Имя: ";
            trophiesLbl.Text = "Трофеев: ";
            highestTrophiesLbl.Text = "Максимум трофеев: ";
            potentiallyHighestTrophiesLbl.Text = "Потенциальный максимум\nтрофеев: ";
            lvlLbl.Text = "Уровень: ";
            soloVictoriesLbl.Text = "Одиночных побед: ";
            duoVictoriesLbl.Text = "Парных побед: ";
            teamVictoriesLbl.Text = "Побед 3на3: ";
            clubLbl.Text = "Клуб: ";
            brawlersCountLbl.Text = "Бравлеров открыто: ";
            gadgetsCountLbl.Text = "Гаджетов открыто: ";
            starPowersCountLbl.Text = "Звездных сил открыто: ";
            lastBattleTimeLbl.Text = "Последний раз в бою: \n";
            gearsCountLbl.Text = "Снаряжений открыто: ";
            seasonEndTrophiesLbl.Text = "Трофеев в конце\nсезона: ";
            blingsCountLbl.Text = "Получит блингов: ";
            brawlersMediumLvlLbl.Text = "Средний уровень\nбравлеров: ";
        }
        private void SetLabelsForPlayer()
        {
            nameLbl.Text = GetString(nameLbl.Text, $"{player!.Name}");
            trophiesLbl.Text = GetString(trophiesLbl.Text, $"{player.Trophies}");
            highestTrophiesLbl.Text = GetString(highestTrophiesLbl.Text, $"{player.HighestTrophies}");
            lvlLbl.Text = GetString(lvlLbl.Text, $"{player.ExpLevel}");
            soloVictoriesLbl.Text = GetString(soloVictoriesLbl.Text, $"{player.SoloVictories}");
            duoVictoriesLbl.Text = GetString(duoVictoriesLbl.Text, $"{player.DuoVictories}");
            teamVictoriesLbl.Text = GetString(teamVictoriesLbl.Text, $"{player.TeamVictories}");
            clubLbl.Text = GetString(clubLbl.Text, $"{player.Club?.Name}");
            brawlersCountLbl.Text = GetString(brawlersCountLbl.Text, $"{player.Brawlers?.Count}/{brawlersData!.Brawlers?.Count}");
            gadgetsCountLbl.Text = GetString(gadgetsCountLbl.Text, $"{player.GadgetsCount}/{brawlersData.GadgetsCount}");
            starPowersCountLbl.Text = GetString(starPowersCountLbl.Text, $"{player.StarPowersCount}/{brawlersData.StarPowersCount}");
            potentiallyHighestTrophiesLbl.Text = GetString(potentiallyHighestTrophiesLbl.Text, $"{player.PotentiallyHighestTrophies}");
            gearsCountLbl.Text = GetString(gearsCountLbl.Text, $"{player.GearsCount}");
            seasonEndTrophiesLbl.Text = GetString(seasonEndTrophiesLbl.Text, $"{player.SeasonEndTrophies} ({player.SeasonEndTrophies - player.Trophies})");
            blingsCountLbl.Text = GetString(blingsCountLbl.Text, $"{player.SeasonEndBlings}");
            brawlersMediumLvlLbl.Text = GetString(brawlersMediumLvlLbl.Text, $"{player.BrawlersMediumLevel}");
        }
        private async Task TryGetBrawlersData()
        {
            await BrawlAPI.TrySetToken();
            string json = await BrawlAPI.GetAllBrawlersDataJson();
            if (json == string.Empty) return;
            brawlersData = JsonSerializer.Deserialize<BrawlersData>(json);
        }
        private void ShowLastBattleTime(string yyyyMMddTHHmmss)
        {
            DateTime lastBattleTime = DateTime.ParseExact(yyyyMMddTHHmmss, "yyyyMMddTHHmmss", null);
            DateTime currentTime = DateTime.UtcNow;
            TimeSpan timeDiff = currentTime - lastBattleTime;
            lastBattleTimeLbl.Text = GetString(lastBattleTimeLbl.Text, $"{(int)timeDiff.TotalDays}д. {timeDiff.Hours}ч. {timeDiff.Minutes}м. {timeDiff.Seconds}с. назад");
        }
        private static string GetString(string s1, string s2, int finalStringLength = 30)
        {
            int newLineIndex = s1.IndexOf("\n");
            int currentLength = newLineIndex < 0 ? s1.Length : s1[(newLineIndex + 1)..].Length;
            int inputLength = s2.Length;
            for (int i = 0; i < finalStringLength - inputLength - currentLength; i++)
            {
                s2 = " " + s2;
            }
            return s1 + s2;
        }

        private void TagTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = tagTextBox.Text;
            if (string.IsNullOrEmpty(text) || text[0] != '#')
            {
                tagTextBox.Text = "#" + text;
                tagTextBox.SelectionStart = tagTextBox.Text.Length;
            }
            for (int i = 1; i < tagTextBox.Text.Length; i++)
            {
                if (!char.IsLetterOrDigit(tagTextBox.Text[i]))
                {
                    tagTextBox.Text = tagTextBox.Text.Remove(i, 1);
                    tagTextBox.SelectionStart = i;
                }
            }
        }

        public void SortPlayerBrawlers()
        {
            if (player == null) return;
            switch (sortingBrawlersComboBox.SelectedItem)
            {
                case "Меньше всего трофеев":
                    player.SortBrawlersByTrophies();
                    break;
                case "Больше всего трофеев":
                    player.SortBrawlersByTrophiesDescending();
                    break;
                case "Наивысшие трофеи":
                    player.SortBrawlersByHighestTrophies();
                    break;
                case "По уровню":
                    player.SortBrawlersByPower();
                    break;
                case "Ближе всех к новому рангу":
                    player.SortBrawlersByTrophiesToANewRank();
                    break;
                case "Потеряет трофеев (за сезон)":
                    player.SortBrawlersByLosingTrophies();
                    break;
                case "Получит блингов (за сезон)":
                    player.SortBrawlersByBlings();
                    break;
            }
            ShowBrawlers();
        }

        private void ShowBrawlers()
        {
            if (player == null || player.Brawlers == null) return;

            if (visualizationStyleComboBox.SelectedItem.ToString() == "Рисунок")
            {
                FormHelper.ShowPlayerBrawlersOnPictureBox(brawlersPanel, player);
            }
            else
            {
                FormHelper.ShowBrawlersOnTreeView(brawlersPanel, player);
            }
        }
        private void SortingBrawlersComboBox_SelectedIndexChanged(object sender, EventArgs e) => SortPlayerBrawlers();
        private void VisualizationStyleComboBox_SelectedIndexChanged(object sender, EventArgs e) => ShowBrawlers();


        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();
        }

        private void TagsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tagsComboBox.SelectedIndex == tagsComboBox.Items.Count - 1)
            {
                SavedPlayersNamesAndTags.Clear();
                tagsComboBox.Items.Clear();
                tagsComboBox.Items.Add("Очистить");
                AppDB.SavePlayersNameAndTagForTagsComboBox(SavedPlayersNamesAndTags);
                return;
            }
            tagTextBox.Text = SavedPlayersNamesAndTags[tagsComboBox.SelectedItem.ToString()!];
        }
    }
}