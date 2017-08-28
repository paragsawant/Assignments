using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCalculator.API
{
    public interface IValidator<in T>
    {
        List<Exception> StringToDoubleValidation(T input);
        List<Exception> StringToIntegerValidation(T input);
    }
}
