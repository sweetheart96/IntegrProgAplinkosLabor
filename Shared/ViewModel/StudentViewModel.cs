using Shared.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Shared.ViewModel
{
    public class StudentViewModel
    {
        public static List<string> ToViewModelWithAverage(List<BaseStudent> students, int padding)
        {
            return students
                    .Select(x =>
                    x.Name.PadRight(padding) +
                    x.Surname.PadRight(padding) +
                    x.FinalAverage.ToString().PadRight(padding))
                    .ToList();
        }

        public static List<string> ToViewModelWithMedian(List<BaseStudent> students, int padding)
        {
            return students
                    .Select(x =>
                    x.Name.PadRight(padding) +
                    x.Surname.PadRight(padding) +
                    x.FinalMedian.ToString().PadRight(padding))
                    .ToList();
        }

        public static List<string> ToViewModelWithAverageAndMedian(List<BaseStudent> students, int padding)
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
