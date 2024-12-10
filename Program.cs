using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    private static List<Student> students = new List<Student>();
    private static List<Teacher> teachers = new List<Teacher>();
    private static List<GradeJournal> journals = new List<GradeJournal>();

    public static void Main()
    {
        LoadData();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Выберите роль:");
            Console.WriteLine("1. Студент");
            Console.WriteLine("2. Преподаватель");
            Console.WriteLine("3. Администратор");
            Console.WriteLine("0. Выход");

            Console.Write("Введите номер роли: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        StudentMenu();
                        break;
                    case 2:
                        TeacherMenu();
                        break;
                    case 3:
                        AdminMenu();
                        break;
                    case 0:
                        SaveData(); 
                        Console.WriteLine("Выход из программы.");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ошибка: введите число.");
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }

    private static void LoadData()
    {
        if (File.Exists("students.bin"))
        {
            using (var fs = new FileStream("students.bin", FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(fs))
            {
                while (fs.Position < fs.Length)
                {
                    students.Add(Student.ReadFromBinary(reader));
                }
            }
        }

        if (File.Exists("teachers.bin"))
        {
            using (var fs = new FileStream("teachers.bin", FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(fs))
            {
                while (fs.Position < fs.Length)
                {
                    teachers.Add(Teacher.ReadFromBinary(reader));
                }
            }
        }

        if (File.Exists("journals.bin"))
        {
            using (var fs = new FileStream("journals.bin", FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(fs))
            {
                while (fs.Position < fs.Length)
                {
                    journals.Add(GradeJournal.ReadFromBinary(reader));
                }
            }
        }
    }

    private static void SaveData()
    {
        using (var fs = new FileStream("students.bin", FileMode.Create, FileAccess.Write))
        using (var writer = new BinaryWriter(fs))
        {
            foreach (var student in students)
            {
                student.WriteToBinary(writer);
            }
        }

        using (var fs = new FileStream("teachers.bin", FileMode.Create, FileAccess.Write))
        using (var writer = new BinaryWriter(fs))
        {
            foreach (var teacher in teachers)
            {
                teacher.WriteToBinary(writer);
            }
        }

        using (var fs = new FileStream("journals.bin", FileMode.Create, FileAccess.Write))
        using (var writer = new BinaryWriter(fs))
        {
            foreach (var journal in journals)
            {
                journal.WriteToBinary(writer);
            }
        }
    }

    private static void StudentMenu()
    {
        Console.WriteLine("Меню студента.");
    }

    private static void TeacherMenu()
    {
        Console.WriteLine("Меню преподавателя.");
    }

    private static void AdminMenu()
    {
        Console.WriteLine("Меню администратора.");
    }
}
