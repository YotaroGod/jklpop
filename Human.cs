namespace ArrayPro
{
    public abstract class Human : IComparable<Human>
    {
        public abstract string Name { get; set; }
        public abstract int Age { get; set; }
        public abstract void ActStupid();

        public int CompareTo(Human other)
        {
            if (other == null)
                return 1;

            return Age.CompareTo(other.Age);
        }

        public override string ToString()
        {
            return $"({Name}, Age: {Age})";
        }
    }
}
