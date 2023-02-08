using DEINT_Ej9_El_tiempo.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DEINT_Ej9_El_tiempo.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class WeatherViewModel
    {
        public bool IsVisible { get; set; }
        public WeatherData WeatherData { get; set; }
        public string Address { get; set; }
        public string Searched_Address { get; set; }
        public DateTime CurrentDate { get; set; }

        private HttpClient client;

        public ICommand SearchCommand { get; set; }

        public WeatherViewModel()
        {
            IsVisible = false;
            client = new HttpClient();

            SearchCommand = new Command(async (s) => {
                try { 
                    CurrentDate = DateTime.Now;

                    Searched_Address = Address;

                    await GetWeather(await GetCoordinatesAsync(s.ToString()));

                    IsVisible = true;
                } catch (NullReferenceException e)
                {
                    await App.Current.MainPage.DisplayAlert("Localidad", "Localidad no encontrada", "OK");
                    IsVisible = false;
                }
        });
        }

        private async Task<Location> GetCoordinatesAsync(string address) { 
            var locations = await Geocoding.GetLocationsAsync(address);
            var location = locations?.FirstOrDefault();
            return location;
        }

        private async Task GetWeather(Location location) {
            try
            {
                string longitud = (Math.Round(location.Longitude, 2).ToString().Replace(",", "."));
                string latitud = (Math.Round(location.Latitude, 2).ToString().Replace(",", "."));

                var url = $"https://api.open-meteo.com/v1/forecast?latitude={latitud}&longitude={longitud}&daily=weathercode,temperature_2m_max,temperature_2m_min&current_weather=true&timezone=auto";

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        var data = await JsonSerializer.DeserializeAsync<WeatherData>(responseStream);
                        WeatherData = data;
                    }
                }
            }
            catch (NullReferenceException e) {
                throw new NullReferenceException();
            }
        }
    }
}
