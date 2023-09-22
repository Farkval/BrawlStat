using System.Drawing.Drawing2D;

namespace BrawlStat.BrawlPainter
{
    public static class BrawlersBackground
    {
        public static int BackgroundWidth = 150;
        public static int BackgroundHeight = 100;
        public static Bitmap CreateChromaticBackground()
        {
            Bitmap bitmap = new(BackgroundWidth, BackgroundHeight);
            using Graphics g = Graphics.FromImage(bitmap);
            Rectangle rect = new(0, 0, BackgroundWidth, BackgroundHeight);
            LinearGradientBrush brush = new(rect, Color.Yellow, Color.Purple, LinearGradientMode.BackwardDiagonal);
            ColorBlend colorBlend = new()
            {
                Positions = new[] { 0, 0.5f, 1 },
                Colors = new[] { Color.Yellow, Color.Red, Color.Purple }
            };
            brush.InterpolationColors = colorBlend;
            g.FillRectangle(brush, rect);
            return bitmap;
        }
        public static Bitmap CreateDefaultBackground()
        {
            Bitmap bitmap = new(BackgroundWidth, BackgroundHeight);
            using Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            return bitmap;
        }
        public static Bitmap CreateStartingBackground()
        {
            Bitmap bitmap = new(BackgroundWidth, BackgroundHeight);
            using Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.FromArgb(148, 215, 244));
            return bitmap;
        }
        public static Bitmap CreateRareBackground()
        {
            Bitmap bitmap = new(BackgroundWidth, BackgroundHeight);
            using Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.FromArgb(46, 221, 28));
            return bitmap;
        }
        public static Bitmap CreateSuperRareBackground()
        {
            Bitmap bitmap = new(BackgroundWidth, BackgroundHeight);
            using Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.FromArgb(0, 135, 250));
            return bitmap;
        }
        public static Bitmap CreateEpicBackground()
        {
            Bitmap bitmap = new(BackgroundWidth, BackgroundHeight);
            using Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.FromArgb(0, 135, 250));
            return bitmap;
        }
        public static Bitmap CreateMythicBackground()
        {
            Bitmap bitmap = new(BackgroundWidth, BackgroundHeight);
            using Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.Red);
            return bitmap;
        }
        public static Bitmap CreateLegendaryBackground()
        {
            Bitmap bitmap = new(BackgroundWidth, BackgroundHeight);
            using Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.Yellow);
            return bitmap;
        }
    }
}
