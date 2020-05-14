using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPWeatherService.Models
{
	public class Weather
	{
		public string ParkCode { get; set; }
		public DateTime ForecastDate { get; set; }
		public double LowTemp { get; set; }
		public double HighTemp { get; set; }
		public string Forecast { get; set; }


		public String GetWeatherRecommendation ()
		{
			return GetForecastRecommendation() + "\n" + GetTemperatureRecommendation();
		}

		private string GetForecastRecommendation ()
		{
			string result = string.Empty;
			switch (Forecast) {
				case "snow":
					result = "Pack snowshoes!";
					break;
				case "rain":
					result = "Pack rain gear, and wear waterproof shoes!";
					break;
				case "thunderstorms":
					result = "Seek shelter, and avoid hiking on exposed ridges!";
					break;
				case "sun":
					result = "Pack sunblock!";
					break;
			}
			return result;
		}

		private string GetTemperatureRecommendation ()
		{
			string result = string.Empty;
			if (HighTemp > 75)
				result = "Bring an extra gallon of water!\n";
			else if (LowTemp < 20)
				result = "DANGER! FRIGID TEMPERATURES!!\n";
			if (HighTemp - LowTemp > 20)
				result += "Wear breathable layers!\n";
			return result;
		}

	}
}
