using System;
using System.Collections.Generic;

namespace Foundation4Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            var videos = new List<Video>();

            // Video #1
            var video1 = new Video("Intro to C#", "Jane Doe", 300);
            video1.AddComment(new Comment("Alice", "Great overview!"));
            video1.AddComment(new Comment("Bob", "Very helpful, thanks."));
            video1.AddComment(new Comment("Carol", "Could use more examples."));
            videos.Add(video1);

            // Video #2
            var video2 = new Video("OOP Principles", "John Smith", 420);
            video2.AddComment(new Comment("Dave", "Loved the inheritance section."));
            video2.AddComment(new Comment("Eve", "Polymorphism explained well!"));
            video2.AddComment(new Comment("Frank", "Encapsulation part was confusing."));
            videos.Add(video2);

            // Video #3
            var video3 = new Video("LINQ Basics", "Alex Johnson", 250);
            video3.AddComment(new Comment("Grace", "Nice intro to LINQ."));
            video3.AddComment(new Comment("Heidi", "What about exceptions?"));
            video3.AddComment(new Comment("Ivan", "Looking forward to advanced topics."));
            videos.Add(video3);

            // Display each video and its comments
            foreach (var vid in videos)
            {
                Console.WriteLine(vid.GetDisplayInfo());
                foreach (var comment in vid.GetAllComments())
                {
                    Console.WriteLine(" - " + comment.GetDisplayText());
                }
                Console.WriteLine();
            }
        }
    }
}
