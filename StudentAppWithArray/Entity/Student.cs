using Shared.Entity;
using Shared.Helpers;
using System.Linq;

namespace StudentAppWithArray.Entity
{
    public class Student : BaseStudent
    {
        public int[] Marks { get; private set; }

        public Student(string name, string surname, double finalAverage, double finalMedian, int[] marks) : base(name, surname, finalAverage, finalMedian)
        {
            Marks = marks;
        }

        public static Student Create(string name, string surname, int[] homeworkMarks, double examMark)
        {
            var finalAverage = homeworkMarks.Count() > 0 ? homeworkMarks.Average() * 0.3 + examMark * 0.7 : examMark * 0.7;
            var finalMedian = homeworkMarks.Count() > 0 ? MathHelper.CalculateMedian(homeworkMarks) * 0.3 + examMark * 0.7 : examMark * 0.7;

            return new Student(name, surname, finalAverage, finalMedian, homeworkMarks);
        }
    }
}
