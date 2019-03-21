using StudentApp.Entity;
using StudentApp.Service;
using System.Collections.Generic;

namespace StudentApp
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
