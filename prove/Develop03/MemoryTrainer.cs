using System;

namespace ScriptureMemorizer
{
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
}
