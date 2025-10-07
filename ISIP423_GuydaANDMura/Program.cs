using System;

class Program
{
    class University
    {
        class People
        {
            protected string name { get; set; } = "";
            protected string surname { get; set; } = "";
            protected int age { get; set; }
            protected string phone { get; set; } = "";
            protected string role { get; set; } = "";

            public string GetName() => name;
            public string GetSurname() => name;
            public int GetAge() => age;
            public string GetPhone() => phone;
        }

        class Teacher : People
        {
            public Teacher()
            {
                role = "Teacher";
            }

            public string GetRole() => role;
        }

        class Student : People
        {
            List <Student> students = new List<Student>();
            public Student()
            {
                role = "Student";
            }

            public string GetRole() => role;

            static void AddStudent()
            {
                Console.WriteLine("=== Добавление студента ===");
                while (true)
                {
                    var student = new Student();
                    while (true)
                    {
                        Console.WriteLine("Введите имя студента: ");
                        string name = Console.ReadLine();
                        if (!string.IsNullOrEmpty(name))
                        {
                            student.name = name;
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
                            student.surname = surname;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Фамилия не может быть пустой!");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Введите возраст студента: ");
                        if (int.TryParse(Console.ReadLine(), out int age))
                        {
                            if (age > 0)
                            {
                                student.age = age;
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
                        Console.WriteLine("Введите телефон студента: ");
                        string phone = Console.ReadLine();
                        if (!string.IsNullOrEmpty(phone))
                        {
                            if (phone.Length > 10)
                            {
                                student.phone = phone;
                                break;
                            }

                            else
                            {
                                Console.WriteLine("Длина телефонного номера не соответствует стандарту!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Имя не может быть пустым!");
                        }
                    }

                }
            }
        }

        class Courses
        {
            string title { get; set; } = "";
            string Teacher { get; set; } = "";
            string description { get; set; } = "";

            public string GetTitle() => title;
            public string GetTeacher() => Teacher;
            public string GetDescription() => description;
        }
    }
}