using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCalculator.API
{
	/// <summary>
	/// Validate Patient Information
	/// </summary>
	public class ValidatePatientInfo : IValidator<Dictionary<string, string>>
	{

		/// <summary>
		/// Convert String to Double Validation 
		/// </summary>
		/// <param name="inputs"></param>
		/// <returns></returns>
		public List<Exception> StringToDoubleValidation(Dictionary<string, string> inputs)
		{
			var exceptions = new List<Exception>();
			foreach (var input in inputs)
			{
				if (!double.TryParse(input.Value, out double result))
				{
					exceptions.Add(new Exception($"{input.Key} must be a numeric value."));
				}
			}

			return exceptions;
		}

		/// <summary>
		/// String to Integer Validation
		/// </summary>
		/// <param name="inputs"></param>
		/// <returns></returns>
		public List<Exception> StringToIntegerValidation(Dictionary<string, string> inputs)
		{
			var exceptions = new List<Exception>();
			foreach (var input in inputs)
			{
				if (!int.TryParse(input.Value, out int result))
				{
					exceptions.Add(new Exception($"{input.Key}"));
				}
			}

			return exceptions;
		}
	}
}
