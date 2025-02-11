using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Image 
    {
        public string Picture { get; set; }
        public Image(string url)
        {
            LoadImage(url);
        }

        private void LoadImage(string url)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(url);

            Picture = ExtractImage(html);
        }
        public static string ExtractImage(string html)
        {
            Regex regex = new Regex("<img[^>]*src=\"(//sinst\\.fwdcdn\\.com/img/weatherImg/b/\\w+\\.jpg)\"[^>]*>");



            Match match = regex.Match(html);
            if (match.Success)
            {
                string text = match.Groups[1].Value;
                return text;
            }
            else return "Немає даних";



        }


    }
}
