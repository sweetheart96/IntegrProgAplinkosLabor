using System;
using System.Collections.Generic;

namespace StudentApp.Service
{
    public static class AutoGenerator
    {
        static Random Random = new Random();

        public static List<int> GenerateMarks()
        {
            var howMany = Random.Next(5, 15);
            var marks = new List<int>();

            for(var i = 0; i < howMany; i++)
            {
                marks.Add(GenereateMark());
            }

            return marks;
        }

        public static int[] GenerateArrayMarks()
        {
            var howMany = Random.Next(5, 15);
            var marks = new int[15];

            for (var i = 0; i < howMany; i++)
            {
                marks[i] = GenereateMark();
            }

            return marks;
        }

        public static int GenereateMark()
        {
            return Random.Next(1, 10);
        }
    }
}
