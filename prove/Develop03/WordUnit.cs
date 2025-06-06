using System;

namespace ScriptureMemorizer
{
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
}
