using System;

namespace ScriptureMemorizer
{
    // Simple class for keeping track of the scripture location
    public class BibleReference
    {
        private readonly string _book;
        private readonly int _chapter;
        private readonly int _verseStart;
        private readonly int? _verseEnd;  // optional 

        // Constructor for just a single verse
        public BibleReference(string bookName, int chapterNum, int startVerse)
        {
            _book       = bookName;
            _chapter    = chapterNum;
            _verseStart = startVerse;
            _verseEnd   = null;  // by default, no range
        }

        // Constructor for a range like 3:16–18
        public BibleReference(string bookName, int chapterNum, int startVerse, int endVerse)
        {
            _book       = bookName;
            _chapter    = chapterNum;
            _verseStart = startVerse;
            _verseEnd   = endVerse;
        }

        public string GetText()
        {
            return _verseEnd.HasValue
                ? $"{_book} {_chapter}:{_verseStart}-{_verseEnd}"
                : $"{_book} {_chapter}:{_verseStart}";
        }
    }
}
