using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoringandUpdatingTeacherRecords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataFilePath = "D:\\Phase-1\\Course-End-Projects\\StoringandUpdatingTeacherRecords\\teacher_records.txt";
            TeacherDataHandler dataHandler = new TeacherDataHandler(dataFilePath);

            List<Teacher> teachers = dataHandler.ReadTeacherData();

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\n===== Rainbow School Teacher Records =====");
                Console.WriteLine("1. Add Teacher");
                Console.WriteLine("2. Update Teacher");
                Console.WriteLine("3. View All Teachers");
                Console.WriteLine("4. Exit");

                Console.Write("\nEnter your choice (1/2/3/4): ");
                string choiceStr = Console.ReadLine();
                if (!int.TryParse(choiceStr, out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddTeacher(teachers);
                        break;
                    case 2:
                        UpdateTeacher(teachers);
                        break;
                    case 3:
                        ViewAllTeachers(teachers);
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose from 1 to 4.");
                        break;
                }
            }

            dataHandler.SaveTeacherData(teachers);
        }

        static void AddTeacher(List<Teacher> teachers)
        {
            Console.WriteLine("\n===== Add Teacher =====");
            Console.Write("Enter ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                return;
            }

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Class: ");
            string className = Console.ReadLine();

            Console.Write("Enter Section: ");
            string section = Console.ReadLine();

            Teacher newTeacher = new Teacher(id, name, className, section);
            teachers.Add(newTeacher);

            Console.WriteLine("Teacher added successfully.");
        }

        static void UpdateTeacher(List<Teacher> teachers)
        {
            Console.WriteLine("\n===== Update Teacher =====");
            Console.Write("Enter ID of the teacher to update: ");
            if (!int.TryParse(Console.ReadLine(), out int idToUpdate))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                return;
            }

            Teacher teacherToUpdate = teachers.Find(t => t.ID == idToUpdate);
            if (teacherToUpdate == null)
            {
                Console.WriteLine("Teacher with the given ID not found.");
                return;
            }

            Console.Write("Enter updated Name: ");
            teacherToUpdate.Name = Console.ReadLine();

            Console.Write("Enter updated Class: ");
            teacherToUpdate.Class = Console.ReadLine();

            Console.Write("Enter updated Section: ");
            teacherToUpdate.Section = Console.ReadLine();

            Console.WriteLine("Teacher updated successfully.");
        }

        static void ViewAllTeachers(List<Teacher> teachers)
        {
            Console.WriteLine("\n===== All Teachers =====");
            foreach (Teacher teacher in teachers)
            {
                Console.WriteLine(teacher);
            }
        }
    }
}
