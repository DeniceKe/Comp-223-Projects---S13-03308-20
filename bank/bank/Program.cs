using System;
using System.Collections.Generic;

class BankAccount
{
    public string AccountNumber { get; }
    public string AccountHolder { get; set; }
    public decimal Balance { get; set; }

    public BankAccount(string accountHolder, decimal initialBalance)
    {
        AccountNumber = GenerateAccountNumber();
        AccountHolder = accountHolder;
        Balance = initialBalance;
    }

    private string GenerateAccountNumber()
    {
        // Generate a unique account number (you may use a more sophisticated method)
        return Guid.NewGuid().ToString().Substring(0, 8);
    }
}

class BankAccountManagementSystem
{
    private List<BankAccount> accounts;

    public BankAccountManagementSystem()
    {
        accounts = new List<BankAccount>();
    }

    public void CreateAccount()
    {
        Console.Write("Enter account holder's name: ");
        string accountHolder = Console.ReadLine();

        Console.Write("Enter initial balance: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal initialBalance))
        {
            BankAccount account = new BankAccount(accountHolder, initialBalance);
            accounts.Add(account);
            Console.WriteLine($"Account created successfully. Account Number: {account.AccountNumber}");
        }
        else
        {
            Console.WriteLine("Invalid initial balance. Account creation failed.");
        }
    }

    public void MakeDeposit()
    {
        Console.Write("Enter account number: ");
        string accountNumber = Console.ReadLine();

        BankAccount account = FindAccount(accountNumber);
        if (account != null)
        {
            Console.Write("Enter deposit amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
            {
                account.Balance += depositAmount;
                Console.WriteLine($"Deposit successful. New balance: {account.Balance:C}");
            }
            else
            {
                Console.WriteLine("Invalid deposit amount.");
            }
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    public void MakeWithdrawal()
    {
        Console.Write("Enter account number: ");
        string accountNumber = Console.ReadLine();

        BankAccount account = FindAccount(accountNumber);
        if (account != null)
        {
            Console.Write("Enter withdrawal amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal withdrawalAmount) && withdrawalAmount <= account.Balance)
            {
                account.Balance -= withdrawalAmount;
                Console.WriteLine($"Withdrawal successful. New balance: {account.Balance:C}");
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
            }
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    public void InquireBalance()
    {
        Console.Write("Enter account number: ");
        string accountNumber = Console.ReadLine();

        BankAccount account = FindAccount(accountNumber);
        if (account != null)
        {
            Console.WriteLine($"Account balance for {account.AccountHolder}: {account.Balance:C}");
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    public void DisplayMenu()
    {
        Console.WriteLine("\nBank Account Management System Menu:");
        Console.WriteLine("1. Create Account");
        Console.WriteLine("2. Make Deposit");
        Console.WriteLine("3. Make Withdrawal");
        Console.WriteLine("4. Inquire Balance");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice (1-5): ");
    }

    private BankAccount FindAccount(string accountNumber)
    {
        return accounts.Find(account => account.AccountNumber == accountNumber);
    }

    public void Run()
    {
        int choice;

        do
        {
            DisplayMenu();

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        MakeDeposit();
                        break;
                    case 3:
                        MakeWithdrawal();
                        break;
                    case 4:
                        InquireBalance();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the Bank Account Management System. Thank you!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

        } while (choice != 5);
    }
}

class Program
{
    static void Main()
    {
        BankAccountManagementSystem bankSystem = new BankAccountManagementSystem();
        bankSystem.Run();
    }
}
