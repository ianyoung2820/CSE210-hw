using System;

namespace EternalQuest
{
    /// <summary>
    /// A one-time goal: once completed, awards points exactly once.
    /// </summary>
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string title, string description, int points)
            : base(title, description, points) { }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                return _points;
            }
            return 0;
        }

        public override string GetStatus()
        {
            return _isComplete ? "[X]" : "[ ]";
        }

        public override string Serialize()
        {
            // Format: Simple|title|description|points|isCompleteFlag
            return $"Simple|{_title}|{_description}|{_points}|{(_isComplete ? 1 : 0)}";
        }
    }
}