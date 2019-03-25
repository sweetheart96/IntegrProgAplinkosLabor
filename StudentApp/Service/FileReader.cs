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
        static readonly string textFilePath = "..\\..\\..\\kursiokai.txt";

        public static List<Student> ReadFile()
        {
            var students = new List<Student>();
            string[] lines = File.ReadAllLines(textFilePath);
            lines = lines.Skip(1).ToArray(); //skipping the header

            students.AddRange(FileStudentModel.ToEntity(lines));

            return students;
        }
    }
}
