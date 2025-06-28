using System;

namespace EternalQuest
{
    /// <summary>
    /// Abstract base class for all goals, holding common fields and enforcing
    /// that each subclass implement RecordEvent, GetStatus, and Serialize.
    /// </summary>
    public abstract class Goal
    {
        // Common member variables (_camelCase)
        protected string _title;
        protected string _description;
        protected int _points;
        protected bool _isComplete;

        /// <summary>
        /// Base constructor to initialize a goal.
        /// </summary>
        protected Goal(string title, string description, int points)
        {
            _title = title;
            _description = description;
            _points = points;
            _isComplete = false;
        }

        // Public accessors (methods to avoid property confusion)
        public string GetTitle() => _title;
        public string GetDescription() => _description;
        public int GetPoints() => _points;
        public bool IsComplete() => _isComplete;

        /// <summary>
        /// Record progress on the goal; subclasses award points and update state.
        /// </summary>
        public abstract int RecordEvent();

        /// <summary>
        /// Return a string indicating completion status for listing.
        /// </summary>
        public abstract string GetStatus();

        /// <summary>
        /// Serialize this goal into a line for save/load.
        /// </summary>
        public abstract string Serialize();
    }
}
