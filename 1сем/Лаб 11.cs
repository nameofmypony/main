using System;
class Student
{
    public string name;
    public int year;
    public string mom;
    public string dad;
    public string home;
}
class Program
{

    static Student[] students = new Student[100];
    static int number = 0;
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int operation;
        do
        {
            Console.WriteLine("1 - заполнить информацию об ученике");
            Console.WriteLine("2 - изменить информацию об ученике");
            Console.WriteLine("3 - выполнить поиск учеников по начальной букве ФИО");
            Console.WriteLine("4 - выполнить поиск учеников по улице проживания");
            Console.WriteLine("5 - выполнить поиск учеников по году рождения");
            Console.WriteLine("6 - выйти");
            Console.Write("выберите действие (1-6): ");
            if (int.TryParse(Console.ReadLine(), out operation))
            {
                switch (operation)
                {
                    case 1:
                        New();
                        break;
                    case 2:
                        Change();
                        break;
                    case 3:
                        Symbol();
                        break;
                    case 4:
                        Street();
                        break;
                    case 5:
                        Year();
                        break;
                    case 6:
                        Console.WriteLine("выход");
                        break;
                    default:
                        Console.WriteLine("ошибка");
                        break;
                }
            }
            else
            {
                Console.WriteLine("ошибка");
                continue;
            }
        } while (operation != 6);
    }
    static void New()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        if (number < students.Length)
        {
            Student student = new Student();
            Console.Write("введите ФИО ученика: ");
            student.name = Console.ReadLine();
            Console.Write("введите год рождения: ");
            student.year = int.Parse(Console.ReadLine());
            Console.Write("введите ФИО мамы: ");
            student.mom = Console.ReadLine();
            Console.Write("введите ФИО папы: ");
            student.dad = Console.ReadLine();
            Console.Write("введите адрес (улица дом квартира через пробел): ");
            student.home = Console.ReadLine();
            students[number] = student;
            number++;
            Console.WriteLine("информация об ученике заполнена");
        }
        else
        {
            Console.WriteLine("массив учеников заполнен");
        }
    }
    static void Change()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        if (number != 0)
        {
            Console.Write("введите ФИО ученика: ");
            string name = Console.ReadLine();
            bool found = false;
            foreach (Student student in students)
            {
                if (student != null && student.name == name)
                {
                    Console.Write("введите год рождения: ");
                    student.year = int.Parse(Console.ReadLine());
                    Console.Write("введите ФИО мамы: ");
                    student.mom = (Console.ReadLine());
                    Console.Write("введите ФИО папы: ");
                    student.dad = (Console.ReadLine());
                    Console.Write("введите адрес: ");
                    student.home = (Console.ReadLine());
                    Console.WriteLine("информация об ученике изменена");
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("ученик с указанным ФИО не найден");
            }
        }
        else
        {
            Console.WriteLine("массив учеников пустой");
            return;
        }
    }
    static void Symbol()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        if (number != 0)
        {
            Console.Write("введите букву: ");
            string letters = Console.ReadLine();
            char letter = letters[0];
            Console.WriteLine("ученики, чье ФИО начинается с этой буквы: ");
            bool found = false;
            foreach (Student student in students)
            {
                if (student != null && student.name[0] == letter)
                {
                    Console.WriteLine(student.name);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("таких нет");
            }
        }
        else
        {
            Console.WriteLine("массив учеников пустой");
            return;
        }
    }
    static void Street()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        if (number != 0)
        {
            Console.Write("введите название улицы: ");
            string street = Console.ReadLine();
            Console.WriteLine("ученики, проживающие на этой улице: ");
            bool found = false;
            foreach (Student student in students)
            {
                if (student != null)
                {
                    string[] Home = student.home.Split(' ');
                    if (Home[0] == street)
                    {
                        Console.WriteLine(student.name);
                        found = true;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("таких нет");
            }
        }
        else
        {
            Console.WriteLine("массив учеников пустой");
            return;
        }
    }
    static void Year()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        if (number != 0)
        {
            Console.Write("введите год рождения: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("ученики этого года рождения: ");
            bool found = false;
            foreach (Student student in students)
            {
                if (student != null && student.year == year)
                {
                    Console.WriteLine(student.name);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("таких нет");
            }
        }
        else
        {
            Console.WriteLine("массив учеников пустой");
            return;
        }
    }
}
