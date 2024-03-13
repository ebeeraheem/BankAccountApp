using BankAccountLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp
{
    internal static class CreateAccount
    {
        //Get and return the account owner's name
        public static string AccountOwnersName()
        {
            Console.Write("Enter your full name: ");
            string accountHoldersName = Console.ReadLine();

            //Check whether it contains only letters and white spaces
            bool validName = VerifyInput.ValidString(accountHoldersName);

            //If it's not, keep asking
            while (validName == false)
            {
                Console.WriteLine("Thaw was an invalid name.");
                Console.Write("Please enter your full name without any special characters or numbers: ");
                accountHoldersName = Console.ReadLine();
                validName = VerifyInput.ValidString(accountHoldersName);
            }

            //This will only return a valid string
            //Example "Suleiman" or "Ibrahim Suleiman"
            return accountHoldersName;
        }

        //Get an initial deposit of more than 1000m and return it
        public static decimal InitialDeposit()
        {
            Console.Write("How much would you like to deposit: ");
            string textInitialDeposit = Console.ReadLine();

            //check if it is a valid number
            bool validNumber = VerifyInput.ValidDecimal(textInitialDeposit);

            //Convert the number to a decimal
            (bool result, decimal validDecimal) conversionResult = 
                TypeConversion.StringToDecimal(textInitialDeposit);

            //Check if it is above 1000m
            bool validDeposit = VerifyInput.AboveAThousand(conversionResult);

            //If it's not a valid number or if it is below 1000m, keep asking
            while (!validNumber || !conversionResult.result || !validDeposit)
            {
                Console.WriteLine("That was an invalid input");
                Console.Write("Please enter a number greater than or equal to 1000: ");
                textInitialDeposit = Console.ReadLine();

                validNumber = VerifyInput.ValidDecimal(textInitialDeposit);
                conversionResult = TypeConversion.StringToDecimal(textInitialDeposit);
                validDeposit = VerifyInput.AboveAThousand(conversionResult);
            }

            decimal initialDeposit = conversionResult.validDecimal;

            //This will only return a decimal greater than or equal to 1000m
            return initialDeposit;
        }

        //Create an account with the above details - Not done yet!!
        public static BankAccount NewAccount()
        {
            Console.WriteLine("Enter your name and deposit a minimum of $1,000.00 to open an account.");
            string name = CreateAccount.AccountOwnersName();
            decimal initialDeposit = CreateAccount.InitialDeposit();

            BankAccount newAccount = new BankAccount(name, initialDeposit);

            return newAccount;
        }
    }
}
