using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAppConsole
{
    internal class Program
    {
        static List<Student> students = new List<Student>();

        static void Main()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("===== Student Management System =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Remove Student");
                Console.WriteLine("5. Search by Student ID");
                Console.WriteLine("6. Search by Student Name");
                Console.WriteLine("7. Show Highest Average, Lowest Average, Average Average");
                Console.WriteLine("8. Display Passed Students");
                Console.WriteLine("9. Display Failed Students");
                Console.WriteLine("10. Display Students By Grade");
                Console.WriteLine("11. Filter Students Above Average");
                Console.WriteLine("12. Sort Students By Average");
                Console.WriteLine("13. Display Top Performer");
                Console.WriteLine("0. Exit");

                Console.Write("\nChoose Option: ");

                int choice;

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid Input.");
                    Console.WriteLine("Press Any Key To Continue...");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;

                    case 2:
                        DisplayStudents(students);
                        break;

                    case 3:
                        UpdateStudent();
                        break;

                    case 4:
                        RemoveStudent();
                        break;

                    case 5:
                        SearchById();
                        break;

                    case 6:
                        SearchByName();
                        break;

                    case 7:
                        ShowStatistics();
                        break;

                    case 8:
                        DisplayPassedStudents();
                        break;

                    case 9:
                        DisplayFailedStudents();
                        break;

                    case 10:
                        DisplayByGrade();
                        break;

                    case 11:
                        FilterAboveAverage();
                        break;

                    case 12:
                        SortByAverage();
                        break;

                    case 13:
                        DisplayTopPerformer();
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddStudent()
        {
            Student student = new Student();
            Console.Clear();

            Console.Write("ID : ");
            student.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Name : ");
            student.Name = Console.ReadLine()!;

            Console.Write("Physics : ");
            student.Physics = Convert.ToInt32(Console.ReadLine());

            Console.Write("Chemistry : ");
            student.Chemistry = Convert.ToInt32(Console.ReadLine());

            Console.Write("Math : ");
            student.Math = Convert.ToInt32(Console.ReadLine());

            student.Total = student.Physics + student.Chemistry + student.Math;
            student.Average = student.Total / 3.0;

            CalculateResult(student);

            students.Add(student);

            Console.WriteLine("\nStudent Added Successfully.");
            Console.ReadKey();
        }

        static void CalculateResult(Student student)
        {
            double avg = student.Average;
            Console.Clear();

            if (avg >= 80)
            {
                student.LetterGrade = "A+";
                student.CGPA = 4.00;
            }
            else if (avg >= 70)
            {
                student.LetterGrade = "A";
                student.CGPA = 3.75;
            }
            else if (avg >= 60)
            {
                student.LetterGrade = "A-";
                student.CGPA = 3.50;
            }
            else if (avg >= 50)
            {
                student.LetterGrade = "B";
                student.CGPA = 3.00;
            }
            else if (avg >= 40)
            {
                student.LetterGrade = "C";
                student.CGPA = 2.00;
            }
            else
            {
                student.LetterGrade = "F";
                student.CGPA = 0;
            }

            student.IsPassed = avg >= 40;
        }

        static void DisplayStudents(List<Student> list)
        {
            Console.Clear();
            if (list.Count == 0)
            {
                Console.WriteLine("No Student Found.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine($"\tID\tName\t\tTotal Marks\t\tAverage Marks\t\tLetterGrade\t\tCGPA");
            Console.WriteLine("================================================================================================================");
            foreach (Student s in list)
            {
                Console.WriteLine($"\t{s.Id}\t{s.Name}\t\t{s.Total}\t\t\t{s.Average:F2}\t\t\t{s.LetterGrade}\t\t\t{s.CGPA}");
            }
            Console.WriteLine("================================================================================================================");

            Console.ReadKey();
        }

        static void UpdateStudent()
        {
            Console.Clear();
            Console.Write("Enter ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Student student = students.FirstOrDefault(x => x.Id == id)!;

            if (student == null)
            {
                Console.WriteLine("Student Not Found.");
                Console.ReadKey();
                return;
            }

            Console.Write("New Name : ");
            student.Name = Console.ReadLine()!;

            Console.Write("Physics : ");
            student.Physics = Convert.ToInt32(Console.ReadLine());

            Console.Write("Chemistry : ");
            student.Chemistry = Convert.ToInt32(Console.ReadLine());

            Console.Write("Math : ");
            student.Math = Convert.ToInt32(Console.ReadLine());

            student.Total = student.Physics + student.Chemistry + student.Math;
            student.Average = student.Total / 3.0;

            CalculateResult(student);

            Console.WriteLine("Updated Successfully.");
            Console.ReadKey();
        }

        static void RemoveStudent()
        {
            Console.Clear();
            Console.Write("Enter ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Student student = students.FirstOrDefault(x => x.Id == id)!;

            if (student == null)
            {
                Console.WriteLine("Student Not Found.");
            }
            else
            {
                students.Remove(student);
                Console.WriteLine("Removed Successfully.");
            }

            Console.ReadKey();
        }

        static void SearchById()
        {
            Console.Clear();
            Console.Write("Enter ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Student student = students.FirstOrDefault(x => x.Id == id)!;

            if (student == null)
            {
                Console.WriteLine("Not Found.");
                Console.ReadKey();
                return;
            }

            DisplayStudents(new List<Student> { student });
        }

        static void SearchByName()
        {
            Console.Clear();
            Console.Write("Enter Name : ");
            string name = Console.ReadLine()!;

            List<Student> result = students
                .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .ToList();

            DisplayStudents(result);
        }

        static void ShowStatistics()
        {
            Console.Clear();
            if (students.Count == 0)
            {
                Console.WriteLine("No Data.");
            }
            else
            {
                Console.WriteLine($"Highest Average : {students.Max(x => x.Average):F2}");
                Console.WriteLine($"Lowest Average : {students.Min(x => x.Average):F2}");
                Console.WriteLine($"Average Average : {students.Average(x => x.Average):F2}");
            }

            Console.ReadKey();
        }

        static void DisplayPassedStudents()
        {
            Console.Clear();
            DisplayStudents(students.Where(x => x.IsPassed).ToList());
        }

        static void DisplayFailedStudents()
        {
            DisplayStudents(students.Where(x => !x.IsPassed).ToList());
        }

        static void DisplayByGrade()
        {
            Console.Clear();
            Console.Write("Enter Grade : ");
            string grade = Console.ReadLine()!;

            List<Student> result = students
                .Where(x => x.LetterGrade.Equals(grade, StringComparison.OrdinalIgnoreCase))
                .ToList();

            DisplayStudents(result);
        }

        static void FilterAboveAverage()
        {
            Console.Clear();
            if (students.Count == 0)
            {
                Console.WriteLine("No Data.");
                Console.ReadKey();
                return;
            }

            double avg = students.Average(x => x.Average);

            List<Student> result = students
                .Where(x => x.Average > avg)
                .ToList();

            Console.WriteLine($"Overall Average = {avg:F2}");

            DisplayStudents(result);
        }

        static void SortByAverage()
        {
            Console.Clear();
            List<Student> result = students
                .OrderByDescending(x => x.Average)
                .ToList();

            DisplayStudents(result);
        }

        static void DisplayTopPerformer()
        {
            Console.Clear();
            if (students.Count == 0)
            {
                Console.WriteLine("No Data.");
                Console.ReadKey();
                return;
            }

            Student top = students
                .OrderByDescending(x => x.Average)
                .First();

            DisplayStudents(new List<Student> { top });
        }
    }
}