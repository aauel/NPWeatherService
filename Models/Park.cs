using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPWeatherService.Models
{
	public class Park
	{
		[Key] public string ParkCode { get; set; }
		[Required] public string State { get; set; }
		[Required] public string ParkName { get; set; }
		[Required] public int Acreage { get; set; }
		[Required] public int ElevationInFeet { get; set; }
		[Required] public decimal MilesOfTrail { get; set; }
		[Required] public int NumberOfCampsites { get; set; }
		[Required] public string Climate { get; set; }
		[Required] public int YearFounded { get; set; }
		[Required] public int AnnualVisitorCount { get; set; }
		[Required] public int EntryFee { get; set; }
		[Required] public int NumberOfAnimalSpecies { get; set; }
		[Required] public decimal Latitude { get; set; }
		[Required] public decimal Longitude { get; set; }
		[Required] public string InspirationalQuote { get; set; }
		[Required] public string InspirationalQuoteSource { get; set; }
		[Required] public string ParkDescription { get; set; }

		// Navigation Property
		public IList<Survey> Surveys { get; set; }
		public IList<Weather> DaysOfWeather { get; set; }

		public override string ToString ()
		{
			return ParkName.PadRight(17);
		}
	}
}
