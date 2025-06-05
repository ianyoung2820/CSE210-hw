using System;

class Program
{
    static void Main(string[] args)
    {
        {
            string playAgain = "yes";

            // Outer loop
            while (playAgain.ToLower() == "yes")
            {
                // Generate a random number between 1 and 100
                Random randomGenerator = new Random();
                int secretNumber = randomGenerator.Next(1, 101);
                int userGuess;
                int attempts = 0;

                // Guessing loop
                do
                {
                    Console.Write("Guess a number between 1 and 100: ");
                    userGuess = int.Parse(Console.ReadLine());
                    attempts++;

                    if (userGuess < secretNumber)
                        Console.WriteLine("Higher");
                    else if (userGuess > secretNumber)
                        Console.WriteLine("Lower");

                } while (userGuess != secretNumber);

                Console.WriteLine($"You guessed it in {attempts} attempts!");

                // Ask if the user wants to play again
                Console.Write("Play again? (yes/no): ");
                playAgain = Console.ReadLine();
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}

public class WordUnit
{
    private readonly string _rawText;
    private bool _isHidden;

    public WordUnit(string word)
    {
        _rawText = word;
        _isHidden = false;
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
