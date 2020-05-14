using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPWeatherService.Models
{
	/* Response 
			<<< "daily" data block 
				<<< "data" array of 8 data points 
					<<< "icon" -> text summary of this data point 
							<<< [clear-day, clear-night, rain, snow, sleet, wind, fog, cloudy, partly-cloudy-day, partly-cloudy-night] >>>
						"temperatureHigh" -> daytime high temperature in degrees Fahrenheit, 
						"temperatureLow" -> daytime low temperature in degrees Fahrenheit, 
						"time" -> UNIX time at midnight of the day
		 */

	public class DataPoint
	{
		[JsonProperty(PropertyName = "time")] internal long TimeUnix { get; set; }
		[JsonProperty(PropertyName = "icon")] public string Icon { get; set; }
		[JsonProperty(PropertyName = "temperatureLow")] public double TemperatureLow { get; set; }
		[JsonProperty(PropertyName = "temperatureHigh")] public double TemperatureHigh { get; set; }
	}

	public class DataBlock
	{
		/* List will contain 8 <DataPoint> objects for 8 days of forecasts, ordered by time */
		[JsonProperty(PropertyName = "data")] public List<DataPoint> Data { get; set; }
	}

	public class Forecast
	{
		// A <DataBlock> containing the weather conditions day-by-day for the next week.
		[JsonProperty(PropertyName = "daily")] public DataBlock Daily { get; set; }
	}
}
