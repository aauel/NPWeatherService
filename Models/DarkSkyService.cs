using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace NPWeatherService.Models
{

	public class DarkSkyService
	{
		private readonly Uri baseUri = new Uri("https://api.darksky.net/forecast/");
		private string _apiKey = null;
		private readonly HttpClient httpClient;
		private string responseBody;

		public DarkSkyService (string apiKey)
		{
			_apiKey = apiKey;
			httpClient = new HttpClient();
		}

		public async Task<Forecast> GetForecast(Park park)
		{
			string query = $"{_apiKey}/{park.Latitude},{park.Longitude}?exclude=currently,minutely,hourly,alerts,flags";
			HttpResponseMessage response = await httpClient.GetAsync($"{baseUri}{query}");
			response.EnsureSuccessStatusCode();
			responseBody = await response.Content.ReadAsStringAsync();

			// Forecast - "daily" data block with 8 data points for 8 days of weather
			Forecast forecast = JsonConvert.DeserializeObject<Forecast>(responseBody);
			return forecast;
		}

		public List<Weather> GetWeatherForWeek(Park park, Forecast forecast)
		{
			List<Weather> WeekOfWeather = new List<Weather>();

			// Creates Weather objects for each day
			foreach (DataPoint day in forecast.Daily.Data) {
				Weather w = new Weather
				{
					ParkCode = park.ParkCode,
					ForecastDate = UnixTimeStampToDateTime(day.TimeUnix),
					LowTemp = day.TemperatureLow,
					HighTemp = day.TemperatureHigh,
					Forecast = day.Icon
				};
				WeekOfWeather.Add(w);
			}
			return WeekOfWeather;
		}

		private static DateTime UnixTimeStampToDateTime (long unixTimeStamp)
		{
			// Unix timestamp is seconds past epoch
			System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
			return dtDateTime;
		}

	}
}
