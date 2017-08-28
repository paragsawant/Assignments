using OOD.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOD
{
    public abstract class SeaVehicles:Vehicles
    {
	    protected SeaVehicles()
	    {
		    
	    }

	    public string NauticalRegistrationNumber { get; set; }

	    public override List<ValidationError> ValidateVehicles(Vehicles vehicles)
	    {
		    var errors =  base.ValidateVehicles(vehicles);
			errors.AddRange(ValidateNauticalRegistrationNumber(vehicles));
		    return errors;
	    }

		/// <summary>
		/// Validation for the Nautical Registration Number 
		/// </summary>
		/// <returns>List of errors in the vehicles validation.</returns>
	    private static IEnumerable<ValidationError> ValidateNauticalRegistrationNumber(Vehicles vehicles)
		{
			//123-124XJHDGSGD
			// Logic to validate the Nautical Number and if it is not valid then add them into the validation other wise return empty ValidationError list.
			return new List<ValidationError>();
		}
	}
}
