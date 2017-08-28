using CalorieCalculator.API.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CalorieCalculator.API
{
    public static class CaloriesHelper
    {
        public static string ConvertPatientInfoToPatientHistory(PatientPersonalInfo patientInfo,PatientPhysicalInfo patientPhysicalInfo)
        {
            var patientsHistory = new PatientsHistory();
            patientsHistory.Items = new PatientsHistoryPatient[] {new PatientsHistoryPatient()
            {
                firstName = patientInfo.FirstName,
                lastName = patientInfo.LastName,
                ssn = patientInfo.SsnPart1 + '-' + patientInfo.SsnPart2 + '-' + patientInfo.SsnPart3,
                measurement = new[] { new PatientsHistoryPatientMeasurement()
                {
                    age = patientPhysicalInfo.Age,
                    height = ((Convert.ToInt32(patientPhysicalInfo.HeightFeet) * 12) + patientPhysicalInfo.HeightInches).ToString(),
                    weight = patientPhysicalInfo.Weight,
                    idealBodyWeight = HealthCalculator.GetIdealWeight(patientPhysicalInfo),
                    dailyCaloriesRecommended = HealthCalculator.GetCalories(patientPhysicalInfo),
                    distanceFromIdealWeight = HealthCalculator.GetDistanceFromIdealWeight(HealthCalculator.GetIdealWeight(patientPhysicalInfo),patientPhysicalInfo.Weight),
                    date = DateTime.Now.ToString(CultureInfo.InvariantCulture)
                } }
            }
            };

            return ConvertPatientHistoryToXml(patientsHistory);
        }

        private static string ConvertPatientHistoryToXml(PatientsHistory patientsHistory)
        {
	        var settings = new XmlWriterSettings {OmitXmlDeclaration = true};
	        var ser = new XmlSerializer(typeof(PatientsHistory));
            var m = new MemoryStream();
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            ser.Serialize(m, patientsHistory, ns);
            m.Position = 0;
            var xml = new StreamReader(m).ReadToEnd();
            xml = RemoveXmlDefinition(xml);
            return xml;
        }

        private static string RemoveXmlDefinition(string xml)
        {
            var xdoc = XDocument.Parse(xml);
            xdoc.Declaration = null;

            return xdoc.ToString();
        }

        public static XmlNode AddMeasurementNode(XmlDocument document , XmlNode patientNode, PatientPhysicalInfo patientPhysicalInfo, string calories, string idealWeight, string distanceFromIdealWeight,bool ispatientNode)
        {
            var measurement = ispatientNode ? patientNode.FirstChild.CloneNode(true) : document.DocumentElement.FirstChild["measurement"].CloneNode(true);
            measurement.Attributes["date"].Value = DateTime.Now.ToString();
            measurement["height"].FirstChild.Value = ((Convert.ToInt32(patientPhysicalInfo.HeightFeet) * 12) + Convert.ToInt32(patientPhysicalInfo.HeightInches)).ToString();
            measurement["weight"].FirstChild.Value = patientPhysicalInfo.Weight;
            measurement["age"].FirstChild.Value = patientPhysicalInfo.Age;
            measurement["dailyCaloriesRecommended"].FirstChild.Value = calories;
            measurement["idealBodyWeight"].FirstChild.Value = idealWeight;
            measurement["distanceFromIdealWeight"].FirstChild.Value = distanceFromIdealWeight;
            return measurement;
        }

        public static XmlNode AddPatientNode(XmlDocument document , PatientPersonalInfo patientPersonalInfo)
        {
            var patientNode =
                    document.DocumentElement.FirstChild.CloneNode(false);
            patientNode.Attributes["ssn"].Value = patientPersonalInfo.SsnPart1 + "-" + patientPersonalInfo.SsnPart2 + "-" + patientPersonalInfo.SsnPart3;
            patientNode.Attributes["firstName"].Value = patientPersonalInfo.FirstName;
            patientNode.Attributes["lastName"].Value = patientPersonalInfo.LastName;
            return patientNode;
        }

    }
}
