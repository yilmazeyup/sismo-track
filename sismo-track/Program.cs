using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

class Program
{
    static async Task Main(string[] args)
    {
        using (var client = new HttpClient())
        {
            var url = "https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&latitude=39.0&longitude=35.0&maxradiuskm=1000&limit=10";

            try
            {
                var response = await client.GetStringAsync(url);
                var json = JObject.Parse(response);
                var features = json["features"];

                foreach (var feature in features)
                {
                    var properties = feature["properties"];
                    var id = feature["id"];
                    var mag = properties["mag"];
                    var place = properties["place"];
                    var time = DateTimeOffset.FromUnixTimeMilliseconds((long)properties["time"]).DateTime;
                    var detailUrl = properties["detail"].ToString();

                    Console.WriteLine($"ID: {id}, Deprem: {mag}, Yer: {place}, Zaman: {time}");
                    Console.WriteLine($"Detay URL: {detailUrl}");
                    Console.WriteLine("------------------------------------------------------");

                    // Detay URL'sine istek yapılıyor
                    var detailResponse = await client.GetStringAsync(detailUrl);
                    var detailJson = JObject.Parse(detailResponse);
                    var detailedProperties = detailJson["properties"];

                    // Detaylı bilgileri yazdır
                    Console.WriteLine("Detaylı Bilgiler:");
                    Console.WriteLine($"Hissedildi: {detailedProperties["felt"]}");
                    Console.WriteLine($"CDI: {detailedProperties["cdi"]}");
                    Console.WriteLine($"MMI: {detailedProperties["mmi"]}");
                    Console.WriteLine($"Tsunami: {detailedProperties["tsunami"]}");
                    Console.WriteLine($"Önem: {detailedProperties["sig"]}");
                    Console.WriteLine("------------------------------------------------------");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine($"Message: {e.Message}");
            }
        }
    }
}
