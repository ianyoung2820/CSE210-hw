using System;
using System.IO;
using System.Collections.Generic;

namespace EternalQuest
{
    // Program to track my random goals (with my weird notes!)
    class Program
    {
        // My goal list - experimental: tried Dictionary<int, Goal> but stuck with List
        private static List<Goal> _goals = new List<Goal>();
        private static int _totalScore = 0; // Keeps getting higher... hope this doesn’t overflow

        static void Main(string[] args)
        {
            //Console.WriteLine("Debug: Starting Main");
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine($"\n-- Your score so far: {_totalScore} --");
                Console.WriteLine("1) Create new goal");
                Console.WriteLine("2) List goals");
                Console.WriteLine("3) Record event");
                Console.WriteLine("4) Save goals");
                Console.WriteLine("5) Load goals");
                Console.WriteLine("6) Quit");
                Console.Write("-> Your choice? ");

                string choice = Console.ReadLine();
                // ^^ maybe add validation later
                switch (choice)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        ListGoals();
                        break;
                    case "3":
                        // Attempt to record, catch if bad input?
                        _totalScore += RecordEvent();
                        break;
                    case "4":
                        SaveGoals();
                        break;
                    case "5":
                        LoadGoals();
                        break;
                    case "6":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Oops, that wasn’t an option. Try again.");
                        break;
                }
            }

            Console.WriteLine("Thanks for playing—umm, tracking! Press any key to exit.");
            Console.ReadKey();
        }

        static void CreateGoal()
        {
            Console.Write("Which type? (1=Simple, 2=Eternal, 3=Checklist): ");
            string type = Console.ReadLine();

            Console.Write("Title (eg. 'Read a book'): ");
            string title = Console.ReadLine();

            Console.Write("Description: ");
            string desc = Console.ReadLine();

            Console.Write("Points for completion: ");
            if (!int.TryParse(Console.ReadLine(), out int pts))
            {
                Console.WriteLine("Hmm, that didn’t parse. Setting points to 0.");
                pts = 0;
            }

            // Quick hack: handle checklist separately
            if (type == "3")
            {
                Console.Write("How many times to complete? ");
                int target = int.TryParse(Console.ReadLine(), out int t) ? t : 1;
                Console.Write("Bonus points when done: ");
                int bonus = int.TryParse(Console.ReadLine(), out int b) ? b : 0;
                _goals.Add(new ChecklistGoal(title, desc, pts, target, bonus));
            }
            else if (type == "2")
            {
                _goals.Add(new EternalGoal(title, desc, pts));
            }
            else
            {
                // default simple
                _goals.Add(new SimpleGoal(title, desc, pts));
            }

            Console.WriteLine($"Added goal: '{title}' with {pts} pts. ({_goals.Count} total)");
        }

        static void ListGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet. Add one!");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                var goal = _goals[i];
                Console.WriteLine($"[{i+1}] {goal.GetStatus()} - {goal.GetTitle()} ({goal.GetDescription()})");
            }
        }

        static int RecordEvent()
        {
            ListGoals();
            Console.Write("Select goal # to mark: ");
            if (!int.TryParse(Console.ReadLine(), out int idx))
            {
                Console.WriteLine("Invalid number; no points awarded.");
                return 0;
            }
            idx--; // convert to 0-based
            if (idx < 0 || idx >= _goals.Count)
            {
                Console.WriteLine("That goal doesn't exist.");
                return 0;
            }

            int earned = _goals[idx].RecordEvent();
            Console.WriteLine($"Nice! You earned {earned} points.");
            // TODO: maybe save automatically?
            return earned;
        }

        static void SaveGoals()
        {
            Console.Write("Enter filename to save (e.g. goals.txt): ");
            string fileName = Console.ReadLine();

            try
            {
                using (var writer = new StreamWriter(fileName))
                {
                    writer.WriteLine(_totalScore);
                    foreach (var g in _goals)
                    {
                        writer.WriteLine(g.Serialize());
                    }
                }
                Console.WriteLine("Successfully saved! 👍");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving file: " + ex.Message);
            }
        }

        static void LoadGoals()
        {
            Console.Write("Filename to load: ");
            string fileName = Console.ReadLine();
            if (!File.Exists(fileName))
            {
                Console.WriteLine("File not found! 😕");
                return;
            }

            var lines = File.ReadAllLines(fileName);
            _goals.Clear();
            if (int.TryParse(lines[0], out int score))
            {
                _totalScore = score;
            }

            // parse each goal line
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                // Example: Simple|Title|Desc|Pts|DoneFlag
                switch (parts[0])
                {
                    case "Simple":
                        var s = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        if (parts[4] == "1") s.RecordEvent(); // mark done
                        _goals.Add(s);
                        break;

                    case "Eternal":
                        var e = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                        int times = int.Parse(parts[4]);
                        for (int j = 0; j < times; j++) e.RecordEvent();
                        _goals.Add(e);
                        break;

                    case "Checklist":
                        var c = new ChecklistGoal(
                            parts[1], parts[2],
                            int.Parse(parts[3]),
                            int.Parse(parts[5]),
                            int.Parse(parts[6]));
                        int doneCount = int.Parse(parts[4]);
                        for (int j = 0; j < doneCount; j++) c.RecordEvent();
                        _goals.Add(c);
                        break;
                }
            }
            Console.WriteLine($"Loaded {_goals.Count} goals. Score = {_totalScore}");
        }
    }
}
