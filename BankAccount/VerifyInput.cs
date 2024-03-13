using BankAccountLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp
{
    internal static class VerifyInput
    {
        //Check whether a given string contain only letters and spaces
        public static bool ValidString(string input)
        {
            //If string is empty or null: return false;
            if (string.IsNullOrEmpty(input) == true)
            {
                return false;
            }

            //If string contains only spaces: return false;
            if (input.All(char.IsWhiteSpace))
            {
                return false;
            }

            //If string contains letters only: return true;
            if (input.All(char.IsLetter) == true)
            {
                return true;
            }

            //If string contains letters and spaces: return true;
            if (input.All(c => char.IsLetter(c) == true || char.IsWhiteSpace(c) == true))
            {
                return true;
            }

            //Everithing else: return false;
            return false;
        }

        //Check whether a given string contains only numbers and a maximum of one period '.'
        public static bool ValidDecimal(string input)
        {
            //If string is empty or null: return false;
            if (string.IsNullOrEmpty(input) == true)
            {
                return false;
            }

            //If string contains only spaces: return false;
            if (input.All(char.IsWhiteSpace))
            {
                return false;
            }

            //If string contains digits only: return true;
            if (input.All(char.IsDigit) == true)
            {
                return true;
            }

            //If string has only digits and 0 or 1 decimal points: return true;
            int decimalPointCount = input.Count(c => c == '.');
            if (input.All(c => char.IsDigit(c) || c == '.') && decimalPointCount <= 1)
            {
                return true;
            }

            //return (decimalPointCount <= 1) && input.All(c => char.IsDigit(c) || c == '.');
            return false;
        }

        //Check whether initial deposit is greater than or equal to 1000m
        public static bool AboveAThousand((bool result, decimal validDecimal) conversionResult)
        {
            return conversionResult.validDecimal >= 1000m ? true : false;
        }

        //Check whether deposit amount is greater than 0
        public static decimal ValidDepositAmount()
        {
            Console.WriteLine("How much would you like to deposit?");
            Console.Write("Enter amount: ");
            string textDepositAmount = Console.ReadLine();

            //Validate amount
            bool validNumber = ValidDecimal(textDepositAmount);

            //Convert to decimal
            (bool result, decimal amount) = TypeConversion.StringToDecimal(textDepositAmount);

            //Check if it's greater than 0
            bool positiveAmount = amount > 0 ? true : false;

            while (!validNumber || !result || !positiveAmount)
            {
                Console.WriteLine("Sorry, that was not a valid amount. Deposit amount must be greater than 0.");
                Console.Write("Enter amount: ");
                textDepositAmount = Console.ReadLine();
                validNumber = ValidDecimal(textDepositAmount);
                (result, amount) = TypeConversion.StringToDecimal(textDepositAmount);
                positiveAmount = amount > 0 ? true : false;
            }

            return amount;
        }

        //Check whether transaction note is null, empty, or has only white spaces
        public static bool ValidNote(string input)
        {
            //If string is empty or null: return false;
            if (string.IsNullOrEmpty(input) == true)
            {
                return false;
            }

            //If string contains only spaces: return false;
            if (input.All(char.IsWhiteSpace))
            {
                return false;
            }

            return true;
        }
        public static string ValidTransactionNote()
        {
            //Get a transaction note
            Console.Write("Add a transaction note: ");
            string note = Console.ReadLine();
            //Verify the string
            bool validNote = VerifyInput.ValidNote(note);
            while (validNote == false)
            {
                Console.Write("Note can't be empty. Please enter a valid note: ");
                note = Console.ReadLine();
                validNote = VerifyInput.ValidNote(note);
            }

            return note;
        }

        //Check whether withdrawal will result in a negative balance
        public static decimal ValidWithdrawalAmount(BankAccount userAccount)
        {
            Console.Write("How much would you like to withdraw: ");
            string textAmount = Console.ReadLine();

            //Check if the string is a valid number
            bool validNumber = VerifyInput.ValidDecimal(textAmount);

            //Convert to decimal
            (bool result, decimal validDecimal) = TypeConversion.StringToDecimal(textAmount);

            //Check if it is greater than 0
            bool positiveAmount = validDecimal > 0 ? true : false;

            //Check if it is greater than current account balance
            bool sufficientBalance = validDecimal <= userAccount.Balance ? true : false;

            while (!validNumber || !result || !positiveAmount || !sufficientBalance)
            {
                Console.WriteLine("Please enter an amount not greater than your current balance.");
                Console.WriteLine($"Your current balance is {userAccount.Balance:C}");
                Console.Write("How much would you like to withdraw: ");
                textAmount = Console.ReadLine();
                validNumber = VerifyInput.ValidDecimal(textAmount);
                (result, validDecimal) = TypeConversion.StringToDecimal(textAmount);
                positiveAmount = validDecimal > 0 ? true : false;
                sufficientBalance = validDecimal <= userAccount.Balance ? true : false;
            }

            return validDecimal;
        }

    }
}
