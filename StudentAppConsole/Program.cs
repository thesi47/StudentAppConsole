using System.Transactions;

namespace StudentAppConsole
{
    public class Program
    {
        static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
            while (true)
            {


                Console.Clear();
                Console.WriteLine("Welcome to Student Console Manager...!");
                Console.WriteLine("=======STUDENT MANAGEMENT SYSTEM=======");
                Console.WriteLine();

                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Remove Student");
                Console.WriteLine("5. Search by Student ID");
                Console.WriteLine("6. Search by Student Name");
                Console.WriteLine("7. Show Highest Mark, Lowest Mark, Average Mark");
                Console.WriteLine("8. Display Passed Students");
                Console.WriteLine("9. Display Failed Students");
                Console.WriteLine("10. Display Students By grade");
                Console.WriteLine("11. Filter Students Above Average");
                Console.WriteLine("12. Sort Students By Mark");
                Console.WriteLine("13. Display Top Performer");
                Console.WriteLine("0. Exit");
                Console.WriteLine();
                Console.Write("Enter Choice: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;

                    case "2":
                        DisplayStudents();
                        break;

                    case "3":
                        UpdateStudent();
                        break;

                    case "4":
                        RemoveStudent();
                        break;

                    case "5":
                        SearchById();
                        break;

                    case "6":
                        SearchByName();
                        break;

                    case "7":
                        ShowStatistics();
                        break;

                    case "8":
                        ShowPassedStudents();
                        break;

                    case "9":
                        ShowFailedStudents();
                        break;

                    case "10":
                        ShowByGrade();
                        break;

                    case "11":
                        AboveAverage();
                        break;

                    case "12":
                        SortByMark();
                        break;

                    case "13":
                        TopPerformer();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }
        }
        static void AddStudent()
        {
            Console.Write("Enter Student ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine()!;
            Console.WriteLine();
            Console.Write("Enter Chemistry Mark");
            int chemistry = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Physics Mark");
            int physics = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Math Mark");
            int math = Convert.ToInt32(Console.ReadLine());


            students.Add(new Student
            {
                Id = id,
                Name = name,
                Chemistry = chemistry,
                Physics = physics,
                Math = math

            });
            Console.WriteLine($"Student {name} added successfully");
            static void DisplayStudents()
            {
                if (!students.Any())
                {
                    Console.WriteLine("No Students Found.");
                }
                else
                {
                    foreach (var s in students)
                    {
                        Console.WriteLine($"{s.Id}\t{s.Name}\t{s.Mark}\t{s.Grade}");
                    }
                }
                
            }

            static void UpdateStudent()
            {
                Console.Write("Enter Student ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Student student = students.FirstOrDefault(s => s.Id == id);

                if (student == null)
                {
                    Console.WriteLine("Student Not Found.");
                }
                else
                {
                    Console.Write("New Name: ");
                    student.Name = Console.ReadLine();

                    Console.Write("New Mark: ");
                    student.Mark = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Updated Successfully.");
                }

                
            }

            static void RemoveStudent()
            {
                Console.Write("Enter Student ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Student student = students.FirstOrDefault(s => s.Id == id);

                if (student != null)
                {
                    students.Remove(student);
                    Console.WriteLine("Student Removed.");
                }
                else
                {
                    Console.WriteLine("Student Not Found.");
                }

                
            }

            static void SearchById()
            {
                Console.Write("Enter ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                var s = students.FirstOrDefault(x => x.Id == id);

                if (s == null)
                    Console.WriteLine("Student Not Found.");
                else
                    Console.WriteLine($"{s.Id} {s.Name} {s.Mark} {s.Grade}");

                
            }

            static void SearchByName()
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                var result = students.Where(x => x.Name.ToLower().Contains(name.ToLower()));

                foreach (var s in result)
                {
                    Console.WriteLine($"{s.Id} {s.Name} {s.Mark} {s.Grade}");
                }

                
            }

            static void ShowStatistics()
            {
                if (!students.Any())
                {
                    Console.WriteLine("No Data.");
                }
                else
                {
                    Console.WriteLine($"Highest Mark : {students.Max(x => x.Mark)}");
                    Console.WriteLine($"Lowest Mark  : {students.Min(x => x.Mark)}");
                    Console.WriteLine($"Average Mark : {students.Average(x => x.Mark):F2}");
                }

                
            }

            static void ShowPassedStudents()
            {
                foreach (var s in students.Where(x => x.IsPassed))
                {
                    Console.WriteLine($"{s.Id} {s.Name} {s.Mark}");
                }

                
            }

            static void ShowFailedStudents()
            {
                foreach (var s in students.Where(x => !x.IsPassed))
                {
                    Console.WriteLine($"{s.Id} {s.Name} {s.Mark}");
                }

                
            }

            static void ShowByGrade()
            {
                Console.Write("Enter Grade: ");
                string grade = Console.ReadLine().ToUpper();

                var result = students.Where(x => x.Grade.ToUpper() == grade);

                foreach (var s in result)
                {
                    Console.WriteLine($"{s.Id} {s.Name} {s.Mark}");
                }

                
            }

            static void AboveAverage()
            {
                if (!students.Any())
                {
                    Console.WriteLine("No Data.");
                }
                else
                {
                    double avg = students.Average(x => x.Mark);

                    Console.WriteLine($"Average = {avg:F2}\n");

                    foreach (var s in students.Where(x => x.Mark > avg))
                    {
                        Console.WriteLine($"{s.Id} {s.Name} {s.Mark}");
                    }
                }

                
            }

            static void SortByMark()
            {
                foreach (var s in students.OrderByDescending(x => x.Mark))
                {
                    Console.WriteLine($"{s.Id} {s.Name} {s.Mark}");
                }

                
            }

            static void TopPerformer()
            {
                if (!students.Any())
                {
                    Console.WriteLine("No Students.");
                }
                else
                {
                    var top = students.OrderByDescending(x => x.Mark).First();

                    Console.WriteLine("Top Performer");
                    Console.WriteLine($"ID    : {top.Id}");
                    Console.WriteLine($"Name  : {top.Name}");
                    Console.WriteLine($"Mark  : {top.Mark}");
                    Console.WriteLine($"Grade : {top.Grade}");
                }

                
            }
        }
    }
}