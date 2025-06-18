namespace Learning05
{
    public class Shape
    {
        private string _color;

        public Shape(string color)
        {
            _color = color;
        }

        public string GetColor()
        {
            return _color;
        }

        public void SetColor(string color)
        {
            _color = color;
        }

        // The base implementation returns 0; 
        // each subclass will override with its own logic.
        public virtual double GetArea()
        {
            return 0;
        }
    }
}
