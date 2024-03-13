using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp
{
    internal static class TypeConversion
    {
        //Convert a string number to a decimal. Return a boolean and the result of the conversion
        public static (bool result, decimal validDecimal) StringToDecimal(string input)
        {
            bool result = decimal.TryParse(input, out decimal validDecimal);

            return (result, validDecimal);
        }
    }
}
