using System;
using System.Diagnostics;
using System.Linq;

namespace StudentApp.Service
{
    public static class FileGenerationAndSpeedMeasurementHelper
    {
        public static void GenerateFileReadAndReturnTime(int studentsNumber)
        {
            try
            {
                var fileNumber = Math.Log10(studentsNumber);

                Console.WriteLine($"Failas numeris {fileNumber} pradetas generuoti");
                var sw = new Stopwatch();
                sw.Start();

                FileWriter.GenerateFile(studentsNumber, "sugeneruotiStudentai");

                var students = FileReader.ReadFileWithoutHeader($"sugeneruotiStudentai{fileNumber}.txt");
                var goodOnes = students.Where(x => x.FinalAverage >= 5).ToList();
                var badOnes = students.Where(x => x.FinalAverage < 5).ToList();

                FileWriter.WriteStudentsToFile(goodOnes, $"galvociai{fileNumber}.txt");
                FileWriter.WriteStudentsToFile(badOnes, $"vargsiukai{fileNumber}.txt");

                sw.Stop();
                
                Console.WriteLine($"Failas numeris {fileNumber} buvo sugeneruotas, nuskaitytas ir padalintas i du failus (galvociai ir vargsiukai) per {sw.Elapsed.Seconds} sekundziu ir {sw.Elapsed.Milliseconds} milisekundziu");
                Console.WriteLine("Paspauskite enter...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ivyko klaida: {ex.Message}");
            }
        }
    }
}
