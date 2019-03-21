using StudentApp.Entity;
using StudentApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentApp.Service
{
    public static class ConsoleHelper
    {
        private static int Padding = 20;
        private static char DivChar = "-".ToCharArray().First();

        private static string ListHeader = "Vardas".PadRight(Padding) + "Pavarde".PadRight(Padding);
        private static string ResultAverage = "Galutinis (Vid.)".PadRight(Padding);
        private static string ResultMedian = "Galutinis (Med.)".PadRight(Padding);

        private static List<string> Menu = new List<string>
        {
            "1. Prideti studenta ir jo pazymius",
            "2. Perziureti sarasa",
            "3. Prideti studenta su atsitiktiniais pazymiais",
            "4. Baigti darba"
        };

        private static List<string> NewStudentAdding = new List<string>
        {
            "Iveskite varda: ",
            "Iveskite pavarde: ",
            "Iveskite namu darbu pazymius per tarpa: ",
            "Iveskite egzamino pazymi: "
        };

        public static void RunMenu()
        {
            try
            {
                Console.Clear();

                foreach (var line in Menu)
                {
                    Console.WriteLine(line);
                }

                var input = Int32.Parse(Console.ReadLine());

                Console.Clear();

                switch (input)
                {
                    case 1:
                        Input();
                        break;
                    case 2:
                        Output();
                        break;
                    case 3:
                        InputWithRandomGeneratedMarks();
                        break;
                    case 4:
                        EndWork();
                        break;
                    default:
                        WrongMenuNumber();
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Blogas formatas - iveskite skaiciu");
                RunMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ivyko klaida");
                RunMenu();
            }
        }

        private static void WrongMenuNumber()
        {
            Console.WriteLine("Ivestas neteisingas skaicius");
            RunMenu();
        }

        private static void Input()
        {
            try
            {
                var studentDetails = new List<string>();

                foreach (var item in NewStudentAdding)
                {
                    Console.WriteLine(item);
                    studentDetails.Add(Console.ReadLine());
                }

                if (studentDetails.Any(x => string.IsNullOrWhiteSpace(x))){
                    Console.WriteLine("Vienas is parametru buvo tuscias arba tarpas");
                    Console.ReadLine();
                    RunMenu();
                }

                var homeworkMarks = studentDetails[2].Split(' ').Select(Int32.Parse).ToList();

                //var homeworkMarks = studentDetails[2].Split(' ').Select(Int32.Parse).ToArray(); - realizacija su masyvu 

                Program.Students.Add(Student.Create(studentDetails[0], studentDetails[1], homeworkMarks, Int32.Parse(studentDetails[3])));
                RunMenu();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Vienas ar daugiau parametru ivesti neteisingu formatu.");
                RunMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ivyko klaida.");
                RunMenu();
            }             
        }

        private static void InputWithRandomGeneratedMarks()
        {
            try
            {
                Console.WriteLine(NewStudentAdding[0]);
                var name = Console.ReadLine();
                Console.WriteLine(NewStudentAdding[1]);
                var surname = Console.ReadLine();

                var homeworkMarks = AutoGenerator.GenerateMarks();
                //var homeworkMarks = AutoGenerator.GenerateArrayMarks(); - realizacija su masyvu 
                var examMark = AutoGenerator.GenereateMark();

                Program.Students.Add(Student.Create(name, surname, homeworkMarks, examMark));
                RunMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ivyko klaida.");
                RunMenu();
            }
        }

        private static void Output()
        {
            try
            {
                Console.WriteLine("Galutini pazymi skaiciuoti pagal: ");
                Console.WriteLine("1. Vidurki");
                Console.WriteLine("2. Mediana");

                var input = Int32.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.WriteLine("{0}{1}", ListHeader, ResultAverage);
                        PrintOutput(StudentViewModel.ToViewModelWithAverage(Program.Students, Padding));
                        break;
                    case 2:
                        Console.WriteLine("{0}{1}", ListHeader, ResultMedian);
                        PrintOutput(StudentViewModel.ToViewModelWithMedian(Program.Students, Padding));
                        break;
                    default:
                        WrongMenuNumber();
                        break;
                }

                Console.ReadLine();
                RunMenu();

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Vienas ar daugiau parametru ivesti neteisingu formatu.");
                RunMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ivyko klaida.");
                RunMenu();
            }
        }

        private static void PrintOutput(List<string> items)
        {
            Console.WriteLine("".PadRight(Padding * 3, DivChar));

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void EndWork()
        {
            Environment.Exit(0);
        }
    }
}
