using OOD.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOD
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class Vehicles
	{
	/// <summary>
	/// 
	/// </summary>
		public int Year { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Model { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Make { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string VINNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public Vehicles()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="year"></param>
		/// <param name="model"></param>
		/// <param name="make"></param>
		public Vehicles(int year, string model, string make)
		{
			this.Make = make;
			this.Model = model;
			this.Year = year;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="year"></param>
		/// <param name="model"></param>
		/// <param name="make"></param>
		/// <param name="vinNumber"></param>
		public Vehicles(int year, string model, string make, string vinNumber)
		{
			this.Make = make;
			this.Model = model;
			this.Year = year;
			this.VINNumber = vinNumber;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual List<ValidationError> ValidateVehicles(Vehicles vehicles)
		{
			var validationErrors = new List<ValidationError>();
			Makes make;
			if (!Enum.TryParse<Makes>(this.Make, out make))
			{
				validationErrors.Add(new ValidationError(nameof(this.Make), "Invalid Make."));
			}

			if (this.Year < DateTime.MinValue.Year || this.Year > DateTime.MaxValue.Year)
			{
				validationErrors.Add(new ValidationError(nameof(this.Year), "Invalid Year."));
			}

			// Data Base call to validate if the combination of the Year , Make and Made is correct 
			// I am using list to verify if that is in the list
			var dbData = new DbData();
			var records = dbData.ListVehiclesDbRecord;
			if (records.Where(vehicle => vehicle.Make == this.Make && vehicle.Model == this.Model).Any(vehicle => (vehicle.EndDate != null && vehicle.EndDate < this.Year) || vehicle.StartDate > this.Year))
			{
				validationErrors.Add(new ValidationError("", $"Invalid Combination of Make {this.Make} , Model {this.Model}, Year{this.Year}."));
			}

			validationErrors.AddRange(this.ValidateVINNumber(vehicles));

			return validationErrors;
		}

		/// <summary>
		/// Validation for the VIn Number 
		/// </summary>
		/// <returns></returns>
		private IEnumerable<ValidationError> ValidateVINNumber(Vehicles vehicles)
		{
		//logic to validate the VIN Number, if it is not valid format add errors to validation errors and return the list.
			return new List<ValidationError>();
		}
	}
}
