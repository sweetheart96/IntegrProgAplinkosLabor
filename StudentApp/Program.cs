using StudentApp.Entity;
using StudentApp.Service;
using System;
using System.Collections.Generic;

namespace StudentApp
{
    class Program
    {
        public static List<Student> Students = new List<Student>();
        public static LinkedList<Student> StudentsLinkedList = new LinkedList<Student>();


        static void Main(string[] args)
        {
            //This block of code only for speed testing
            try
            {
                for (int i = 10; i <= 100000; i *= 10)
                {
                    FileWriter.GenerateFile(i, "sugeneruotiStudentai");
                    FileGenerationAndSpeedMeasurementHelper.ReadFileAndReturnTime(i);
                    FileGenerationAndSpeedMeasurementHelper.ReadFileAndReturnTimeWithLinkedList(i);
                    FileGenerationAndSpeedMeasurementHelper.ReadFileAndReturnTimeWithQueue(i);
                }

                Console.WriteLine($"Paspauskite enter...");

                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ivyko klaida generuojant arba nuskaitant failus: {ex.Message}");
            }

            //menu start
            ConsoleHelper.RunMenu();
        }
    }
}
