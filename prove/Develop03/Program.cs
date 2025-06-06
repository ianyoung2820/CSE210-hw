using System;

namespace ScriptureMemorizer
{
    // Main entry point
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
