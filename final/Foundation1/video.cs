using System.Collections.Generic;

namespace Foundation4Program1
{
    public class Video
    {
        private string title;
        private string author;
        private int lengthSeconds;
        private List<Comment> comments = new List<Comment>();

        public Video(string title, string author, int lengthSeconds)
        {
            this.title = title;
            this.author = author;
            this.lengthSeconds = lengthSeconds;
        }

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return comments.Count;
        }

        public string GetDisplayInfo()
        {
            return $"Title: {title}\nAuthor: {author}\nLength: {lengthSeconds} seconds\nComments: {GetCommentCount()}";
        }

        public List<Comment> GetAllComments()
        {
            // return a copy so internal list stays encapsulated
            return new List<Comment>(comments);
        }
    }
}
