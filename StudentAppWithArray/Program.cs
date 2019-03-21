using StudentAppWithArray.Entity;
using StudentAppWithArray.Service;
using System.Collections.Generic;

namespace StudentAppWithArray
{
    class Program
    {
        public static List<Student> Students = new List<Student>();

        static void Main(string[] args)
        {
            ConsoleHelper.RunMenu();
        }
    }
}
