using System;

namespace Foundation4Program4
{
    public class Cycling : Activity
    {
        private double speedMph;

        public Cycling(DateTime date, int minutes, double speedMph)
            : base(date, minutes)
        {
            this.speedMph = speedMph;
        }

        public override double GetDistance() => (speedMph * minutes) / 60;
        public override double GetSpeed()    => speedMph;
        public override double GetPace()     => 60 / speedMph;
    }
}
