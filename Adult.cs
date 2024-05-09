namespace ArrayPro
{
    public class Adult : Human,IComparable<Adult>
    {
        public Adult()
        {
            Age = 18;
        }

        public override string Name { get; set; }

        private int age;

        
        public override int Age
        {
            get => age;
            set
            {
                if (value < 18)
                {
                    throw new ArgumentException("Adults are 18+");
                }
                age = value;
            }
        }

        public override void ActStupid()
        {
            
        }

        public int CompareTo(Adult other)
        {
            if (other == null)
                return 1;

            return Age.CompareTo(other.Age);
        }
    }
}
