using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLibrary
{
    public class Weather
    {
        public string Clouds { get; set; }
        public string Temperature { get; set; }
        public string Wind { get; set; }
        public string Direction { get; set; }
        public string Humidity { get; set; }
        public string Water { get; set; }
       
        public Weather() { }

        public void Upload(string url)
        {
            try
            {
                WebClient web = new WebClient();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                Regex Clouds_reg = new Regex("<div class=\"description\">([А-ЯІЄа-яіє.,\\s]+)<\\/div><\\/div><div class=\"weather-item\"><div class=\"item-label\">");
                Match m1 = Clouds_reg.Match(html);

                Regex Temperature_reg = new Regex("<span class=\"unit-temperature\" data-temperature-f=\"\\d+\">([+-]?\\d+)<\\/span><\\/div>");
                Match m2 = Temperature_reg.Match(html);

                Regex Wind_reg = new Regex("<div class=\"item-label\">Вітер<\\/div><div class=\"item-value\"><span class=\"unit-wind\" data-wind-kmh=\"\\d+\" data-wind-mph=\"\\d+\">(\\d+)<\\/span>");
                Match m3 = Wind_reg.Match(html);

                Regex Direction_reg = new Regex("<span class=\"small item-measure unit-wind\" data-wind-kmh=\"км\\/год, .+\" data-wind-mph=\"миля\\/год, .+\"> м\\/c, (.+)<\\/span><\\/div><\\/div><div class=\"weather-item\"><div class=\"item-label\">Тиск<\\/div>");
                Match m4 = Direction_reg.Match(html);

                Regex Humidity_reg = new Regex("Вологість<\\/div><div class=\"item-value\">(\\d+)<span class=\"small\">&nbsp;%<\\/span><\\/div>");
                Match m5 = Humidity_reg.Match(html);

                Regex Water_reg = new Regex("Вода<\\/div><div class=\"item-value\"><span class=\"unit-temperature\" data-temperature-f=\"\\d+\">(((\\+|-\r\n)[1-9]\\d?)|(0))<\\/span><\\/div><\\/div>");
                Match m6 = Water_reg.Match(html);

                
                Clouds = m1.Success ? m1.Groups[1].Value.Trim() : "Немає даних";
                Temperature = m2.Success ? m2.Groups[1].Value.Trim() + "°C" : "Немає даних";
                Wind = m3.Success ? m3.Groups[1].Value.Trim() + " км/год" : "Немає даних";
                Direction = m4.Success ? m4.Groups[1].Value.Trim() : "Немає даних";
                Humidity = m5.Success ? m5.Groups[1].Value.Trim() + "%" : "Немає даних";
                Water = m6.Success ? m6.Groups[1].Value.Trim() + "°C" : "Немає даних";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка завантаження погодних даних: " + ex.Message);
            }
        }
    }
}

