using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Newtonsoft.Json;
using LifeManagementApp1.Model;
using CommunityToolkit.Mvvm.Input;


namespace LifeManagementApp1.ViewModel
{
    public partial class WeatherViewModel : INotifyPropertyChanged
    {
        private string _city;
        private LifeManagementApp1.Model.WeatherData _weatherData;

        private string _alertMessage;
        private string _iconUrl;

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged();
            }
        }

        public WeatherData WeatherData
        {
            get => _weatherData;
            set
            {
                _weatherData = value;
                OnPropertyChanged();
            }
        }

        public string AlertMessage
        {
            get => _alertMessage;
            set
            {
                _alertMessage = value;
                OnPropertyChanged();
            }
        }

        public string IconUrl
        {
            get => _iconUrl;
            set
            {
                _iconUrl = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetWeatherCommand { get; }

        public WeatherViewModel()
        {
            GetWeatherCommand = new Command(async () => await GetWeatherAsync());
        }

        private async Task GetWeatherAsync()
        {
            if (string.IsNullOrEmpty(City))
            {
                AlertMessage = "Please enter a city.";
                return;
            }

            WeatherData = await FetchWeatherData(City);

            if (WeatherData != null)
            {
                IconUrl = $"https://openweathermap.org/img/wn/{WeatherData.Icon}@2x.png";
                AlertMessage = WeatherData.WindSpeed > 4 ? "Wind speed alert: More than 4 m/s!" : string.Empty;
            }
            else
            {
                AlertMessage = "Weather data could not be retrieved.";
            }
        }

        private async Task<WeatherData> FetchWeatherData(string city)
        {
            try
            {
                string apiKey = "41a8bbca562b148eb901743dad61fa52";
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

                using (var client = new HttpClient())
                {
                    var response = await client.GetStringAsync(url);
                    var weatherResponse = JsonConvert.DeserializeObject<WeatherApiResponse>(response);

                    return new WeatherData
                    {
                        Temp = weatherResponse.Main.Temp,
                        TempMin = weatherResponse.Main.TempMin,
                        TempMax = weatherResponse.Main.TempMax,
                        Description = weatherResponse.Weather[0].Description,
                        WindSpeed = weatherResponse.Wind.Speed,
                        Icon = weatherResponse.Weather[0].Icon
                    };
                }
            }
            catch
            {
                return null;
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
