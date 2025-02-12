using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Image
    {
        public string Picture { get; private set; }

        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<Image> CreateAsync(string url)
        {
            var image = new Image();
            await image.LoadImage(url);  
            return image;
        }

        private async Task LoadImage(string url)
        {
            try
            {
                var html = await DownloadHtmlAsync(url);
                Picture = ExtractImage(html);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при завантаженні зображення: {ex.Message}");
                Picture = "Немає даних";
            }
        }

        private async Task<string> DownloadHtmlAsync(string url)
        {
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }

        private string ExtractImage(string html)
        {
            try
            {
                Regex regex = new Regex("<img[^>]*srcset=\"([^\"]+)\"[^>]*>");
                Match match = regex.Match(html);

                if (match.Success)
                {
                    return match.Groups[1].Value;
                }
                else
                {
                    return "Немає даних";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при обробці HTML: {ex.Message}");
                return "Немає даних";
            }
        }
    }
}
