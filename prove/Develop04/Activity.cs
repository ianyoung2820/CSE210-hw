using System;
using System.Threading;

public abstract class Activity
{
    // core info for every activity
    protected string _name;
    protected string _description;
    protected int    _durationSec;

    protected Activity(string name, string description)
    {
        _name        = name;
        _description = description;
    }

    public void Run()
    {
        DisplayStart();
        PerformActivity();
        DisplayEnd();
    }

    private void DisplayStart()
    {
        Console.Clear();
        Console.WriteLine($"=== {_name} ===");
        Console.WriteLine(_description);
        Console.Write("Enter duration (sec): ");
        if (!int.TryParse(Console.ReadLine(), out _durationSec))
        {
            Console.WriteLine("Oops, that wasn’t a number. Using 30s.");
            _durationSec = 30;
        }

        Console.WriteLine("Get ready...");
        ShowCountdown(3);
    }

    private void DisplayEnd()
    {
        Console.WriteLine("\nNice work! 🎉");
        Console.WriteLine($"Finished {_name} for {_durationSec}s.\n");
        ShowCountdown(3);
    }

    #region Animation Helpers

    protected void ShowCountdown(int seconds)
    {
        // personal favorite—count down visibly
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            SafeSleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    protected void ShowSpinner(int loops)
    {
        var frames = new[] { "|", "/", "–", "\\" };
        for (int i = 0; i < loops; i++)
        {
            foreach (var f in frames)
            {
                Console.Write(f);
                SafeSleep(150);
                Console.Write("\b \b");
            }
        }
        Console.WriteLine();
    }

    private void SafeSleep(int ms)
    {
        try
        {
            Thread.Sleep(ms);
        }
        catch (ThreadInterruptedException ex)
        {
            // crude log; could write to a file
            Console.WriteLine($"[Log] Sleep error: {ex.Message}");
        }
    }

    #endregion

    protected abstract void PerformActivity();
}
