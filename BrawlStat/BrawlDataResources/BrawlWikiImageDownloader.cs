using BrawlStat.Data;
using System.Text.Json;

namespace BrawlStat.BrawlDataResources
{
    public class BrawlWikiImageDownloader : BrawlWikiImageHelper
    {
        public BrawlWikiImageDownloader(HttpClient httpClient) : base(httpClient)
        {
            HttpClient = httpClient;
        }
        public async Task DownloadGadgetsAndStarPowers()
        {
            #region Удаляем существующие картинки

            DirectoryInfo gadgetsDirInfo = new(AppDB.GadgetsDir);
            foreach (FileInfo file in gadgetsDirInfo.EnumerateFiles())
            {
                file.Delete();
            }
            DirectoryInfo starPowersDirInfo = new(AppDB.StarPowersDir);
            foreach (FileInfo file in starPowersDirInfo.EnumerateFiles())
            {
                file.Delete();
            }


            #endregion
            #region Загружаем картинки в файлы

            string gadgetsHTML = await GetBrawlWikiGadgetsHtml();
            List<string> gadgetsHrefs = GetHrefsFromHtml(gadgetsHTML);
            await DownloadImageFromHrefs(gadgetsHrefs, AppDB.GadgetsDir);

            string starPowersHTML = await GetBrawlWikiStarPowersHtml();
            List<string> starPowersHrefs = GetHrefsFromHtml(starPowersHTML);
            await DownloadImageFromHrefs(starPowersHrefs, AppDB.StarPowersDir);

            #endregion

            (List<int> gadgetsId, List<int> starPowersId) = await GetAllGadgetsAndStarPowersIdSortedByRare();

            #region Переименовываем файлы

            gadgetsDirInfo = new(AppDB.GadgetsDir);
            FileInfo[] gadgets = gadgetsDirInfo.GetFiles();
            for (int i = 0; i < gadgets.Length; i++)
            {
                File.Move($"{AppDB.GadgetsDir}/{i}.png", $"{AppDB.GadgetsDir}/{gadgetsId[i]}.png");
            }

            starPowersDirInfo = new(AppDB.StarPowersDir);
            FileInfo[] starPowers = starPowersDirInfo.GetFiles();
            for (int i = 0; i < starPowers.Length; i++)
            {
                File.Move($"{AppDB.StarPowersDir}/{i}.png", $"{AppDB.StarPowersDir}/{starPowersId[i]}.png");
            }

            #endregion
        }

        public async Task LoadRanks()
        {
            await DownloadRanksIcon(AppDB.RanksDir);
        }

        private async Task<(List<int>, List<int>)> GetAllGadgetsAndStarPowersIdSortedByRare()
        {
            await BrawlAPI.TrySetToken();

            string json = await BrawlAPI.GetAllBrawlersDataJson();

            //Отсортированные id бравлеров по редкости как в игре также как и на BrawlWiki
            List<int> brawlersIdSortedByRare = BrawlersRare.BrawlersIdSortedByRare.ToList();

            BrawlersData brawlersData = JsonSerializer.Deserialize<BrawlersData>(json)!;

            //Сортируем бравлеров по редкости как в игре
            brawlersData.Brawlers = brawlersData.Brawlers!
                .OrderBy(brawler => brawlersIdSortedByRare.IndexOf(brawler.Id))
                .ToList();

            //Возвращаем лист id гаджетов и звездных сил пропустив бравлеров которых нет сейчас на BrawlWiki
            return (brawlersData.Brawlers
                .Skip(brawlersData.Brawlers.Count - brawlersIdSortedByRare.Count)
                .SelectMany(brawler => brawler.Gadgets!.Select(gadget => gadget.Id))
                .ToList(),

                brawlersData.Brawlers
                .Skip(brawlersData.Brawlers.Count - brawlersIdSortedByRare.Count)
                .SelectMany(brawler => brawler.StarPowers!.Select(starPower => starPower.Id))
                .ToList());

        }
    }
}
