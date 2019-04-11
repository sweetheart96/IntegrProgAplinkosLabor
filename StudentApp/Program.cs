using StudentApp.Entity;
using StudentApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentApp
{
    class Program
    {
        public static List<Student> Students = new List<Student>();

        static void Main(string[] args)
        {
            //This block of code only for speed testing
            //try
            //{
            //    for(int i = 10; i <= 100000; i *= 10)
            //    {
            //        FileGenerationAndSpeedMeasurementHelper.GenerateFileReadAndReturnTime(i);
            //    }
                
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Ivyko klaida generuojant arba nuskaitant failus: {ex.Message}");
            //}

            ConsoleHelper.RunMenu();
        }
    }
}
