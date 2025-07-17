using System;
using System.Collections.Generic;

namespace Foundation4Program4
{
    class Program
    {
        static void Main(string[] args)
        {
            var activities = new List<Activity>
            {
                new Running(DateTime.Now.AddDays(-3), 30, 3.0),
                new Cycling(DateTime.Now.AddDays(-2), 45, 12.0),
                new Swimming(DateTime.Now.AddDays(-1), 60, 40)
            };

            foreach (var act in activities)
            {
                Console.WriteLine(act.GetSummary());
            }
        }
    }
}
