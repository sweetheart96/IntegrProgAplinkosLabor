using StudentApp.Entity;
using System;
using System.Collections.Generic;

namespace StudentApp.ViewModels
{
    public class FileStudentModel
    {
        public static Student ToEntity(string lineFromFile)
        {
            string[] words = lineFromFile.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var examMark = Int32.Parse(words[7]);
            var marks = new List<int>
            {
                Int32.Parse(words[2]),
                Int32.Parse(words[3]),
                Int32.Parse(words[4]),
                Int32.Parse(words[5]),
                Int32.Parse(words[6])
            };

            var student = Student.Create(words[0], words[1], marks, examMark);

            return student;
        }

        public static List<Student> ToEntity(string[] linesFromFile)
        {
            var students = new List<Student>();

            try
            {
                foreach (var item in linesFromFile)
                {
                    students.Add(ToEntity(item));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ivyko klaida kuriant Student objekta is failo");
            }

            return students;
        }

        public static LinkedList<Student> ToEntityIntoLinkedList(string[] linesFromFile)
        {
            var students = new LinkedList<Student>();

            try
            {
                foreach (var item in linesFromFile)
                {
                    students.AddLast(ToEntity(item));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ivyko klaida kuriant Student objekta is failo");
            }

            return students;
        }
        

    }
}
