using System;
using CalorieCalculator;
using CalorieCalculator.API;
using CalorieCalculator.API.Model;
using Autofac;
using Owin;

namespace CalorieCounterTestHarness
{
	class Program
	{
		public static void Main(string[] args)
		{
			var builder = new ContainerBuilder();

			StartUp.Registration(builder);

			var patientPhysicalInfo = new PatientPhysicalInfo(Gender.Male, "33", "5", "10", "250");


			Calorie.Calculate("5", "10", "250", "33", Gender.Male);




			Console.WriteLine("Stats: {0}'{1}\", {2} year old {3} weighing {4} lbs", patientPhysicalInfo.HeightFeet,
				patientPhysicalInfo.HeightInches,
				patientPhysicalInfo.Age,
				Enum.GetName(typeof(Gender), patientPhysicalInfo.Gender),
				patientPhysicalInfo.Weight);

			Console.WriteLine("Calculation: Ideal Weight = {0}, Distance From Ideal Weight = {1}, Calories = {2}", Calorie.IdealWeight,
																												  Calorie.DistanceFromIdealWeight,
																												  Calorie.Calories);

			var patientPersonalInfo = new PatientPersonalInfo("Bob", "Smith", "123", "33", "1234");

			Calorie.Save("123", "33", "1234", "Bob", "Smith", "5", "10", "250", "33");
			Console.WriteLine("Patient: {0} {1}, SSN: {2}-{3}-{4}", patientPersonalInfo.FirstName,
				patientPersonalInfo.LastName,
				patientPersonalInfo.SsnPart1,
				patientPersonalInfo.SsnPart2,
				patientPersonalInfo.SsnPart3);

			var history = Calorie.GetHistory();
			Console.WriteLine();
			Console.WriteLine("Here is your previous history:");
			Console.WriteLine(history);

			Console.WriteLine("Press enter to quit");
			Console.ReadLine();



			Calorie.Calculate(patientPhysicalInfo);
			Calorie.Save(patientPersonalInfo, patientPhysicalInfo);

			TestCase_ValidatePatientPersonalData();
			TestCase_ValidatePatientPhysicalData();
			TestCase_Save();

		}

		private static void TestCase_ValidatePatientPersonalData()
		{
			var patientPersonalInfo = new PatientPersonalInfo("Bob", "Smith", "123", "33", "1234");

			patientPersonalInfo.ValidatePatientPersonalData();
		}

		private static void TestCase_ValidatePatientPhysicalData()
		{
			var patientPhysicalInfo = new PatientPhysicalInfo(Gender.Male, "33", "5", "10", "250");

			patientPhysicalInfo.ValidatePatientPhysicalData();
		}

		private static void TestCase_Save()
		{
			var patientPhysicalInfo = new PatientPhysicalInfo(Gender.Male, "33", "5", "10", "250");
			var patientPersonalInfo = new PatientPersonalInfo("Bob", "Smith", "123", "33", "1234");
			Calorie.Save(patientPersonalInfo,patientPhysicalInfo);

		}

	}
}
