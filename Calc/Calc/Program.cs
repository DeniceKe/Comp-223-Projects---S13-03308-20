using System;

class Calculator
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Simple Calculator");
            Console.WriteLine("------------------");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Exit");

            Console.Write("Select an operation (1-5): ");
            string choice = Console.ReadLine();

            if (choice == "5")
            {
                Console.WriteLine("Exiting calculator. Goodbye!");
                break;
            }

            if (!IsValidChoice(choice))
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                continue;
            }

            double num1, num2;
            Console.Write("Enter the first number: ");
            if (!double.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
                continue;
            }

            Console.Write("Enter the second number: ");
            if (!double.TryParse(Console.ReadLine(), out num2))
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
                continue;
            }

            try
            {
                double result = PerformOperation(choice, num1, num2);
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();
        }
    }

    static bool IsValidChoice(string choice)
    {
        return choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5";
    }

    static double PerformOperation(string choice, double num1, double num2)
    {
        switch (choice)
        {
            case "1":
                return num1 + num2;
            case "2":
                return num1 - num2;
            case "3":
                return num1 * num2;
            case "4":
                if (num2 == 0)
                {
                    throw new ArgumentException("Cannot divide by zero.");
                }
                return num1 / num2;
            default:
                throw new InvalidOperationException("Invalid operation");
        }
    }
}
