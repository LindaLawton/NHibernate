namespace NHibernateDemoApp.Domain
{
    public class Person
    {
        public virtual int ID { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }

        public  virtual  string Address { get; set; }
        public virtual Car Car { get; set; }


        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        // alt insert + equality members + select id
        protected bool Equals(Person other)
        {
            return ID == other.ID;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Person) obj);
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}
