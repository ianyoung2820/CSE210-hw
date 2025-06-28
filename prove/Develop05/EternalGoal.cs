using System;

namespace EternalQuest
{
    /// <summary>
    /// A never-completing goal: each time recorded, always awards points.
    /// Tracks how many times recorded.
    /// </summary>
    public class EternalGoal : Goal
    {
        private int _timesRecorded;

        public EternalGoal(string title, string description, int points)
            : base(title, description, points)
        {
            _timesRecorded = 0;
        }

        public override int RecordEvent()
        {
            _timesRecorded++;
            return _points;
        }

        public override string GetStatus()
        {
            return $"[∞] Recorded {_timesRecorded} times";
        }

        public override string Serialize()
        {
            // Format: Eternal|title|description|points|timesRecorded
            return $"Eternal|{_title}|{_description}|{_points}|{_timesRecorded}";
        }
    }
}