using System;

namespace Learning04
{
    public class Assignment
    {
        // Private fields
        private string _studentName;
        private string _topic;

        // Constructor
        public Assignment(string studentName, string topic)
        {
            _studentName = studentName;
            _topic = topic;
        }

        // Public getter for _studentName (used by derived classes)
        public string GetStudentName()
        {
            return _studentName;
        }

        // GetSummary returns "StudentName - Topic"
        public string GetSummary()
        {
            return $"{_studentName} - {_topic}";
        }
    }
}