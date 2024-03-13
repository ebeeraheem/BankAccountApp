using BankAccountLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp
{
    internal static class PerformTransaction
    {
        public static int AllTransactions(BankAccount userAccount)
        {
            Console.Clear();
            Console.WriteLine($"Dear {userAccount.AccountName}, Welcome to Last Bank.");
            Console.WriteLine("1. Make a deposit.");
            Console.WriteLine("2. Make a withdrawal.");
            Console.WriteLine("3. View account balance.");
            Console.WriteLine("4. View account number.");
            Console.WriteLine("5. Print account statement.");
            Console.WriteLine();
            Console.Write("What would you like to do today: ");
            string response = Console.ReadLine();

            bool validNumber = int.TryParse(response, out int result);
            bool validRange = result > 0 && result <= 5 ? true : false;

            while (validNumber == false || validRange == false)
            {
                Console.WriteLine("That was an invalid choice. Please enter a number from 1 - 5.");
                Console.Write("What would you like to do today: ");
                response = Console.ReadLine();

                validNumber = int.TryParse(response, out result);
                validRange = result > 0 && result <= 5 ? true : false;
            }

            return result;
        }
        public static void Deposit(BankAccount userAccount)
        {            
            decimal depositAmount = VerifyInput.ValidDepositAmount();                      
            string transactionNote = VerifyInput.ValidTransactionNote();

            userAccount.MakeDeposit(depositAmount, transactionNote);

            Console.WriteLine("Transaction successful.");
            Console.WriteLine();
        }
        public static void Withdrawal(BankAccount userAccount)
        {
            decimal withdrawalAmount = VerifyInput.ValidWithdrawalAmount(userAccount);
            string transactionNote = VerifyInput.ValidTransactionNote();

            userAccount.MakeWithdrawal(withdrawalAmount, transactionNote);

            Console.WriteLine("Transaction successful.");
            Console.WriteLine();
        }
        public static void PrintStatement(BankAccount userAccount)
        {
            StringBuilder accountStatement = userAccount.Statement();
            Console.WriteLine(accountStatement.ToString());
        }
        public static void TransactionChoice(int transactionChoice, BankAccount userAccount)
        {
            switch (transactionChoice)
            {
                case 1:
                    Console.Clear();
                    Deposit(userAccount);
                    break;
                case 2:
                    Console.Clear();
                    Withdrawal(userAccount);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine($"Your account balance is: {userAccount.Balance:C}");
                    Console.WriteLine();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine($"Your account number is: {userAccount.Number}");
                    Console.WriteLine();
                    break;
                case 5:
                    Console.Clear();
                    PrintStatement(userAccount);
                    break;
                default:
                    break;
            }
        }
        public static void NewTransaction(BankAccount userAccount)
        {
            string transactionResponse = String.Empty;
            do
            {
                //Ask for a transaction choice
                int transactionChoice = PerformTransaction.AllTransactions(userAccount);

                //Execute the selected transaction
                PerformTransaction.TransactionChoice(transactionChoice, userAccount);

                Console.Write("Would you like to perform another transaction (yes/no): ");
                transactionResponse = Console.ReadLine();
            } while (transactionResponse.ToLower() == "yes");
        }
    }
}
