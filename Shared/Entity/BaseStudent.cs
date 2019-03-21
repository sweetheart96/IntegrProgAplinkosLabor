namespace Shared.Entity
{
    public class BaseStudent
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public double FinalAverage { get; private set; }
        public double FinalMedian { get; private set; }

        protected BaseStudent(string name, string surname, double finalAverage, double finalMedian)
        {
            Name = name;
            Surname = surname;
            FinalAverage = finalAverage;
            FinalMedian = finalMedian;
        }
    }
}
