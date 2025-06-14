using System;
using System.Threading;

class Program
{
    static void Main()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App Menu");
            Console.WriteLine("1) Breathing Session");
            Console.WriteLine("2) Reflection Session");
            Console.WriteLine("3) Listing Session");
            Console.WriteLine("4) Exit");
            Console.Write("Select an option: ");

            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            Activity activity = choice switch
            {
                '1' => new BreathingActivity(),
                '2' => new ReflectionActivity(),
                '3' => new ListingActivity(),
                '4' => null,
                _   => null
            };

            if (activity != null)
            {
                activity.Run();
                Console.WriteLine("Press any key to return...");
                Console.ReadKey(true);
            }
            else if (choice == '4')
                running = false;
            else
            {
                Console.WriteLine("Invalid choice—try again.");
                ShowQuickDots();  // small feedback
            }
        }
    }

    // quick & dirty loader animation for invalid input
    private static void ShowQuickDots()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.Write(".");
            Thread.Sleep(400);
        }
        Console.WriteLine();
    }
}

// EXTRA: Could log user durations to a file for progress tracking.
