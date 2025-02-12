using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Weather
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        // Регулярні вирази як константи
        private static readonly string CloudsPattern = "<div class=\"description\">([А-ЯІЄа-яіє.,\\s]+)<\\/div><\\/div><div class=\"weather-item\"><div class=\"item-label\">";
        private static readonly string TemperaturePattern = @"<temperature-value value=""([+-]?\d+)"" from-unit=""c"" reactive>";
        private static readonly string WindPattern = @"<speed-value value=""([+-]?\d+)"" from-unit=""ms"" reactive>";
        private static readonly string DirectionPattern = @"<span class=""small"">\s*&nbsp;\s*<speed-value[^>]*>м\/с<\/speed-value>\s*,\s*([^""]+?)\s*==";
        private static readonly string HumidityPattern = "Вологість<\\/div><div class=\"item-value\">(\\d+)<span class=\"small\">&nbsp;%<\\/span><\\/div>";
        private static readonly string WaterPattern = @"<div class=""weather-item"">\s*<div class=""item-label"">Вода<\/div>\s*<div class=""item-value"">\s*<temperature-value value=""([+-]?\d+)"" from-unit=""c"" reactive>";

        public string Clouds { get; set; }
        public string Temperature { get; set; }
        public string Wind { get; set; }
        public string Direction { get; set; }
        public string Humidity { get; set; }
        public string Water { get; set; }

        public Weather()
        {
        }

        // Асинхронний метод для завантаження даних
        public async Task UploadAsync(string url)
        {
            try
            {
                var html = await _httpClient.GetStringAsync(url);

                Clouds = ExtractData(CloudsPattern, html, "Немає даних");
                Temperature = ExtractData(TemperaturePattern, html, "Немає даних") + "°C";
                Wind = ExtractData(WindPattern, html, "Немає даних") + " км/год";
                Direction = ExtractData(DirectionPattern, html, "Немає даних");
                Humidity = ExtractData(HumidityPattern, html, "Немає даних") + "%";
                Water = ExtractData(WaterPattern, html, "Немає даних") + "°C";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка завантаження погодних даних: {ex.Message}");
            }
        }

        // Спрощений метод для вилучення даних за допомогою регулярного виразу
        private string ExtractData(string pattern, string input, string defaultValue)
        {
            try
            {
                var regex = new Regex(pattern);
                var match = regex.Match(input);
                return match.Success ? match.Groups[1].Value.Trim() : defaultValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при обробці регулярного виразу: {ex.Message}");
                return defaultValue;
            }
        }
    }
}
