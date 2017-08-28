using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CalorieCalculator.API.Model
{
	/// <summary>
	/// Patient History
	/// </summary>
	[System.SerializableAttribute()]
	public partial class PatientsHistory
	{

		private PatientsHistoryPatient[] itemsField;

		/// <remarks/>
		[XmlElementAttribute("patient", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public PatientsHistoryPatient[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	public partial class PatientsHistoryPatient
	{

		private PatientsHistoryPatientMeasurement[] measurementField;

		private string ssnField;

		private string firstNameField;

		private string lastNameField;

		[System.Xml.Serialization.XmlElementAttribute("measurement", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public PatientsHistoryPatientMeasurement[] measurement
		{
			get
			{
				return this.measurementField;
			}
			set
			{
				this.measurementField = value;
			}
		}

		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string ssn
		{
			get
			{
				return this.ssnField;
			}
			set
			{
				this.ssnField = value;
			}
		}

		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string firstName
		{
			get
			{
				return this.firstNameField;
			}
			set
			{
				this.firstNameField = value;
			}
		}

		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string lastName
		{
			get
			{
				return this.lastNameField;
			}
			set
			{
				this.lastNameField = value;
			}
		}
	}

	[System.SerializableAttribute()]
	public partial class PatientsHistoryPatientMeasurement
	{

		private string heightField;

		private string weightField;

		private string ageField;

		private string dailyCaloriesRecommendedField;

		private string idealBodyWeightField;

		private string distanceFromIdealWeightField;

		private string dateField;


		public string height
		{
			get
			{
				return this.heightField;
			}
			set
			{
				this.heightField = value;
			}
		}


		public string weight
		{
			get
			{
				return this.weightField;
			}
			set
			{
				this.weightField = value;
			}
		}


		public string age
		{
			get
			{
				return this.ageField;
			}
			set
			{
				this.ageField = value;
			}
		}


		public string dailyCaloriesRecommended
		{
			get
			{
				return this.dailyCaloriesRecommendedField;
			}
			set
			{
				this.dailyCaloriesRecommendedField = value;
			}
		}

		public string idealBodyWeight
		{
			get
			{
				return this.idealBodyWeightField;
			}
			set
			{
				this.idealBodyWeightField = value;
			}
		}

		public string distanceFromIdealWeight
		{
			get
			{
				return this.distanceFromIdealWeightField;
			}
			set
			{
				this.distanceFromIdealWeightField = value;
			}
		}

		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string date
		{
			get
			{
				return this.dateField;
			}
			set
			{
				this.dateField = value;
			}
		}
	}

}
