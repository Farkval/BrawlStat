using BrawlStat.Data;

namespace BrawlStat.BrawlDataResources
{
    public class OtherImageDownloader
    {
        public HttpClient HttpClient;
        public OtherImageDownloader(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }
        public async Task DownloadImageFromUrl(string url, string dirPathToSave, string fileName = "0", double resizeCoeff = 1.0)
        {
            if (HttpClient == null) return;
            if (!new FileInfo(dirPathToSave).Exists) Directory.CreateDirectory(dirPathToSave);

            using Stream stream = await HttpClient.GetStreamAsync(url);
            using MemoryStream memoryStream = new();
            stream.CopyTo(memoryStream);

            using Image image = Image.FromStream(memoryStream);
            Bitmap bitmap = new(image, (int)(image.Width * resizeCoeff), (int)(image.Height * resizeCoeff));
            bitmap.Save(Path.Combine(dirPathToSave, $"{fileName}.png"));
        }
        public async Task DownloadPowerImage()
        {
            string url = "https://cdn130.picsart.com/293938373036211.png";
            await DownloadImageFromUrl(url, AppDB.PowerDir, "Power",0.065);
        }
        public async Task DownloadTrophyImage()
        {
            string url = "https://static.wikia.nocookie.net/brawlstars/images/c/cd/Trophy.png/revision/latest/scale-to-width-down/100?cb=20200304181812";
            await DownloadImageFromUrl(url, AppDB.TrophyDir, "Trophy", 0.565);
        }
    }
}
