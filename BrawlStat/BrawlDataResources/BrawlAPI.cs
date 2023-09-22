using System.Text;

namespace BrawlStat.BrawlDataResources
{
    public static class BrawlAPI
    {
        #region properties
        private static string? token;
        private static DateTime tokenUpdateTime;
        private static readonly HttpClient httpClient;
        public static string Token
        {
            get
            {
                return token ?? string.Empty;
            }
        }
        public static DateTime TokenUpdateTime
        {
            get
            {
                return tokenUpdateTime;
            }
        }
        #endregion

        static BrawlAPI()
        {
            httpClient = new();
        }

        public static async Task TrySetToken()
        {
            if ((DateTime.UtcNow - tokenUpdateTime).TotalMinutes < 59) return;

            string apiUrl = "https://developer.brawlstars.com/api/login";
            StringContent requestContent = new(
                "{\"email\":\"ramil.358@yandex.ru\",\"password\":\"123456789superDev!!!\"}",
                Encoding.UTF8,
                "application/json"
            );

            try
            {
                HttpResponseMessage responce = await httpClient.PostAsync(apiUrl, requestContent);

                if (responce.IsSuccessStatusCode)
                {
                    string data = await responce.Content.ReadAsStringAsync();
                    token = data[(data.IndexOf("temporaryAPIToken") + 20)..(data.IndexOf("swaggerUrl") - 3)];
                    tokenUpdateTime = DateTime.UtcNow;

                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Add("authorization", $"Bearer {token}");
                    httpClient.DefaultRequestHeaders.Add("accept", "application/json");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task<string> GetPlayerJson(string playerTagNum)
        {
            if (token == null) return string.Empty;

            string apiUrl = $"https://api.brawlstars.com/v1/players/%23";
            try
            {
                return await httpClient.GetStringAsync($"{apiUrl}{playerTagNum}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static async Task<string> GetPlayerBattlesLogJson(string playerTagNum)
        {
            if (token == null) return string.Empty;

            string apiUrl = $"https://api.brawlstars.com/v1/players/%23";
            try
            {
                return await httpClient.GetStringAsync($"{apiUrl}{playerTagNum}/battlelog");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static async Task<string> GetAllBrawlersDataJson()
        {
            if (token == null) return string.Empty;

            string apiUrl = $"https://api.brawlstars.com/v1/brawlers?limit=210";
            try
            {
                return await httpClient.GetStringAsync(apiUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static void Dispose()
        {
            httpClient.Dispose();
        }
    }
}
