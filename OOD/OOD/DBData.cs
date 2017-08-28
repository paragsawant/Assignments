using OOD.ADO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOD
{
	public class DbData
	{


		public readonly List<VehiclesDbRecord> ListVehiclesDbRecord = new List<VehiclesDbRecord>()
		                              {
			                              new VehiclesDbRecord
			                              {
				                              Make = "nissa",
				                              Model = "altima",
											 StartDate = 2000
			                              },
			                              new VehiclesDbRecord
			                              {
				                              Make = "toyota",
				                              Model = "corolla",
				                              StartDate = 2000
			                              }
									  };
	}
}
