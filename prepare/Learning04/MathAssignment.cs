using System;

namespace Learning04
{
    public class MathAssignment : Assignment
    {
        // Private fields specific to MathAssignment
        private string _textbookSection;
        private string _problems;

        // Constructor calls base(...) to initialize studentName & topic
        public MathAssignment(string studentName, string topic, string textbookSection, string problems)
            : base(studentName, topic)
        {
            _textbookSection = textbookSection;
            _problems = problems;
        }

        // Returns "Section {textbookSection} Problems {problems}"
        public string GetHomeworkList()
        {
            return $"Section {_textbookSection} Problems {_problems}";
        }
    }
}