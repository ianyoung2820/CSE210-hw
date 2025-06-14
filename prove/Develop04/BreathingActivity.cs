using System;

public class BreathingActivity : Activity
{
    // TODO: Let user tweak inhale/exhale durations later
    public BreathingActivity()
        : base("Breathing Session",
               "Focus on slow breaths: inhale calm, exhale stress.")
    { }

    protected override void PerformActivity()
    {
        DateTime deadline = DateTime.Now.AddSeconds(_durationSec);
        while (DateTime.Now < deadline)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(3);

            Console.Write("Breathe out... ");
            ShowCountdown(3);

            ShowSpinner(1);  // little transition spinner
        }
    }
}
