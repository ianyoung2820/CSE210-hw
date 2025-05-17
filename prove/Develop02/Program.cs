using System;
using System.Collections.Generic;
using System.IO;  

namespace JournalApp
{
    class Entry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }

        public Entry(string date, string prompt, string response)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
        }
    }

    class Journal
    {
        private List<Entry> entries = new List<Entry>();
        private const string Separator = "--"; 

        public void AddEntry(Entry entry)
        {
            entries.Add(entry);
        }

        public void DisplayEntries()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("Nothing here yet :( \n");
                return;
            }

            foreach (var entry in entries)
            {
                Console.WriteLine($"Date: {entry.Date}");
                Console.WriteLine($"Prompt: {entry.Prompt}");
                // guard against null Response
                var resp = entry.Response ?? string.Empty;
                Console.WriteLine($"Response: {resp}");
                int wc = resp.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
                Console.WriteLine($"({wc} words)\n");
            }
        }

        public void SaveToFile(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                Console.WriteLine("Invalid filename. Save aborted.\n");
                return;
            }
            try 
            {
                using (var writer = new StreamWriter(filename)) 
                {
                    foreach (var entry in entries)
                    {
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
            if (string.IsNullOrWhiteSpace(filename) || !File.Exists(filename))
            {
                Console.WriteLine($"Can't find {filename} :(?\n");
                return;
            }

            try
            {
                entries.Clear(); 
                var lines = File.ReadAllLines(filename); 
                
                foreach (string line in lines)
                {
                    var parts = line.Split(new[] { Separator }, StringSplitOptions.None);
                    if (parts.Length == 3)
                    {
                        entries.Add(new Entry(
                            date: parts[0],      
                            prompt: parts[1],    
                            response: parts[2]
                        ));
                    }
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
        static readonly List<string> Prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "What challenge did I face today?",
            "What am I grateful for today?",
            "If I could relive one moment, what would it be?"
        };

        static void Main(string[] args)
        {
            var myJournal = new Journal();  
            var random = new Random();  
            var running = true;  

            while (running)
            {
                Console.WriteLine("= Journal Program =");
                Console.WriteLine("1. Write something new");
                Console.WriteLine("2. See all entries");
                Console.WriteLine("3. Save everything");
                Console.WriteLine("4. Load from file");
                Console.WriteLine("5. Exit");
                Console.Write("\nWhat do you want to do? (1-5): ");

                var input = Console.ReadLine();
                Console.WriteLine();

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
                        var saveName = Console.ReadLine();
                        myJournal.SaveToFile(saveName);
                        break;

                    case "4":
                        Console.Write("Which file should I load?: ");
                        var loadName = Console.ReadLine();
                        myJournal.LoadFromFile(loadName);
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
