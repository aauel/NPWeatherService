using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPWeatherService.Models
{
	public enum ActivityLevel
	{
		Inactive,
		Sedentary,
		Active,
		[Display(Name = "Extremely Active")]
		ExtremelyActive
	}

	public enum State
	{
		AL, AK, AZ, AR, CA, CO, CT, DE, DC, FL, 
		GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, 
		MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, 
		NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, 
		SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, WY
	}

	public class Survey
	{
		[Key] public int Id { get; set; }
		[Required] public string ParkCode { get; set; }
		[Required] public string EmailAddress { get; set; }
		[Required] public State State { get; set; }
		[Required] public ActivityLevel ActivityLevel { get; set; }

		// Navigation Property

		[ForeignKey("ParkCode")] public Park Park { get; set; }
	}
}
