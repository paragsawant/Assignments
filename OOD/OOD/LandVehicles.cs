using OOD.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOD
{
    public abstract class LandVehicles:Vehicles
    {
	    private string LicensePlateNumber { get; set; }

	    protected LandVehicles()
		{
			
		}

	    public override List<ValidationError> ValidateVehicles(Vehicles vehicles)
	    {
		    var errors = base.ValidateVehicles(vehicles);
			errors.AddRange(ValidateLicensePlateNumber(vehicles));
		    return errors;
	    }

	    private static IEnumerable<ValidationError> ValidateLicensePlateNumber(Vehicles vehicles, string country="United State")
		{
			return  new List<ValidationError>();
		}

	}
}
