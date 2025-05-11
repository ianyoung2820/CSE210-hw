using System;
using System.Collections.Generic;
using System.IO;  // for file stuff

namespace JournalApp
{
    // basic container for journal stuff - nothing fancy
    class Entry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }

        // TODO: maybe add mood tracking later?
        public Entry(string date, string prompt, string response)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
        }
    }

    class Journal
    {
        // keeping track of entries - might want to switch to Dictionary later
        private List<Entry> entries = new List<Entry>();
        private const string Separator = "--";  // works for now, but maybe CSV would be better?

        public void AddEntry(Entry entry)
        {
            // just add it to the list - simple enough
            entries.Add(entry);
        }

        public void DisplayEntries()
        {
            // quick check if we have anything to show
            if (entries.Count == 0)
            {
                Console.WriteLine("Nothing here yet :( \n");
                return;
            }

            // loop through and show everything
            foreach (var entry in entries)  // changed 'e' to 'entry' for better readability
            {
                Console.WriteLine($"Date: {entry.Date}");
                Console.WriteLine($"Prompt: {entry.Prompt}");
                Console.WriteLine($"Response: {entry.Response}\n");
            }
        }

        // saves everything to a file - had some issues with this earlier but fixed now
        public void SaveToFile(string filename)
        {
            try  // added basic error handling cuz files can be tricky
            {
                using (var writer = new StreamWriter(filename))  // renamed for clarity
                {
                    foreach (var entry in entries)
                    {
                        // format: Date--Prompt--Response (maybe switch to JSON later?)
                        writer.WriteLine($"{entry.Date}{Separator}{entry.Prompt}{Separator}{entry.Response}");
                    }
                }
                Console.WriteLine($"Saved everything to {filename}!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, couldn't save the file: {ex.Message}\n");
            }
        }

        public void LoadFromFile(string filename)
        {
            // make sure file exists before we try anything
            if (!File.Exists(filename))
            {
                Console.WriteLine($"Can't find {filename} :(\n");
                return;
            }

            try
            {
                entries.Clear();  // start fresh
                var lines = File.ReadAllLines(filename);  // grab everything at once
                
                foreach (string line in lines)
                {
                    var parts = line.Split(new[] { Separator }, StringSplitOptions.None);
                    
                    // basic validation - might need more later
                    if (parts.Length == 3)
                    {
                        entries.Add(new Entry(
                            date: parts[0],      // being explicit with parameter names
                            prompt: parts[1],     // helps me remember what's what
                            response: parts[2]
                        ));
                    }
                    // else { /* should probably log bad entries somewhere */ }
                }
                Console.WriteLine($"Loaded from {filename} successfully!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong loading the file: {ex.Message}\n");
            }
        }
    }

    class Program
    {
        // these are pretty good but might want to add more later
        static readonly List<string> Prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "What challenge did I face today?",
            "What am I grateful for today?",
            "If I could relive one moment, what would it be?"
            // "What did I learn today?",  // might add this one later
        };

        static void Main(string[] args)
        {
            var myJournal = new Journal();  // more descriptive name
            var random = new Random();  // for picking prompts
            var running = true;  // control flag

            // main program loop
            while (running)
            {
                // could probably make this prettier but it works
                Console.WriteLine("= Journal Program =");
                Console.WriteLine("1. Write something new");
                Console.WriteLine("2. See all entries");
                Console.WriteLine("3. Save everything");
                Console.WriteLine("4. Load from file");
                Console.WriteLine("5. Exit");
                Console.Write("\nWhat do you want to do? (1-5): ");

                var input = Console.ReadLine();
                Console.WriteLine();

                // handle user choice
                switch (input)
                {
                    case "1":
                        var todaysPrompt = Prompts[random.Next(Prompts.Count)];
                        Console.WriteLine(todaysPrompt);
                        Console.Write("Write your thoughts: ");
                        var userResponse = Console.ReadLine();
                        
                        var today = DateTime.Now.ToShortDateString();
                        myJournal.AddEntry(new Entry(today, todaysPrompt, userResponse));
                        Console.WriteLine("Got it!\n");
                        break;

                    case "2":
                        myJournal.DisplayEntries();
                        break;

                    case "3":
                        Console.Write("Where should I save it? (filename): ");
                        myJournal.SaveToFile(Console.ReadLine());
                        break;

                    case "4":
                        Console.Write("Which file should I load?: ");
                        myJournal.LoadFromFile(Console.ReadLine());
                        break;

                    case "5":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Huh? Try a number between 1 and 5\n");
                        break;
                }
            }
        }
    }
}