using BrawlStat.Data;
using BrawlStat.PlayerData;

namespace BrawlStat.BrawlDataResources
{
    public class BrawlStatsImageDownloader
    {
        public HttpClient HttpClient;
        private const string baseUrl = "https://cdn.brawlstats.com/character-arts/";
        public BrawlStatsImageDownloader(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task DownloadBrawlers(BrawlersData brawlersData, string dirPathToSave)
        {
            if (HttpClient == null || brawlersData.Brawlers == null) return;
            if (!new DirectoryInfo(dirPathToSave).Exists) Directory.CreateDirectory(dirPathToSave);

            foreach (Brawler brawler in brawlersData.Brawlers)
            {
                try
                {
                    using Stream stream = await HttpClient.GetStreamAsync($"{baseUrl}{brawler.Id}.png");
                    using MemoryStream memoryStream = new();
                    stream.CopyTo(memoryStream);

                    using Image image = Image.FromStream(memoryStream);
                    int width = (int)(100.0 * image.Size.Width / image.Size.Height);
                    double scaledValue = (double)(width - 100) / (138 - 100);
                    width = (int)(scaledValue * (148 - 100) + 100);
                    if (width > 148) width = 148;
                    using Bitmap bitmap = new(image, width, 100);
                    bitmap.Save($"{dirPathToSave}/{brawler.Id}.png");
                }
                catch { }
            }
        }
    }
}
