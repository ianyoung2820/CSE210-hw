using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // This class represents the passage and the logic around masking/display
    public class Passage
    {
        private readonly BibleReference _reference;
        private readonly List<WordUnit> _words;

        // Shared Random to avoid same-seed issues
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
}
