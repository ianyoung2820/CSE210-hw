using System;

namespace EternalQuest
{
    /// <summary>
    /// A goal requiring multiple completions; awards base points each time
    /// and a bonus upon reaching target count.
    /// </summary>
    public class ChecklistGoal : Goal
    {
        private int _currentCount;
        private int _targetCount;
        private int _bonus;

        public ChecklistGoal(string title, string description, int points, int targetCount, int bonus)
            : base(title, description, points)
        {
            _targetCount = targetCount;
            _bonus = bonus;
            _currentCount = 0;
        }

        public override int RecordEvent()
        {
            if (_isComplete) return 0;

            _currentCount++;
            int earned = _points;
            if (_currentCount >= _targetCount)
            {
                _isComplete = true;
                earned += _bonus;
            }
            return earned;
        }

        public override string GetStatus()
        {
            return _isComplete
                ? $"[X] Completed {_currentCount}/{_targetCount}"  // done with bonus
                : $"[ ] Completed {_currentCount}/{_targetCount}";
        }

        public override string Serialize()
        {
            // Format: Checklist|title|description|points|current|target|bonus|isCompleteFlag
            return $"Checklist|{_title}|{_description}|{_points}|{_currentCount}|{_targetCount}|{_bonus}|{(_isComplete ? 1 : 0)}";
        }
    }
}
