using StudentApp.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace StudentApp.Service
{
    public static class FileGenerationAndSpeedMeasurementHelper
    {
        public static void ReadFileAndReturnTime(int studentsNumber)
        {
            try
            {
                var fileNumber = Math.Log10(studentsNumber);
                var sw = new Stopwatch();

                Console.WriteLine($"Failas nuskaitomas");

                sw.Start();

                var students = FileReader.ReadFileWithoutHeader($"sugeneruotiStudentai{fileNumber}.txt");
                var goodOnes = students.Where(x => x.FinalAverage >= 5).ToList();
                var badOnes = students.Where(x => x.FinalAverage < 5).ToList();

                FileWriter.WriteStudentsToFile(goodOnes, $"galvociai{fileNumber}.txt");
                FileWriter.WriteStudentsToFile(badOnes, $"vargsiukai{fileNumber}.txt");

                sw.Stop();
                
                Console.WriteLine($"Failas numeris {fileNumber} buvo nuskaitytas ir padalintas i du failus (galvociai ir vargsiukai) per {sw.Elapsed.Seconds} sekundziu ir {sw.Elapsed.Milliseconds} milisekundziu");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ivyko klaida: {ex.Message}");
            }
        }

        public static void ReadFileAndReturnTimeWithLinkedList(int studentsNumber)
        {
            try
            {
                var fileNumber = Math.Log10(studentsNumber);
                var sw = new Stopwatch();

                Console.WriteLine($"Failas nuskaitomas");
                
                sw.Start();

                var students = FileReader.ReadFileWithoutHeaderToLinkedList($"sugeneruotiStudentai{fileNumber}.txt");
                var goodOnes = new LinkedList<Student>(students.Where(x => x.FinalAverage >= 5));
                var badOnes = new LinkedList<Student>(students.Where(x => x.FinalAverage < 5));

                FileWriter.WriteStudentsToFile(goodOnes, $"galvociaiLinked{fileNumber}.txt");
                FileWriter.WriteStudentsToFile(badOnes, $"vargsiukaiLinked{fileNumber}.txt");

                sw.Stop();

                Console.WriteLine($"Failas numeris {fileNumber} buvo nuskaitytas ir padalintas i du failus (galvociai ir vargsiukai) per {sw.Elapsed.Seconds} sekundziu ir {sw.Elapsed.Milliseconds} milisekundziu");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ivyko klaida: {ex.Message}");
            }
        }

        public static void ReadFileAndReturnTimeWithQueue(int studentsNumber)
        {
            try
            {
                var fileNumber = Math.Log10(studentsNumber);
                var sw = new Stopwatch();

                Console.WriteLine($"Failas nuskaitomas");

                sw.Start();

                var students = FileReader.ReadFileWithoutHeaderToQuene($"sugeneruotiStudentai{fileNumber}.txt");
                var goodOnes = students.Where(x => x.FinalAverage >= 5).ToList();
                var badOnes = students.Where(x => x.FinalAverage < 5).ToList();

                FileWriter.WriteStudentsToFile(goodOnes, $"galvociaiQuene{fileNumber}.txt");
                FileWriter.WriteStudentsToFile(badOnes, $"vargsiukaiQuene{fileNumber}.txt");

                sw.Stop();

                Console.WriteLine($"Failas numeris {fileNumber} buvo nuskaitytas ir padalintas i du failus (galvociai ir vargsiukai) per {sw.Elapsed.Seconds} sekundziu ir {sw.Elapsed.Milliseconds} milisekundziu");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ivyko klaida: {ex.Message}");
            }
        }
    }
}
