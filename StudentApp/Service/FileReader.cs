using StudentApp.Entity;
using StudentApp.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentApp.Service
{
    public static class FileReader
    {
        //Default file  
        static readonly string Path = "..\\..\\..\\";

        public static List<Student> ReadFile()
        {
            var filePath = Path + "kursiokai.txt";

            var students = new List<Student>();
            string[] lines = File.ReadAllLines(filePath);
            lines = lines.Skip(1).ToArray(); //skipping the header

            students.AddRange(FileStudentModel.ToEntity(lines));

            return students;
        }

        public static List<Student> ReadFileWithoutHeader(string fileName)
        {
            var filePath = Path + fileName;

            var students = new List<Student>();
            string[] lines = File.ReadAllLines(filePath);

            students.AddRange(FileStudentModel.ToEntity(lines));

            return students;
        }

        public static LinkedList<Student> ReadFileWithoutHeaderToLinkedList(string fileName)
        {
            var filePath = Path + fileName;

            var students = new LinkedList<Student>();
            string[] lines = File.ReadAllLines(filePath);

            foreach(var item in lines)
            {
                students.AddLast(FileStudentModel.ToEntity(item));
            }

            return students;
        }

        public static Queue<Student> ReadFileWithoutHeaderToQuene(string fileName)
        {

            var filePath = Path + fileName;

            var students = new Queue<Student>();
            string[] lines = File.ReadAllLines(filePath);

            foreach(var item in lines)
            {
                students.Enqueue(FileStudentModel.ToEntity(item));
            }

            return students;
        }
    }
}
