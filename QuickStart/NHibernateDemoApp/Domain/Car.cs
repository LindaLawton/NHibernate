namespace NHibernateDemoApp.Domain
{
    public class Car
    {
        public virtual int ID { get; set; }
        public virtual string Make { get; set; }
        public virtual string Model { get; set; }
        public virtual string Year { get; set; }

        public override string ToString()
        {
            return $"{Make} {Model} {Year}";
        }

        protected bool Equals(Car other)
        {
            return ID == other.ID;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Car) obj);
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}