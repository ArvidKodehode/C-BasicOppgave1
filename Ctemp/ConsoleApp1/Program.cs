using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json.Linq;

class Program
{
    // Sett API-nøkkel og by
    private const string ApiKey = "5fb4bae3c1b740bb986123429252401"; // Brukerens API-nøkkel
    private const string City = "Haugesund";
    private const string ApiUrl = $"https://api.weatherapi.com/v1/current.json?key={ApiKey}&q={City}&aqi=no";

    static async Task Main(string[] args)
    {
        Console.WriteLine("Starter program for å hente temperatur og vindhastighet for Haugesund...");

        while (true)
        {
            try
            {
                // Hent værdata
                var weatherData = await GetWeatherData();
                if (weatherData != null)
                {
                    // Skriv ut til konsoll
                    Console.Clear();
                    Console.WriteLine($"Sted: {City}");
                    Console.WriteLine($"Temperatur: {weatherData.Temperature}°C");
                    Console.WriteLine($"Vindhastighet: {weatherData.WindSpeed} m/s");
                    Console.WriteLine($"Oppdatert: {DateTime.Now}");
                }
                else
                {
                    Console.WriteLine("Ingen data tilgjengelig. Sjekk API-nøkkel eller bynavn.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Feil ved henting av data: {ex.Message}");
            }

            // Vent 10 sekunder før neste oppdatering
            Thread.Sleep(10000);
        }
    }

    private static async Task<WeatherData?> GetWeatherData()
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(ApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(json);

                // Sjekk om feltene eksisterer
                var current = data["current"];
                if (current != null)
                {
                    var temperature = current["temp_c"]?.ToObject<double>() ?? 0.0; // Standardverdi 0.0 hvis null
                    var windSpeed = current["wind_mps"]?.ToObject<double>() ?? 0.0; // Standardverdi 0.0 hvis null

                    return new WeatherData
                    {
                        Temperature = temperature,
                        WindSpeed = windSpeed
                    };
                }
                else
                {
                    Console.WriteLine("Uventet JSON-format. Sjekk API-responsen.");
                    return null;
                }
            }
            else
            {
                Console.WriteLine($"Kunne ikke hente data. HTTP-status: {response.StatusCode}");
                return null;
            }
        }
    }
}

class WeatherData
{
    public double Temperature { get; set; }
    public double WindSpeed { get; set; }
}


//dotnet add package Newtonsoft.Json