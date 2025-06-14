using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private static readonly List<string> prompts = new()
    {
        "Think of a time you stood up for someone.",
        "Recall a moment you overcame a big challenge.",
        "Remember when you helped someone in need.",
        "Reflect on a truly selfless act you did."
    };

    private static readonly List<string> questions = new()
    {
        "Why was this meaningful to you?",
        "Have you done anything like this before?",
        "What got you started on that?",
        "How did you feel afterward?",
        "What set this apart from other times?",
        "What’s your favorite part of that experience?",
        "What lessons does it hold for you?",
        "What did you learn about yourself?",
        "How can you apply this going forward?"
    };

    public ReflectionActivity()
        : base("Reflection Session",
               "Dive into times you showed strength & resilience.")
    { }

    protected override void PerformActivity()
    {
        var rnd = new Random();
        Console.WriteLine(prompts[rnd.Next(prompts.Count)]);
        ShowCountdown(5);  // give them extra time to ponder

        DateTime limit = DateTime.Now.AddSeconds(_durationSec);
        while (DateTime.Now < limit)
        {
            Console.WriteLine(questions[rnd.Next(questions.Count)]);
            ShowSpinner(2);
        }
    }
}
