using Shared.Helpers;
using StudentApp.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentApp.Service
{
    public static class FileWriter
    {
        private static string Path = "..\\..\\..\\";

        public static void WriteStudentsToFile(List<Student> students, string fileName)
        {
            try
            {
                var filePath = Path + fileName;
                File.Delete(filePath);
                var mod = students.Count % 10000;
                var div = students.Count / 10000;
                var cyclesNumber = div + 1;

                for (int j = 0; j < cyclesNumber; j++)
                {
                    var text = string.Empty;

                    for (int i = 1 + j * 10000; i <= (cyclesNumber != j + 1 ? (j + 1) * 10000 : j * 10000 + mod); i++)
                    {
                        text += $"{i}. {students.ElementAt(i - 1).Name} {students.ElementAt(i - 1).Surname} {students.ElementAt(i - 1).FinalAverage}" + Environment.NewLine;
                    }

                    File.AppendAllText(filePath, text);
                }

                Console.WriteLine($"{students.Count} studentai sekmingi irasyti i {fileName} faila");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ivyko klaida failo generavimo metu: {ex.Message}");
            }

        }

        public static void WriteStudentsToFile(LinkedList<Student> students, string fileName)
        {
            try
            {
                var filePath = Path + fileName;
                File.Delete(filePath);
                var mod = students.Count % 10000;
                var div = students.Count / 10000;
                var cyclesNumber = div + 1;

                for (int j = 0; j < cyclesNumber; j++)
                {
                    var text = string.Empty;

                    for (int i = 1 + j * 10000; i <= (cyclesNumber != j + 1 ? (j + 1) * 10000 : j * 10000 + mod); i++)
                    {
                        text += $"{i}. {students.ElementAt(i - 1).Name} {students.ElementAt(i - 1).Surname} {students.ElementAt(i - 1).FinalAverage}" + Environment.NewLine;
                    }

                    File.AppendAllText(filePath, text);
                }

                Console.WriteLine($"{students.Count} studentai sekmingi irasyti i {fileName} faila");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ivyko klaida failo generavimo metu: {ex.Message}");
            }

        }

        public static void WriteStudentsToFile(Queue<Student> students, string fileName)
        {
            try
            {
                var filePath = Path + fileName;
                File.Delete(filePath);
                var mod = students.Count % 10000;
                var div = students.Count / 10000;
                var cyclesNumber = div + 1;

                for (int j = 0; j < cyclesNumber; j++)
                {
                    var text = string.Empty;

                    for (int i = 1 + j * 10000; i <= (cyclesNumber != j + 1 ? (j + 1) * 10000 : j * 10000 + mod); i++)
                    {
                        text += $"{i}. {students.ElementAt(i - 1).Name} {students.ElementAt(i - 1).Surname} {students.ElementAt(i - 1).FinalAverage}" + Environment.NewLine;
                    }

                    File.AppendAllText(filePath, text);
                }

                Console.WriteLine($"{students.Count} studentai sekmingi irasyti i {fileName} faila");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ivyko klaida failo generavimo metu: {ex.Message}");
            }

        }

        public static void GenerateFile(int studentsNumber, string fileName)
        {
            if (studentsNumber > 10000)
            {
                GenerateLargeFile(studentsNumber, fileName);
            }
            else
            {
                try
                {
                    var fileNumber = Math.Log10(studentsNumber);
                    var filePath = Path + $"{fileName}{fileNumber}.txt";
                    File.Delete(filePath);
                    var text = string.Empty;

                    for (int i = 1; i <= studentsNumber; i++)
                    {
                        var homeworkMarks = MarksGenerator.GenerateMarks();
                        var examMark = MarksGenerator.GenereateMark();
                        text += $"Vardas{fileNumber}{i} Pavarde{fileNumber}{i} {homeworkMarks[0]} {homeworkMarks[1]} {homeworkMarks[2]} {homeworkMarks[3]} {homeworkMarks[4]} {examMark}" + Environment.NewLine;
                    }

                    File.AppendAllText(filePath, text);
                    Console.WriteLine($"sugeneruotiStudentai{Math.Log10(studentsNumber)} failas is {studentsNumber} studentu sekmingai sugeneruotas");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ivyko klaida failo generavimo metu: {ex.Message}");
                }
            }

        }

        //better to use this one if studentsNumber is greater than 10000
        public static void GenerateLargeFile(int studentsNumber, string fileName)
        {
            try
            {
                var filePath = Path + $"{fileName}{Math.Log10(studentsNumber)}.txt";
                File.Delete(filePath);
                var mod = studentsNumber % 10000;
                var div = studentsNumber / 10000;
                var cyclesNumber = div + 1;

                for (int j = 0; j < cyclesNumber; j++)
                {
                    var text = string.Empty;

                    for (int i = 1 + j * 10000; i <= (cyclesNumber != j + 1 ? (j + 1) * 10000 : j * 10000 + mod); i++)
                    {
                        var homeworkMarks = MarksGenerator.GenerateMarks();
                        var examMark = MarksGenerator.GenereateMark();
                        text += $"Vardas{i} Pavarde{i} {homeworkMarks[0]} {homeworkMarks[1]} {homeworkMarks[2]} {homeworkMarks[3]} {homeworkMarks[4]} {examMark}" + Environment.NewLine;
                    }

                    File.AppendAllText(filePath, text);
                }

                Console.WriteLine($"sugeneruotiStudentai{Math.Log10(studentsNumber)} failas is {studentsNumber} studentu sekmingai sugeneruotas");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ivyko klaida failo generavimo metu: {ex.Message}");
            }
        }
    }
}
