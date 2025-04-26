using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt for percentage
        Console.Write("What is your grade percentage? ");
        int percentage = int.Parse(Console.ReadLine());

        // Determine base letter grade
        string letter;
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine plus/minus
        int lastDigit = percentage % 10;
        string sign = "";

        if (letter == "A")
        {
            // No A+, only A or A-
            if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "F")
        {
            // No F+ or F-
            sign = "";
        }
        else
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Output final grade
        Console.WriteLine($"Your letter grade is {letter}{sign}.");

        // Pass/fail message (70 to pass)
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Better luck next time—keep studying and you’ll get it!");
        }
    }
}
