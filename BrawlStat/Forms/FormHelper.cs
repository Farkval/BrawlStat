using BrawlStat.Data;
using BrawlStat.PlayerData;

namespace BrawlStat.Forms
{
    public static class FormHelper
    {
        public static void ShowBrawlersOnTreeView(Panel panel, Player player)
        {
            TreeView treeView = new()
            {
                Size = new Size(panel.Width, panel.Height)
            };
            panel.Controls.Clear();
            panel.Controls.Add(treeView);
            treeView.Nodes.Clear();

            List<Brawler> specialBrawlers = new();
            if (player.Sorting == Sorting.ByBlings || player.Sorting == Sorting.ByLosingTrophies)
            {
                specialBrawlers = player.Brawlers!.Take(20).ToList();
            }

            foreach (Brawler brawler in player.Brawlers!)
            {
                TreeNode brawlerNode = new(brawler.Name);
                treeView.Nodes.Add(brawlerNode);

                TreeNode rankNode = new($"Ранг: {brawler.Rank}");
                brawlerNode.Nodes.Add(rankNode);

                TreeNode trophiesNode = new($"Трофеи: {brawler.Trophies}");
                brawlerNode.Nodes.Add(trophiesNode);

                TreeNode highestTrophiesNode = new($"Наивысшие трофеи: {brawler.HighestTrophies}");
                brawlerNode.Nodes.Add(highestTrophiesNode);

                TreeNode powerNode = new($"Уровень силы: {brawler.Power}");
                brawlerNode.Nodes.Add(powerNode);

                if (player.Sorting == Sorting.ByLosingTrophies || player.Sorting == Sorting.ByBlings)
                {
                    int trophies = 0, blings = 0;
                    if (specialBrawlers.Contains(brawler))
                    {
                        trophies = brawler.Trophies - brawler.SeasonEndTrophies;
                        blings = brawler.SeasonEndBlings;
                    }

                    TreeNode seasonEndTrophiesNode = new($"Потеряет трофеев: {trophies}");
                    brawlerNode.Nodes.Add(seasonEndTrophiesNode);

                    TreeNode seasonEndBlingsNode = new($"Получит блингов: {blings}");
                    brawlerNode.Nodes.Add(seasonEndBlingsNode);
                }

                TreeNode gadgetsNode = new($"Гаджеты ({brawler.Gadgets!.Count}):");
                brawlerNode.Nodes.Add(gadgetsNode);
                foreach (Gadget gadget in brawler.Gadgets)
                {
                    TreeNode gadgetNode = new(gadget.Name);
                    gadgetsNode.Nodes.Add(gadgetNode);
                }

                TreeNode starPowersNode = new($"Звездные силы ({brawler.StarPowers!.Count}):");
                brawlerNode.Nodes.Add(starPowersNode);
                foreach (StarPower starPower in brawler.StarPowers)
                {
                    TreeNode starPowerNode = new(starPower.Name);
                    starPowersNode.Nodes.Add(starPowerNode);
                }

                TreeNode gearsNode = new($"Снаряжения ({brawler.Gears!.Count}):");
                brawlerNode.Nodes.Add(gearsNode);
                foreach (Gear gear in brawler.Gears)
                {
                    TreeNode gearNode = new(gear.Name);
                    gearsNode.Nodes.Add(gearNode);
                }
            }
        }

        public static void ShowPlayerBrawlersOnPictureBox(Panel panel, Player player)
        {
            //Инициализируем Bitmap на котором нарисуем всех бравлеров
            int height = player.Brawlers!.Count / 4 * 175;
            if (player.Brawlers.Count % 4 > 0) height += 175;
            Bitmap brawlersBmp = new(175 * 4, height);

            //Загрузим картинки уровня и кубка для рисования
            using Bitmap powerBmp = new(Path.Combine(AppDB.PowerDir, "Power.png"));
            using Bitmap trophyBitmap = new(Path.Combine(AppDB.TrophyDir, "Trophy.png"));
            using Graphics g = Graphics.FromImage(brawlersBmp);

            List<Brawler> specialBrawlers = new();
            if (player.Sorting == Sorting.ByBlings || player.Sorting == Sorting.ByLosingTrophies)
            {
                specialBrawlers = player.Brawlers.Take(20).ToList();
            }

            int x = 0, y = 0;
            foreach (Brawler brawler in player.Brawlers)
            {
                //Рисуем бравлера
                if (brawler.Image == null) continue;
                g.DrawImage(brawler.Image, x, y);

                //Подрисовываем картинку с уровнем бравлера
                int lblX = brawler.Power / 10 == 1 ? x + 129 : x + 134;
                g.DrawImage(powerBmp, x + 108, y + 74);
                g.DrawString($"{brawler.Power}", new("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Black), lblX, y + 99);

                //Подрисовываем картинку трофея с доп инфой
                switch (player.Sorting)
                {
                    case Sorting.ByHighestTrophies:
                        lblX = x + 145 - $"{brawler.HighestTrophies}".Length * 5;
                        g.DrawImage(trophyBitmap, x + 119, y + 3);
                        g.DrawString($"{brawler.HighestTrophies}", new("Arial", 10), new SolidBrush(Color.Black), lblX, y + 5);
                        break;
                    case Sorting.ByTrophiesToANewRank:
                        lblX = x + 145 - $"{brawler.TrophiesToANewRank}".Length * 5;
                        g.DrawImage(trophyBitmap, x + 119, y + 3);
                        g.DrawString($"{brawler.TrophiesToANewRank}", new("Arial", 10), new SolidBrush(Color.Black), lblX, y + 5);
                        break;
                    case Sorting.ByLosingTrophies:
                        int trophies = 0;
                        if (specialBrawlers.Contains(brawler))
                            trophies = brawler.Trophies - brawler.SeasonEndTrophies;

                        lblX = x + 145 - $"{trophies}".Length * 5;
                        g.DrawImage(trophyBitmap, x + 119, y + 3);
                        g.DrawString($"{trophies}", new("Arial", 10), new SolidBrush(Color.Black), lblX, y + 5);
                        break;
                    case Sorting.ByBlings:
                        int blings = 0;
                        if (specialBrawlers.Contains(brawler))
                            blings = brawler.SeasonEndBlings;

                        lblX = x + 145 - $"{blings}".Length * 5;
                        g.DrawImage(trophyBitmap, x + 119, y + 3);
                        g.DrawString($"{blings}", new("Arial", 10), new SolidBrush(Color.Black), lblX, y + 5);
                        break;
                }

                x += 175;
                if (x >= 175 * 4)
                {
                    x = 0;
                    y += 175;
                }
            }
            PictureBox pictureBox = new()
            {
                SizeMode = PictureBoxSizeMode.AutoSize,
                Image = brawlersBmp
            };
            panel.Controls.Clear();
            panel.Controls.Add(pictureBox);
        }
    }
}
