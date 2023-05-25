//using System.Net.Http;
//using System.Threading.Tasks;


//namespace SmartHome_MVC.Helpers

//{
//    public class WeatherServices
//    {
//        private readonly HttpClient httpClient;

//        public WeatherService()
//        {
//            httpClient = new HttpClient();
//        }

//        public async Task<double> GetCurrentTemperature()
//        {
//            string apiKey = "b78914adc769484c70194fc36745f561"; // Tutaj wpisz swój klucz API OpenWeatherMap

//            string url = $"http://api.openweathermap.org/data/2.5/weather?q=Bydgoszcz&appid={apiKey}&units=metric";

//            HttpResponseMessage response = await httpClient.GetAsync(url);

//            if (response.IsSuccessStatusCode)
//            {
//                var weatherData = await response.Content.ReadAsAsync<WeatherData>();
//                return weatherData.Main.Temperature;
//            }
//            else
//            {
//                throw new Exception("Błąd podczas pobierania danych pogodowych.");
//            }
//        }
//    }

//    public class WeatherData
//    {
//        public MainData Main { get; set; }
//    }

//    public class MainData
//    {
//        public double Temperature { get; set; }
//    }
//}
