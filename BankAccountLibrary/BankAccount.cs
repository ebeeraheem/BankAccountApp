using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLibrary
{
    public class BankAccount
    {
        //Setting the seed as a static field ensures that...
        //each time an account is created, a new number is generated
        private static int _accountNumberSeed = 1234567890;

        public string AccountName { get; set; }
        public string Number {  get; }
        public decimal Balance 
        { 
            get
            {
                decimal balance = 0;
                foreach (Transactions transaction in _allTransactions)
                {
                    balance += transaction.Amount;
                }
                return balance;
            }
        }
                
        public BankAccount(string name, decimal initialBalance)
        {
            if (initialBalance <= 0)
            {
                throw new ArgumentOutOfRangeException("initialBalance", "Initial balance must be greater than or equal to 1000.");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Name must not be empty or contain only spaces.");
            }
            AccountName = name;            
            MakeDeposit(initialBalance, "Opening balance");

            Number = _accountNumberSeed.ToString();
            _accountNumberSeed++;
        }


        private List<Transactions> _allTransactions = new List<Transactions>();

        //Make a deposit by adding the amount and a note about the transaction
        public void MakeDeposit(decimal amount, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Deposit amount must be positive.");
            }
            if (string.IsNullOrEmpty(note))
            {
                throw new ArgumentNullException("note", "Note must not be empty or contain only spaces.");
            }
            DateTime transactionTime = DateTime.Now;
            Transactions deposit = new Transactions(amount, transactionTime, note);
            _allTransactions.Add(deposit);
        }

        //Make a withdrawal by adding the amount and a note about the transaction
        public void MakeWithdrawal(decimal amount, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("amount", "Withdrawal amount must be positive.");
            }
            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException("amount", "Withdrawal cannot result in a negative balance.");
            }
            if (string.IsNullOrEmpty(note))
            {
                throw new ArgumentNullException("note", "Note must not be empty or contain only spaces.");
            }
            DateTime transactionTime = DateTime.Now;
            Transactions withdrawal = new Transactions(-amount, transactionTime, note);
            _allTransactions.Add(withdrawal);
        }

        public StringBuilder Statement()
        {
            StringBuilder transactions = new StringBuilder();
            transactions.AppendLine("DATE\t\t\t\tAMOUNT\t\tNOTES");
            
            foreach (Transactions transaction in _allTransactions)
            {
                transactions.AppendLine($"{transaction.Date:g}\t\t{transaction.Amount}\t\t{transaction.Notes}");
            }

            return transactions;
        }
    }
}
