using Shared.Entity;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentApp.Entity
{
    public class Student : BaseStudent
    {
        public List<int> Marks { get; private set; }

        public Student(string name, string surname, double finalAverage, double finalMedian, List<int> marks) : base(name, surname, finalAverage, finalMedian)
        {
            Marks = marks;
        }

        public static Student Create(string name, string surname, List<int> homeworkMarks, double examMark)
        {
            if(homeworkMarks.Any(x=>x<0) || examMark < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var finalAverage = homeworkMarks.Count > 0 ? homeworkMarks.Average() * 0.3 + examMark * 0.7 : examMark * 0.7;
            var finalMedian = homeworkMarks.Count > 0 ? MathHelper.CalculateMedian(homeworkMarks) * 0.3 + examMark * 0.7 : examMark * 0.7;

            return new Student(name, surname, finalAverage, finalMedian, homeworkMarks);
        }
    }
}
