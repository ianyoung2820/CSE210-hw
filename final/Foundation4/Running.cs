using System;

namespace Foundation4Program4
{
    public class Running : Activity
    {
        private double distanceMiles;

        public Running(DateTime date, int minutes, double distanceMiles)
            : base(date, minutes)
        {
            this.distanceMiles = distanceMiles;
        }

        public override double GetDistance() => distanceMiles;
        public override double GetSpeed()    => (distanceMiles / minutes) * 60;
        public override double GetPace()     => minutes / distanceMiles;
    }
}
