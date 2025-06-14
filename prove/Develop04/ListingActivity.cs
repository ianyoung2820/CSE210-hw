using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private static readonly List<string> topics = new()
    {
        "Who do you appreciate today?",
        "What are your personal strengths?",
        "Name people you helped this week.",
        "When did you feel peaceful recently?",
        "List some of your personal heroes."
    };

    public ListingActivity()
        : base("Listing Session",
               "List items in a category to boost positivity.")
    {
        // nothing fancy here—barebones constructor
    }

    protected override void PerformActivity()
    {
        var rnd    = new Random();
        string prompt = topics[rnd.Next(topics.Count)];
        Console.WriteLine(prompt);
        ShowCountdown(3);

        var entries = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(_durationSec);
        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string line = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(line))
                entries.Add(line);
        }

        Console.WriteLine($"\nYou listed {entries.Count} items. Well done!");
    }
}
