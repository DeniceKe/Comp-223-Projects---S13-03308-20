using System;

class WaterBillCalculator
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Water Bill Calculator!");

        // Get user input for water consumption
        double waterConsumption = GetUserInput("Enter water consumption in cubic meters: ");

        // Get user input for usage type (residential, commercial, or industrial)
        char usageType = GetUsageType();

        // Get rate based on usage type
        double rate = GetRate(usageType);

        // Calculate water bill
        double totalBill = CalculateWaterBill(waterConsumption, rate);

        // Display the monthly water bill amount
        DisplayBillDetails(waterConsumption, rate, totalBill);

        Console.WriteLine("Thank you for using the Water Bill Calculator!");
    }

    static double GetUserInput(string prompt)
    {
        double userInput;
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out userInput) && userInput >= 0)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a non-negative number.");
            }
        }
    }

    static char GetUsageType()
    {
        char usageType;
        while (true)
        {
            Console.Write("Enter usage type (R for residential, C for commercial, I for industrial): ");
            if (char.TryParse(Console.ReadLine().ToUpper(), out usageType) && (usageType == 'R' || usageType == 'C' || usageType == 'I'))
            {
                return usageType;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'R' for residential, 'C' for commercial, or 'I' for industrial.");
            }
        }
    }

    static double GetRate(char usageType)
    {
        // Rate structures based on the provided information
        switch (usageType)
        {
            case 'R':
                return 25.00; // Residential rate per cubic meter
            case 'C':
                return 30.50; // Commercial rate per cubic meter
            case 'I':
                return 35.75; // Industrial rate per cubic meter
            default:
                return 0.0;   // Default to 0 if the usage type is not recognized
        }
    }

    static double CalculateWaterBill(double waterConsumption, double rate)
    {
        return waterConsumption * rate;
    }

    static void DisplayBillDetails(double waterConsumption, double rate, double totalBill)
    {
        Console.WriteLine("\nBill Details:");
        Console.WriteLine($"Water Consumption: {waterConsumption} cubic meters");
        Console.WriteLine($"Rate: KES {rate:F2} per cubic meter");
        Console.WriteLine($"Total Bill: KES {totalBill:F2}");
    }
}

