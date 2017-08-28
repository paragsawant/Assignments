using CalorieCalculator.API.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCalculator.API
{
	/// <summary>
	/// Health Calculator
	/// </summary>
	public static class HealthCalculator
	{
		/// <summary>
		/// Get Calories of patient
		/// </summary>
		/// <param name="patientInfo">Patient Physical Info</param>
		/// <returns>Calories of patient</returns>
		public static string GetCalories(PatientPhysicalInfo patientInfo)
		{
			if (patientInfo.Gender == Gender.Male)
			{
				return (66
				+ (6.3 * Convert.ToDouble(patientInfo.Weight))
				+ (12.9 * ((Convert.ToDouble(patientInfo.HeightFeet) * 12) + Convert.ToDouble(patientInfo.HeightInches)))
				- (6.8 * Convert.ToDouble(patientInfo.Age))).ToString(CultureInfo.InvariantCulture);

			}

			return (655
			+ (4.3 * Convert.ToDouble(patientInfo.Weight))
			+ (4.7 * ((Convert.ToDouble(patientInfo.HeightFeet) * 12)
			+ Convert.ToDouble(patientInfo.HeightInches)))
			- (4.7 * Convert.ToDouble(patientInfo.Age))).ToString(CultureInfo.InvariantCulture);

		}

		/// <summary>
		/// Get Ideal weight of patient
		/// </summary>
		/// <param name="patientInfo">Patient Physical Info </param>
		/// <returns>Calories of patient</returns>
		public static string GetIdealWeight(PatientPhysicalInfo patientInfo)
		{
			if (patientInfo.Gender == Gender.Male)
			{
				return ((50 +
				(2.3 * (((Convert.ToDouble(patientInfo.HeightFeet) - 5) * 12)
				+ Convert.ToDouble(patientInfo.HeightInches)))) * 2.2046).ToString(CultureInfo.InvariantCulture);
			}

			return ((45.5 +
			(2.3 * (((Convert.ToDouble(patientInfo.HeightFeet) - 5) * 12)
			+ Convert.ToDouble(patientInfo.HeightInches)))) * 2.2046).ToString(CultureInfo.InvariantCulture);

		}

		/// <summary>
		/// Get Distance From Ideal Weight
		/// </summary>
		/// <param name="idealWeight">ideal Weight</param>
		/// <param name="weight">Current Weight</param>
		/// <returns>Difference between current weight and ideal weight</returns>
		public static string GetDistanceFromIdealWeight(string idealWeight, string weight)
		{
			return (Convert.ToDouble(weight) - Convert.ToDouble(idealWeight)).ToString(CultureInfo.InvariantCulture);
		}

	}
}
