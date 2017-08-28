using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCalculator.API.Model
{
	/// <summary>
	/// Patient Personal Information
	/// </summary>
	public class PatientPersonalInfo
	{
		/// <summary>
		/// Constructor of Patient information
		/// </summary>
		/// <param name="firstName">First Name of Patient</param>
		/// <param name="lastName">Last Name of Patient</param>
		/// <param name="ssnPart1">SSN Part 1 of Patient</param>
		/// <param name="ssnPart2">SSN Part 2 of Patient</param>
		/// <param name="ssnPart3">SSN Part 3 of Patient</param>
		public PatientPersonalInfo(string firstName, string lastName, string ssnPart1, string ssnPart2, string ssnPart3)
		{

			this.FirstName = firstName;
			this.LastName = lastName;
			this.SsnPart1 = ssnPart1;
			this.SsnPart2 = ssnPart2;
			this.SsnPart2 = ssnPart2;
			this.SsnPart3 = ssnPart3;
		}

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string SsnPart1 { get; set; }

		public string SsnPart2 { get; set; }

		public string SsnPart3 { get; set; }

		/// <summary>
		/// Validate Personal Information
		/// </summary>
		/// <returns>Error if not valid</returns>
		public List<Exception> ValidatePatientPersonalData()
		{
			var validate = new ValidatePatientInfo();
			var fieldsToValidate =
				new Dictionary<string, string>
				{
					{Resource.InvalidSSNPart1, this.SsnPart1},
					{Resource.InvalidSSNPart2, this.SsnPart2},
					{Resource.InvalidSSNPart3, this.SsnPart3}
				};

			var messages = validate.StringToIntegerValidation(fieldsToValidate);
			if (this.FirstName.Trim().Length < 1)
			{
				messages.Add(new Exception(Resource.InvalidFirstName));
			}

			if (this.LastName.Trim().Length < 1)
			{
				messages.Add(new Exception(Resource.InvalidLastName));
			}

			return messages;
		}
	}
}
