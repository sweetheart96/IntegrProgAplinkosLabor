using StudentApp.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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

                var badOnes = new List<Student>();

                for (var i = students.Count - 1; i >= 0; i--)
                {
                    var thisStudent = students[i];

                    if (thisStudent.FinalAverage < 5)
                    {
                        badOnes.Add(thisStudent);
                        students.Remove(thisStudent);
                    }
                }

                FileWriter.WriteStudentsToFile(students, $"galvociai{fileNumber}.txt");
                FileWriter.WriteStudentsToFile(badOnes, $"vargsiukai{fileNumber}.txt");

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
