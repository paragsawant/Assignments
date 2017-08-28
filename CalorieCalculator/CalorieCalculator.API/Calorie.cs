using CalorieCalculator.API.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CalorieCalculator.API
{
    public static class Calorie
    {
        public static string DistanceFromIdealWeight { get; private set; }
        public static string IdealWeight { get; private set; }
        public static string Calories { get; private set; }

		public static void Calculate(string heightFeet, string heightInches, string weight, string age, Gender sex)
		{
			var patientPhysicalInfo = new PatientPhysicalInfo(sex,age,heightFeet,heightInches,weight);
			Calculate(patientPhysicalInfo);
		}

	    public static void Save(string patientSsnPart1, string patientSsnPart2, string patientSsnPart3, string patientFirstName,
		    string patientLastName, string heightFeet, string heightInches, string weight, string age)
	    {
			var patientPhysicalInfo = new PatientPhysicalInfo(age, heightFeet, heightInches, weight);
		    var patientPersonalInfo = new PatientPersonalInfo(patientFirstName, patientLastName, patientSsnPart1,
			    patientSsnPart2, patientSsnPart3);
		    Save(patientPersonalInfo, patientPhysicalInfo);

	    }


		public static void Calculate(PatientPhysicalInfo patientPhysicalInfo)
        {
            //Clear old results
            DistanceFromIdealWeight = string.Empty;
            IdealWeight = string.Empty;
            Calories = string.Empty;
            /* Validate User Input: */
            //Validate height (feet) is numeric value


            #region Input Validation


            var errors = patientPhysicalInfo.ValidatePatientPhysicalData();
            if (errors.Any())
            {
                var errorMessage = new StringBuilder();
                foreach (var error in errors)
                {
                    errorMessage.Append(error);
                }

                throw new Exception(errorMessage.ToString());
            }


            #endregion Input Validation


            #region Calories Calculation
            /*End validation*/

            Calories = HealthCalculator.GetCalories(patientPhysicalInfo);

            IdealWeight = HealthCalculator.GetIdealWeight(patientPhysicalInfo);
            #endregion Calories Calculation


            #region Calculate and display distance from ideal weight
            //Calculate and display distance from ideal weight
            DistanceFromIdealWeight = HealthCalculator.GetDistanceFromIdealWeight(IdealWeight,patientPhysicalInfo.Weight);
            #endregion

        }

        public static void Save(PatientPersonalInfo patientPersonalInfo, PatientPhysicalInfo patientPhysicalInfo)
        {


            var patientPhysicalDataValidation = true;
            var patientPersonalDataValidation = true;


            #region Patient Personal Input Data Validation

            var errors = patientPersonalInfo.ValidatePatientPersonalData();
            if (errors.Any())
            {
                patientPersonalDataValidation = false;
                foreach (var error in errors)
                {
                    Console.WriteLine(error.Message);
                }
            }

            #endregion Patient Personal Input Data Validation


            #region Patient General Data Validation

            errors = patientPhysicalInfo.ValidatePatientPhysicalData();
            if (errors.Any())
            {
	            patientPhysicalDataValidation = false;
                foreach (var error in errors)
                {
                    Console.WriteLine(error.Message);
                }
            }

            /*End validation*/


            #endregion Patient General Data Validation


            if (patientPersonalDataValidation == false || patientPhysicalDataValidation == false)
            {
                throw new Exception(Resource.InvalidOutput);
            }

            bool fileCreated = true;

            #region XML File Generation and Data Writing

            XmlDocument document = new XmlDocument();
            try
            {
                var file = GetAssemblyDirectory() + @"\PatientsHistory.xml";
                if (File.Exists(file))
                {
                    document.Load(file);
                }
                else
                {
                    fileCreated = false;
                }

            }
            catch (FileNotFoundException ee)
            {
                throw ee;
            }

            
            if (!fileCreated)
            {
                document.LoadXml(CaloriesHelper.ConvertPatientInfoToPatientHistory(patientPersonalInfo,patientPhysicalInfo));
            }
            else
            {
                //Search for existing node for this patient
                XmlNode patientNode = null;
                foreach (XmlNode node in document.FirstChild.ChildNodes)
                {
                    foreach (XmlAttribute attrib in node.Attributes)
                    {
                        //We will use SSN to uniquely identify patient
                        if ((attrib.Name == "ssn") & (attrib.Value == patientPersonalInfo.SsnPart1 + "-" + patientPersonalInfo.SsnPart2 + "-" + patientPersonalInfo.SsnPart3))
                        {
                            patientNode = node;
                        }
                    }
                }
                if (patientNode == null)
                {
                    //just clone any patient node and use it for the new patient node
                    XmlNode thisPatient = CaloriesHelper.AddPatientNode(document, patientPersonalInfo);
                    XmlNode measurement = CaloriesHelper.AddMeasurementNode(document,thisPatient, patientPhysicalInfo, Calories, IdealWeight, DistanceFromIdealWeight,false);
                    thisPatient.AppendChild(measurement);
                    document.FirstChild.AppendChild(thisPatient);
                }
                else
                {
                    //If patient node found just clone any measurement
                    //and use it for the new measurement
                    XmlNode measurement = CaloriesHelper.AddMeasurementNode(document,patientNode, patientPhysicalInfo, Calories, IdealWeight, DistanceFromIdealWeight,true);
                    patientNode.AppendChild(measurement);
                }
            }
            //Finally, save the xml to file
            document.Save(GetAssemblyDirectory() + @"\PatientsHistory.xml");
            #endregion XML File Generation and Data Writing
        }


        public static string GetAssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }


        public static string GetHistory()
        {
            return File.ReadAllText(GetAssemblyDirectory() + @"\PatientsHistory.xml");
        }
    }
}

