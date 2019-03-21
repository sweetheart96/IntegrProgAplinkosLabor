using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentApp.Service
{
    public static class MathHelper
    {
        public static double CalculateMedian(List<int> list)
        {
            list.Sort();

            if (list.Count == 1)
            {
                return list.First();
            }

            if (list.Count % 2 == 0)
            {
                return (list[list.Count / 2 - 1] + list[list.Count / 2]) / 2;
            }

            return list[list.Count / 2 - 1];
        }

        public static double CalculateMedian(int[] array)
        {
            Array.Sort(array);

            if (array.Count() == 1)
            {
                return array.First();
            }

            if (array.Count() % 2 == 0)
            {
                return (array[array.Count() / 2 - 1] + array[array.Count() / 2]) / 2;
            }

            return array[array.Count() / 2 - 1];
        }
    }
}
