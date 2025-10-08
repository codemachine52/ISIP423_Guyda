using System;
using System.Globalization;
using System.Xml.Linq;

class Program
{
    class University
    {
        public class People
        {
            protected string name { get; set; } = "";
            protected string surname { get; set; } = "";
            protected string phone { get; set; } = "";

            protected string city { get; set; } = "";
            protected DateOnly birthday { get; set; }
            protected string role { get; set; } = "";

            public string GetName() => name;
            public string GetSurname() => surname;
            public DateOnly GetBirthday() => birthday;
            public string GetCity() => city;
            public string GetPhone() => phone;


            public void SetName(string value) => name = value;
            public void SetSurname(string value) => surname = value;
            public void SetBirthday(DateOnly value) => birthday = value;
            public void SetCity(string value) => city = value;
            public void SetPhone(string value) => phone = value;

        }

        public class Teacher : People
        {

            public Teacher()
            {
                role = "Teacher";
            }

            public string GetRole() => role;
        }


        public class Student : People
        {

            protected int id = 0;
            protected static int NextID = 1;
            string StudBilet { get; set; } = "";
            string course { get; set; } = "";
            string grouppa { get; set; } = "";
            bool isPaidEducation { get; set; }
            public Student()
            {
                role = "Student";
                id = NextID++;
            }

            public string GetRole() => role;
            public string GetCourse() => course;
            public string GetGrouppa() => grouppa;
            public bool GetPaidEducation() => isPaidEducation;

            public string GetStud() => StudBilet;


            public int GetID() => id;
            public void SetStud(string value) => StudBilet = value;
            public void SetCourse(string value) => course = value;
            public void SetGroup(string value) => grouppa = value;
            public void SetPaidorFree(bool value) => isPaidEducation = value;
        }
    }
            static public void AddStudent()
            {
                Console.WriteLine("=== Добавление студента ===");
                bool continueAdding = true;
        while (continueAdding)
                {
                    var student = new University.Student();
                    while (true)
                    {
                        Console.WriteLine("Введите имя студента: ");
                        string name = Console.ReadLine();
                        if (!string.IsNullOrEmpty(name))
                        {
                            student.SetName(name);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Имя не может быть пустым!");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Введите фамилию студента: ");
                        string surname = Console.ReadLine();
                        if (!string.IsNullOrEmpty(surname))
                        {
                        student.SetSurname(surname);
                        break;
                        }
                        else
                        {
                            Console.WriteLine("Фамилия не может быть пустой!");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Введите дату рождения студента: ");
                        if (DateOnly.TryParse(Console.ReadLine(), out DateOnly age))
                        {
                            if ((DateTime.Now.Year - age.Year) > 0)
                            {
                                student.SetBirthday(age);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Возраст не может быть отрицательным!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Возраст должен быть числом!");
                        }
                    }


                    while (true)
                    {
                        Console.WriteLine("Введите номер студ билета студента: ");
                        string stbilet = Console.ReadLine();
                        if (!string.IsNullOrEmpty(stbilet))
                        {
                            student.SetStud(stbilet);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Номер студенческого билета не может быть пустой!");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Введите курс студента: ");
                        string course = Console.ReadLine();
                        if (!string.IsNullOrEmpty(course))
                        {
                            student.SetCourse(course);
                            break;
                    }
                        else
                        {
                            Console.WriteLine("Курс не может быть пустой!");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Введите группу студента: ");
                        string group = Console.ReadLine();
                        if (!string.IsNullOrEmpty(group))
                        {
                            student.SetGroup(group);
                            break;
                    }
                        else
                        {
                            Console.WriteLine("Группа не может быть пустой!");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Платно обучается студент? (да/нет): ");
                        string PaidorFree = Console.ReadLine();
                        if (!string.IsNullOrEmpty(PaidorFree))
                        {
                            if (PaidorFree.Contains("да"))
                            {
                                student.SetPaidorFree(true);
                                break;
                        }
                            else
                            {
                                student.SetPaidorFree(false);
                                break;
                        }
                        }
                        else
                        {
                            Console.WriteLine("Поле не может быть пустым!");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Введите телефон студента: ");
                        string phone = Console.ReadLine();
                        if (!string.IsNullOrEmpty(phone))
                        {
                            if (phone.Length > 10)
                            {
                                student.SetPhone(phone);
                                break;
                            }

                            else
                            {
                                Console.WriteLine("Длина телефонного номера не соответствует стандарту!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Поле не может быть пустым!");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Введите город студента: ");
                        string city = Console.ReadLine();
                        if (!string.IsNullOrEmpty(city))
                        {
                            student.SetCity(city);
                            break;
                    }
                        else
                        {
                            Console.WriteLine("Поле не может быть пустым!");
                        }
                    }

                    if (student != null)
                    {
                        students.Add(student);
                        Console.WriteLine("Студент успешно добавлен. Продолжить? (да/нет)");
                        string choice = Console.ReadLine();
                        if (!string.IsNullOrEmpty(choice))
                        {
                                
                                if(choice.ToLower() == "да")
                                    {
                                    continueAdding = true;
                                    }
                                if(choice.ToLower() == "нет")
                                    {
                                        continueAdding = false;
                                    }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Не все поля заполнены. Не удалось добавить студента.");
                        }
                    }
                }

        static List<University.Student> students = new List<University.Student>();

        static public void PrintStudent()
            {
                foreach (var student in students)
                {
                    Console.WriteLine($"id: {student.GetID()}, имя: {student.GetName()}, фамилия: {student.GetSurname()}, номер студ. билета: {student.GetStud()}, группа обучения: {student.GetGrouppa()}\n" +
                        $"курс обучения: {student.GetCourse()}, учится платно: {student.GetPaidEducation()}, город проживания: {student.GetCity()}, номер тел: {student.GetPhone()}");
                }
            }

            public class Courses
            {
                string title { get; set; } = "";
                string Teacher { get; set; } = "";
                string description { get; set; } = "";
                int countHours { get; set; }

                public string GetTitle() => title;
                public string GetTeacher() => Teacher;
                public string GetDescription() => description;
                public int GetCountHours() => countHours;
            }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== Университет - Главное меню ===");
            Console.WriteLine("1. Добавить студента");
            Console.WriteLine("2. Показать всех студентов");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            if (int.TryParse(Console.ReadLine(), out int choice)) {
                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        PrintStudent();
                        break;
                    case 0:
                        Console.WriteLine("Выход из программы...");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор! Попробуйте снова.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Выберите пункт меню!");
            }
        }
    }
}