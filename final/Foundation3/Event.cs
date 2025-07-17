using System;

namespace Foundation4Program3
{
    public abstract class Event
    {
        protected string title;
        protected string description;
        protected DateTime date;
        protected TimeSpan time;
        protected Address address;

        protected Event(string title, string description, DateTime date, TimeSpan time, Address address)
        {
            this.title = title;
            this.description = description;
            this.date = date;
            this.time = time;
            this.address = address;
        }

        public string GetStandardDetails()
        {
            return $"{title}\n{description}\nDate: {date:d} Time: {time}\nLocation:\n{address.GetFullAddress()}";
        }

        public abstract string GetFullDetails();

        public string GetShortDescription()
        {
            return $"{GetType().Name}: {title} on {date:d}";
        }
    }
}
