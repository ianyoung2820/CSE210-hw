using System;

namespace Foundation4Program4
{
    public abstract class Activity
    {
        protected DateTime date;
        protected int minutes;

        protected Activity(DateTime date, int minutes)
        {
            this.date = date;
            this.minutes = minutes;
        }

        public abstract double GetDistance();   // miles
        public abstract double GetSpeed();      // mph
        public abstract double GetPace();       // min/mile

        public virtual string GetSummary()
        {
            return $"{date:d} {GetType().Name} ({minutes} min) - " +
                   $"Distance: {GetDistance():F2} mi, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min/mi";
        }
    }
}
