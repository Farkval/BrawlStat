using BrawlStat.Data;
using BrawlStat.PlayerData;
using System.Drawing.Drawing2D;

namespace BrawlStat.BrawlPainter
{
    public static class BrawlerPainter
    {
        public static Bitmap? CreateBrawlerImage(Brawler b)
        {
            if (!BrawlerImageExist(b.Id)) return null;

            Bitmap general = new(165, 165);
            using Bitmap background = b.GetRare() switch
            {
                Rare.Starting => BrawlersBackground.CreateStartingBackground(),
                Rare.Rare => BrawlersBackground.CreateRareBackground(),
                Rare.SuperRare => BrawlersBackground.CreateSuperRareBackground(),
                Rare.Epic => BrawlersBackground.CreateEpicBackground(),
                Rare.Mythic => BrawlersBackground.CreateMythicBackground(),
                Rare.Legendary => BrawlersBackground.CreateLegendaryBackground(),
                Rare.Chromatic => BrawlersBackground.CreateChromaticBackground(),
                _ => BrawlersBackground.CreateDefaultBackground()
            };
            using Bitmap brawler = (Bitmap)Image.FromFile(Path.Combine(AppDB.BrawlersDir, $"{b.Id}.png"));
            using Bitmap rank = (Bitmap)Image.FromFile(Path.Combine(AppDB.RanksDir, $"{b.Rank}.png"));
            using Graphics g = Graphics.FromImage(general);

            //Рисуем фон редкости бравлера
            g.DrawImage(background, 5, 25);
            //Рисуем коричневый прмоугольник снизу на котором будут гаджеты и звездные силы
            g.FillRectangle(new SolidBrush(Color.FromArgb(50, 40, 40)), 5, 125, 150, 40);
            //Рисуем самого бравлера
            g.DrawImage(brawler, 6, 26);
            //Рисуем черную окантовку
            g.DrawRectangle(new Pen(Color.Black, 3), 6, 26, 147, 100);
            g.DrawRectangle(new Pen(Color.Black, 3), 6, 26, 147, 137);

            //Вычисляем насколько надо заполнить полоску прогресса в ранге
            (int startRankTrophies, int endRankTrophies) = b.CurrentRankTrophiesRange;
            int length = b.Trophies < startRankTrophies ? 0 :
                b.Trophies > endRankTrophies ? 114 :
                (int)(114 * (double)((b.Trophies - startRankTrophies) / (double)(endRankTrophies - startRankTrophies)));
            //Рисуем незаполненную полоску прогресса в ранге
            g.FillRectangle(new SolidBrush(Color.FromArgb(75, 25, 25)), 40, 12, 114, 16);
            g.FillRectangle(new SolidBrush(Color.FromArgb(100, 25, 25)), 40, 28, 114, 8);
            //Рисуем заполненную полоску прогресса в ранге
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 153, 19)), 40, 12, length, 16);
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 130, 0)), 40, 28, length, 8);
            //Пишем количество трофеев бойца на полоске прогресса в ранге
            using GraphicsPath f = new();
            f.AddString($"{b.Trophies}", FontFamily.GenericSansSerif, (int)FontStyle.Bold, 19, new Point(65, 12), new StringFormat());
            g.DrawPath(new Pen(Color.Black, 2), f);
            g.FillPath(new SolidBrush(Color.White), f);
            //Рисуем черную окантовку для полоски прогресса в ранге
            g.DrawRectangle(new Pen(Color.Black, 2), 42, 12, 112, 24);
            //Рисуем значок ранга бравлера
            g.DrawImage(rank, 0, 0);

            //Ищем все существующие картинки гаджетов и звездных сил
            List<Bitmap> gadgetsAndStarPowers = new();
            foreach (Gadget gadget in b.Gadgets!)
            {
                if (GadgetImageExist(gadget.Id))
                {
                    Bitmap bmp = (Bitmap)Image.FromFile(Path.Combine(AppDB.GadgetsDir, $"{gadget.Id}.png"));
                    gadgetsAndStarPowers.Add(bmp);
                }
            }
            foreach (StarPower starPower in b.StarPowers!)
            {
                if (StartPowersImageExist(starPower.Id))
                {
                    Bitmap bmp = (Bitmap)Image.FromFile(Path.Combine(AppDB.StarPowersDir, $"{starPower.Id}.png"));
                    gadgetsAndStarPowers.Add(bmp);
                }
            }
            //Рисуем гаджеты и звездные силы
            int offset = (150 - gadgetsAndStarPowers.Count * 30) / (gadgetsAndStarPowers.Count + 1);
            int x = offset + 6;
            foreach (Bitmap bmp in gadgetsAndStarPowers)
            {
                g.DrawImage(bmp, x, 130);
                x += 30 + offset;
                bmp.Dispose();
            }

            return general;
        }

        private static bool BrawlerImageExist(int brawlerId)
        {
            string path = Path.Combine(AppDB.BrawlersDir, $"{brawlerId}.png");
            return new FileInfo(path).Exists;
        }
        private static bool GadgetImageExist(int gadgetId)
        {
            string path = Path.Combine(AppDB.GadgetsDir, $"{gadgetId}.png");
            return new FileInfo(path).Exists;
        }
        private static bool StartPowersImageExist(int gadgetId)
        {
            string path = Path.Combine(AppDB.StarPowersDir, $"{gadgetId}.png");
            return new FileInfo(path).Exists;
        }
    }
}
