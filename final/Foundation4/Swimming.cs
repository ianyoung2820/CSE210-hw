using System;

namespace Foundation4Program4
{
    public class Swimming : Activity
    {
        private int laps;

        public Swimming(DateTime date, int minutes, int laps)
            : base(date, minutes)
        {
            this.laps = laps;
        }

        public override double GetDistance()
        {
            // 50 m per lap → convert to km → convert to miles
            double km = (laps * 50.0) / 1000;
            return km * 0.62;
        }

        public override double GetSpeed()    => (GetDistance() / minutes) * 60;
        public override double GetPace()     => minutes / GetDistance();
    }
}
