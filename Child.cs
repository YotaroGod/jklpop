namespace ArrayPro
{
    public class Child : Human, IComparable<Child>
    {
        public override string Name { get; set; }

        private int age;

        
        public override int Age
        {
            get => age;
            set
            {
                if (value >= 18)
                {
                    throw new ArgumentException("Children are 18-");
                }
                age = value;
            }
        }

        public override void ActStupid()
        {
          
        }

        public int CompareTo(Child other)
        {
            if (other == null)
                return 1;

            return Age.CompareTo(other.Age);
        }
    }
}
