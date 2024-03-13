using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp
{
    internal static class ConsoleInput
    {
        //Get a string from the console and return it
        public static string GetString(string message)
        {
            Console.Write(message);
            string output = Console.ReadLine();

            return output;
        }
    }
}
