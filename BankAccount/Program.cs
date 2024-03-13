


// BANK ACCOUNT APP
using BankAccountApp;
using BankAccountLibrary;


// Each account should have a unique 10-digit account number - DONE
//?Define the account type - ie. single or joint account
// Store the name(s) of the owner(s) - DONE
// Ability to check balance - DONE
// Make deposits - DONE
// Make withdrawals - DONE
// The initial balance must be positive. - DONE
// Withdrawals can't result in a negative balance. - DONE
// View account balance - DONE
// View account number - DONE
// View statement of account - DONE

// UPCOMING FEATURES
// Allow users to request overdraft
// Transaction history for the last three months should determine the amount of overdraft available
//?User must pay overdraft before making future transactions



//Welcome new user
ConsoleOutput.WelcomeToBank();

//Create an account
BankAccount userAccount = CreateAccount.NewAccount();

//Perform transaction
PerformTransaction.NewTransaction(userAccount);

//Thank user
Console.WriteLine("Thank you for banking with us.");

