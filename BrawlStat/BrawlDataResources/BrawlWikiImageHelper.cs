namespace BrawlStat.BrawlDataResources
{
    public class BrawlWikiImageHelper
    {
        public HttpClient HttpClient;
        private const string baseUrl = "https://brawlstars.fandom.com/ru/wiki/Шаблон:";
        public BrawlWikiImageHelper(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        /// <summary>
        /// Метод получения HTML сайта BrawlWiki с картинками всех гаджетов
        /// </summary>
        public async Task<string> GetBrawlWikiGadgetsHtml()
        {
            if (HttpClient == null) return string.Empty;

            HttpResponseMessage responce = await HttpClient.GetAsync(baseUrl + "Гаджеты");
            if (responce.IsSuccessStatusCode)
            {
                return await responce.Content.ReadAsStringAsync();
            }
            return string.Empty;
        }
        /// <summary>
        /// Метод получения HTML сайта BrawlWiki с картинками всех зведных сил
        /// </summary>
        public async Task<string> GetBrawlWikiStarPowersHtml()
        {
            if (HttpClient == null) return string.Empty;

            HttpResponseMessage responce = await HttpClient.GetAsync(baseUrl + "Звёздные_силы");
            if (responce.IsSuccessStatusCode)
            {
                return await responce.Content.ReadAsStringAsync();
            }
            return string.Empty;
        }

        /// <summary>
        /// Метод получения списка ссылок на картинки для гаджетов и звездных сил с HTML сайта BrawlWiki
        /// </summary>
        public List<string> GetHrefsFromHtml(string html)
        {
            if (HttpClient == null) return new();

            List<string> hrefs = new();

            html = html[html.IndexOf("<div class=\"main-container\">")..html.IndexOf("<script type=\"application/javascript\">")];

            while (html.Contains("<div class=\"floatnone\">"))
            {
                html = html[(html.IndexOf("<div class=\"floatnone\">") + 32)..];
                int endIndex = html.IndexOf("class=\"image\">") - 2;
                string href = html[..endIndex];
                hrefs.Add(href.Replace("&amp;", "&"));
                html = html[endIndex..];
            }
            return hrefs;
        }

        /// <summary>
        /// Метод скачивания картинок в указанную дирректорию по href
        /// </summary>
        protected async Task DownloadImageFromHrefs(List<string> hrefs, string dirPathToSave)
        {
            if (HttpClient == null) return;
            if (!new FileInfo(dirPathToSave).Exists) Directory.CreateDirectory(dirPathToSave);

            for (int i = 0; i < hrefs.Count; i++)
            {
                using Stream stream = await HttpClient.GetStreamAsync(hrefs[i]);
                using MemoryStream memoryStream = new();
                stream.CopyTo(memoryStream);
                Image image = Image.FromStream(memoryStream);
                Bitmap bitmap = new(image, 30, 30);
                bitmap.Save($"{dirPathToSave}/{i}.png");
            }
        }
        /// <summary>
        /// Загружает иконки рангов бравлеров в указанную дирректорию с BrawlWiki 
        /// </summary>
        protected async Task DownloadRanksIcon(string dirPathToSave)
        {
            if (HttpClient == null) return;
            if (!new FileInfo(dirPathToSave).Exists) Directory.CreateDirectory(dirPathToSave);

            for (int i = 1; i < 36; i++)
            {
                try
                {
                    using Stream stream = await HttpClient.GetStreamAsync($"https://cdn.brawlify.com/rank/{i}.png");
                    using MemoryStream memoryStream = new();
                    stream.CopyTo(memoryStream);

                    using Image image = Image.FromStream(memoryStream);
                    using Bitmap bitmap = new(image, (int)(image.Width * 0.1625), (int)(image.Height * 0.1625));
                    bitmap.Save($"{dirPathToSave}/{i}.png");
                }
                catch { }
            }
        }
    }
}
