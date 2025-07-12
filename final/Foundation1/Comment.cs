namespace Foundation4Program1
{
    public class Comment
    {
        private string commenterName;
        private string text;

        public Comment(string commenterName, string text)
        {
            this.commenterName = commenterName;
            this.text = text;
        }

        public string GetDisplayText()
        {
            return $"{commenterName}: {text}";
        }
    }
}
