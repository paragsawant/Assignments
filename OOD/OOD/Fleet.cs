using System;
using System.Collections.Generic;
using System.Text;

namespace OOD
{
    public class Fleet
    {
	    public string NickName { get; set; }
		public List<Vehicles> Vehicles { get; set; }
		public string Country { get; set; }

		Fleet( string nickName,List<Vehicles> vehiclesList)
		{
			this.Vehicles = vehiclesList;
			this.NickName = nickName;
		}

	    Fleet(string nickName, List<Vehicles> vehiclesList, string country)
	    {
		    this.Vehicles = vehiclesList;
		    this.NickName = nickName;
		    this.Country = country;
	    }
	}
}
