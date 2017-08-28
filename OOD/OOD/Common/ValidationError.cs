using System;
using System.Collections.Generic;
using System.Text;

namespace OOD.Common
{
    public class ValidationError
    {
	    private string EntityName { get; set; }
	    private string ErrorMessage { get; set; }

		public ValidationError(string entityName,string errorMessage)
		{
			this.EntityName = entityName;
			this.ErrorMessage = errorMessage;
		}
    }
}
