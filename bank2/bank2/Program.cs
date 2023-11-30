using System;
using System.Collections.Generic;

class BankAccount
{
    public int AccountNumber { get; }
    public string AccountHolder { get; set; }
    public double Balance { get; set; }

    public BankAccount(int accountNumber, string accountHolder, double initialBalance)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        Balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited ${amount}. New balance: ${Balance}");
        }
        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrew ${amount}. New balance: ${Balance}");
        }
        else
        {
            Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
        }
    }

    public void InquireBalance()
    {
        Console.WriteLine($"Account balance for {AccountHolder} (Account #{AccountNumber}): ${Balance}");
    }
}

class BankAccountManagementSystem
{
    private static List<BankAccount> accounts = new List<BankAccount>();
    private static int accountCounter = 1;

    static void Main()
    {
        Console.WriteLine("Welcome to the Bank Account Management System!");

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Inquire Balance");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateAccount();
                    break;
                case "2":
                    PerformTransaction(TransactionType.Deposit);
                    break;
                case "3":
                    PerformTransaction(TransactionType.Withdraw);
                    break;
                case "4":
                    InquireBalance();
                    break;
                case "5":
                    Console.WriteLine("Exiting the Bank Account Management System. Thank you!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }

    static void CreateAccount()
    {
        Console.Write("Enter account holder's name: ");
        string accountHolder = Console.ReadLine();

        Console.Write("Enter initial balance: ");
        double initialBalance;
        while (!double.TryParse(Console.ReadLine(), out initialBalance) || initialBalance < 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid initial balance.");
        }

        BankAccount account = new BankAccount(accountCounter++, accountHolder, initialBalance);
        accounts.Add(account);

        Console.WriteLine($"Account created successfully! Account #{account.AccountNumber}");
    }

    static void PerformTransaction(TransactionType transactionType)
    {
        Console.Write("Enter account number: ");
        int accountNumber;
        while (!int.TryParse(Console.ReadLine(), out accountNumber) || !AccountExists(accountNumber))
        {
            Console.WriteLine("Invalid account number. Please enter a valid account number.");
        }

        BankAccount account = accounts.Find(a => a.AccountNumber == accountNumber);

        Console.Write($"Enter {transactionType.ToString().ToLower()} amount: ");
        double amount;
        while (!double.TryParse(Console.ReadLine(), out amount) || amount < 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid amount.");
        }

        switch (transactionType)
        {
            case TransactionType.Deposit:
                account.Deposit(amount);
                break;
            case TransactionType.Withdraw:
                account.Withdraw(amount);
                break;
        }
    }

    static void InquireBalance()
    {
        Console.Write("Enter account number: ");
        int accountNumber;
        while (!int.TryParse(Console.ReadLine(), out accountNumber) || !AccountExists(accountNumber))
        {
            Console.WriteLine("Invalid account number. Please enter a valid account number.");
        }

        BankAccount account = accounts.Find(a => a.AccountNumber == accountNumber);
        account.InquireBalance();
    }

    static bool AccountExists(int accountNumber)
    {
        return accounts.Exists(a => a.AccountNumber == accountNumber);
    }

    enum TransactionType
    {
        Deposit,
        Withdraw
    }
}
