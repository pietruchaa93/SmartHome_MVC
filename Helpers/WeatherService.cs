using Newtonsoft.Json;
using System.Net;

public class WeatherService
{
    private readonly string apiKey;

    public WeatherService(string apiKey)
    {
        this.apiKey = apiKey;
    }

    public WeatherData GetWeather(string city)
    {
        string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

        using (WebClient webClient = new WebClient())
        {
            string json = webClient.DownloadString(apiUrl);
            dynamic data = JsonConvert.DeserializeObject(json);

            double temperature = data.main.temp;
            int humidity = data.main.humidity;

            return new WeatherData(temperature, humidity);
        }
    }
}

public class WeatherData
{
    public double Temperature { get; }
    public int Humidity { get; }

    public WeatherData(double temperature, int humidity)
    {
        Temperature = temperature;
        Humidity = humidity;
    }
}