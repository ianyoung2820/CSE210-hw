using System;
using System.Collections.Generic;
using System.Linq;

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

    // Handles a single word, including whether it's masked or not
    public class WordUnit
    {
        private readonly string _rawText;
        private bool _isHidden;

        public WordUnit(string word)
        {
            _rawText   = word;
            _isHidden  = false;  // all words start visible
        }

        public void Mask()     => _isHidden = true;
        public bool IsMasked() => _isHidden;

        public string Render()
        {
            return _isHidden
                ? new string('_', _rawText.Length)
                : _rawText;
        }
    }

    // This class represents the passage and the logic around masking/display
    public class Passage
    {
        private readonly BibleReference _reference;
        private readonly List<WordUnit> _words;

        // Shared Random to avoid same seed issues
        private static readonly Random _rand = new Random();

        public Passage(BibleReference refInfo, string text)
        {
            _reference = refInfo;
            _words     = text
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(w => new WordUnit(w))
                .ToList();
        }

        public void Show()
        {
            Console.WriteLine(_reference.GetText());
            Console.WriteLine();
            Console.WriteLine(string.Join(" ", _words.Select(w => w.Render())));
        }

        // Now only masks words that are still visible
        public void RandomlyMaskWords(int count = 3)
        {
            var candidates = _words.Where(w => !w.IsMasked()).ToList();
            for (int i = 0; i < count && candidates.Count > 0; i++)
            {
                int idx = _rand.Next(candidates.Count);
                candidates[idx].Mask();
                candidates.RemoveAt(idx);
            }
        }

        public bool IsFullyMasked()
        {
            return _words.All(w => w.IsMasked());
        }
    }

    // Runs the interactive masking practice
    public class MemoryTrainer
    {
        private readonly Passage _passage;

        public MemoryTrainer(Passage passageToPractice)
        {
            _passage = passageToPractice;
        }

        public void StartSession()
        {
            while (true)
            {
                Console.Clear();
                _passage.Show();

                if (_passage.IsFullyMasked())
                {
                    Console.WriteLine("\nNicely done! Everything’s hidden.");
                    break;
                }

                if (!PromptUser())
                {
                    Console.WriteLine("Alright, stopping the session.");
                    break;
                }

                // gradually mask more words
                _passage.RandomlyMaskWords();
            }
        }

        private bool PromptUser()
        {
            Console.WriteLine();
            Console.Write("Press Enter to hide more, or type \"quit\": ");
            string reply = Console.ReadLine()?.Trim() ?? "";

            return !reply.Equals("quit", StringComparison.OrdinalIgnoreCase);
        }
    }

    // Main method
    class Program
    {
        static void Main(string[] args)
        {
            var reference = new BibleReference("John", 3, 16);
            var scripture = "For God so loved the world that He gave His one and only Son, " +
                            "that whoever believes in Him shall not perish but have eternal life.";

            var passage = new Passage(reference, scripture);
            var trainer = new MemoryTrainer(passage);

            trainer.StartSession();
        }
    }
}
