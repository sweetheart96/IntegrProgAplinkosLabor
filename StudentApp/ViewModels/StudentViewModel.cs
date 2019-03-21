using StudentApp.Entity;
using System.Collections.Generic;
using System.Linq;

namespace StudentApp.ViewModels
{
    public class StudentViewModel
    {
        public static List<string> ToViewModelWithAverage(List<Student> students, int padding)
        {
            return students
                    .Select(x =>
                    x.Name.PadRight(padding) +
                    x.Surname.PadRight(padding) +
                    x.FinalAverage.ToString().PadRight(padding))
                    .ToList();
        }

        public static List<string> ToViewModelWithMedian(List<Student> students, int padding)
        {
            return students
                    .Select(x =>
                    x.Name.PadRight(padding) +
                    x.Surname.PadRight(padding) +
                    x.FinalMedian.ToString().PadRight(padding))
                    .ToList();
        }

        public static List<string> ToViewModelWithAverageAndMedian(List<Student> students, int padding)
        {
            return students
                    .Select(x =>
                    x.Name.PadRight(padding) +
                    x.Surname.PadRight(padding) +
                    x.FinalAverage.ToString().PadRight(padding) +
                    x.FinalMedian.ToString().PadRight(padding))
                    .ToList();
        }
    }
}
