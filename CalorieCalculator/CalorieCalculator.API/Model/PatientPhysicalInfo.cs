using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCalculator.API.Model
{
	/// <summary>
	/// Patient Physical Information
	/// </summary>
	public class PatientPhysicalInfo
	{

		public Gender Gender { get; set; }

		public string Age { get; set; }

		public string HeightFeet { get; set; }

		public string HeightInches { get; set; }

		public string Weight { get; set; }

		/// <summary>
		/// Constructor of the Patient Physical Information
		/// </summary>
		/// <param name="gender">Gender of Patient</param>
		/// <param name="age">Age of Patient</param>
		/// <param name="heightFeet">Height in Feet of Patient</param>
		/// <param name="heightInches">Height in Inches of Patient</param>
		/// <param name="weight">Weight of Patient</param>
		public PatientPhysicalInfo(Gender gender, string age, string heightFeet, string heightInches, string weight)

		{
			this.Gender = gender;
			this.Age = age;
			this.HeightFeet = heightFeet;
			this.HeightInches = heightInches;
			this.Weight = weight;
		}

		/// <summary>
		/// Constructor of the Patient Physical Information
		/// </summary>
		/// <param name="age">Age of Patient</param>
		/// <param name="heightFeet">Height in Feet of Patient</param>
		/// <param name="heightInches">Height in Inches of Patient</param>
		/// <param name="weight">Weight of Patient</param>
		public PatientPhysicalInfo(string age, string heightFeet, string heightInches, string weight)

		{
			this.Age = age;
			this.HeightFeet = heightFeet;
			this.HeightInches = heightInches;
			this.Weight = weight;
		}

		/// <summary>
		/// Validate Patient Physical Information
		/// </summary>
		/// <returns>return exception if in valid</returns>
		public List<Exception> ValidatePatientPhysicalData()
		{
			var validate = new ValidatePatientInfo();
			var fieldsToValidate =
				new Dictionary<string, string>
				{
					{Resource.HeightInches, this.HeightInches},
					{Resource.HeightFeet, this.HeightFeet},
					{"Age", this.Age},
					{"Weight", this.Weight}
				};

			var errors = validate.StringToDoubleValidation(fieldsToValidate);
			if (!errors.Any())
			{
				errors.AddRange(this.ValidateHeight());
			}

			return errors;
		}

		/// <summary>
		/// Validate Height of Patient
		/// </summary>
		/// <returns>return errors of not valid age</returns>
		private IEnumerable<Exception> ValidateHeight()
		{
			var errors = new List<Exception>();
			if (!(Convert.ToDouble(this.HeightFeet) >= 5))
			{
				errors.Add(new Exception(Resource.InvalidHeight));
			}

			return errors;
		}
	}
}
