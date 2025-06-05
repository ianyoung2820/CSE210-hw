using System;

namespace Learning04
{
    public class WritingAssignment : Assignment
    {
        // Private field specific to WritingAssignment
        private string _title;

        // Constructor calls base(...) to initialize studentName & topic
        public WritingAssignment(string studentName, string topic, string title)
            : base(studentName, topic)
        {
            _title = title;
        }

        // Returns "{title} by {studentName}"
        public string GetWritingInformation()
        {
            // We can’t access _studentName directly, 
            // so we call the public GetStudentName() from the base class.
            return $"{_title} by {GetStudentName()}";
        }
    }
}