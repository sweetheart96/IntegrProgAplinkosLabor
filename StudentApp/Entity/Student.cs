using StudentApp.Service;
using System.Collections.Generic;
using System.Linq;

namespace StudentApp.Entity
{
    public class Student
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public double FinalAverage { get; private set; }
        public double FinalMedian { get; private set; }

        private Student(string name, string surname, double finalAverage, double finalMedian)
        {
            Name = name;
            Surname = surname;
            FinalAverage = finalAverage;
            FinalMedian = finalMedian;
        }

        public static Student Create(string name, string surname, List<int> homeworkMarks, double examMark)
        {
            var finalAverage = homeworkMarks.Count > 0 ? homeworkMarks.Average() * 0.3 + examMark * 0.7 : examMark * 0.7;
            var finalMedian = homeworkMarks.Count > 0 ? MathHelper.CalculateMedian(homeworkMarks) * 0.3 + examMark * 0.7 : examMark * 0.7;

            return new Student(name, surname, finalAverage, finalMedian);
        }

        public static Student Create(string name, string surname, int[] homeworkMarks, double examMark)
        {
            var finalAverage = homeworkMarks.Count() > 0 ? homeworkMarks.Average() * 0.3 + examMark * 0.7 : examMark * 0.7;
            var finalMedian = homeworkMarks.Count() > 0 ? MathHelper.CalculateMedian(homeworkMarks) * 0.3 + examMark * 0.7 : examMark * 0.7;

            return new Student(name, surname, finalAverage, finalMedian);
        }
    }
}
