using System;

namespace Foundation4Program3
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = new Address("789 Pine Ln", "Denver", "CO", "USA");

            var lecture = new Lecture(
                "Tech Talk",
                "Deep dive into C#",
                new DateTime(2025, 7, 20),
                new TimeSpan(18, 0, 0),
                baseAddress,
                "Dr. Ada",
                150
            );

            var reception = new Reception(
                "Networking Mixer",
                "Meet industry folks",
                new DateTime(2025, 7, 21),
                new TimeSpan(19, 30, 0),
                baseAddress,
                "rsvp@events.com"
            );

            var outdoor = new OutdoorGathering(
                "Summer Festival",
                "Food and games",
                new DateTime(2025, 7, 22),
                new TimeSpan(12, 0, 0),
                baseAddress,
                "Sunny, 75°F"
            );

            Event[] events = { lecture, reception, outdoor };

            foreach (var e in events)
            {
                Console.WriteLine(e.GetStandardDetails());
                Console.WriteLine(e.GetFullDetails());
                Console.WriteLine(e.GetShortDescription());
                Console.WriteLine();
            }
        }
    }
}
