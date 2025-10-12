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
            protected int id = 0;
            protected static int NextID = 1;
            float workExpernc { get; set; }
            double salary { get; set; }
            public Teacher()
            {
                role = "Преподаватель";
                id = NextID++;
            }

            public string GetRole() => role;
            public int GetID() => id;
            public float GetExp() => workExpernc;
            public double GetSalary() => salary;

            public float SetExp(float exp) => workExpernc = exp;
            public double SetSalary(double salar) => salary = salar;
        }


        public class Student : People
        {

            protected int id = 0;
            protected static int NextID = 1;
            string StudBilet { get; set; } = "";
            string grouppa { get; set; } = "";
            bool isPaidEducation { get; set; }
            public Student()
            {
                role = "Студент";
                id = NextID++;
            }

            public string GetRole() => role;
            public string GetGrouppa() => grouppa;
            public bool GetPaidEducation() => isPaidEducation;

            public string GetStud() => StudBilet;


            public int GetID() => id;
            public void SetStud(string value) => StudBilet = value;
            public void SetGroup(string value) => grouppa = value;
            public void SetPaidorFree(bool value) => isPaidEducation = value;
        }


        public class Courses
        {
            protected int ID = 0;
            protected static int NextID = 1;
            protected string title { get; set; } = "";
            protected int id_Teacher { get; set; }
            protected string description { get; set; } = "";
            protected int countHours { get; set; }

            public Courses()
            {
                ID = NextID++;
            }

            public int GetID() => ID;
            public string GetTitle() => title;
            public int GetTeacher() => id_Teacher;
            public string GetDescription() => description;
            public int GetCountHours() => countHours;


            public void SetTitle(string titlee) => title = titlee;
            public void SetIDteacher(int id) => id_Teacher = id;
            public void SetDescription(string descr) => description = descr;
            public int SetHours(int hours) => countHours = hours;
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

                    if (choice.ToLower() == "да")
                    {
                        continueAdding = true;
                    }
                    if (choice.ToLower() == "нет")
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
    static List<University.Teacher> teachers = new List<University.Teacher>();
    static List<University.Courses> courses = new List<University.Courses>();

    //Словарь для хранения записей студентов на курсы
    // Key: ID студента, Value: List<ID курсов>
    static Dictionary<int, List<int>> studentCourses = new Dictionary<int, List<int>>();

    // Словарь для студентов, записанных на курс
    // Key: ID курса, Value: List<ID студентов>
    static Dictionary<int, List<int>> courseStudents = new Dictionary<int, List<int>>();

    static public void PrintStudent()
    {
        if (students.Count > 0)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"id: {student.GetID()}, роль: {student.GetRole()} имя: {student.GetName()}, фамилия: {student.GetSurname()}, дата рождения: {student.GetBirthday()},\nномер студ. билета: {student.GetStud()}, группа обучения: {student.GetGrouppa()}\n" +
                    $"учится платно: {student.GetPaidEducation()}, город проживания: {student.GetCity()}, номер тел: {student.GetPhone()}");

                // Показываем курсы студента, если они есть
                if (studentCourses.ContainsKey(student.GetID()) && studentCourses[student.GetID()].Count > 0)
                {
                    Console.WriteLine("Записан на курсы:");
                    foreach (var courseId in studentCourses[student.GetID()])
                    {
                        var course = courses.FirstOrDefault(c => c.GetID() == courseId);
                        if (course != null)
                        {
                            Console.WriteLine($"  - {course.GetTitle()}");
                        }
                    }
                }
                Console.WriteLine(); // Пустая строка для разделения
            }
        }
        else
        {
            Console.WriteLine("Нет студентов!");
        }
    }

    static public void ADDTeacher()
    {

        Console.WriteLine("===  Добавление учителя  ===");
        bool continadd = true;
        while (continadd)
        {
            var teacher = new University.Teacher();
            while (true)
            {
                Console.WriteLine("Введите имя учителя: ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    teacher.SetName(name);
                    break;
                }
                else
                {
                    Console.WriteLine("Имя должно быть введено верно!");
                }
            }
            while (true)
            {
                Console.WriteLine("Введите фамилию учителя: ");
                string surname = Console.ReadLine();
                if (!string.IsNullOrEmpty(surname))
                {
                    teacher.SetSurname(surname);
                    break;
                }
                else
                {
                    Console.WriteLine("Фамилия должна быть введена верно!");
                }
            }

            while (true)
            {
                Console.WriteLine("Введите дату рождения учителя: ");
                if (DateOnly.TryParse(Console.ReadLine(), out DateOnly result))
                {
                    if ((DateTime.Now.Year - result.Year) > 0)
                    {
                        teacher.SetBirthday(result);
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
                Console.WriteLine("Введите номер телефона учителя:");
                string numb = Console.ReadLine();
                if (!string.IsNullOrEmpty(numb))
                {
                    teacher.SetPhone(numb);
                    break;
                }
                else
                {
                    Console.WriteLine("Номер телефона не может быть пустым!");
                }
            }

            while (true)
            {
                Console.WriteLine("Введите город учителя:");
                string city = Console.ReadLine();
                if (!string.IsNullOrEmpty(city))
                {
                    teacher.SetCity(city);
                    break;
                }
                else
                {
                    Console.WriteLine("Город не может быть пустым!");
                }
            }

            while (true)
            {
                Console.WriteLine("Введите стаж учителя:");
                if (float.TryParse(Console.ReadLine(), out float stag))
                {
                    teacher.SetExp(stag);
                    break;
                }
                else
                {
                    Console.WriteLine("Стаж должен быть числом!");
                }
            }

            while (true)
            {
                Console.WriteLine("Введите ЗП учителя:");
                if (double.TryParse(Console.ReadLine(), out double zp))
                {
                    teacher.SetSalary(zp);
                    break;
                }
                else
                {
                    Console.WriteLine("Зарплата должна быть числом!");
                }
            }

            if (teacher != null)
            {
                teachers.Add(teacher);
                Console.WriteLine("Учитель успешно добавлен. Продолжить? (да/нет)");
                string choice = Console.ReadLine();
                if (!string.IsNullOrEmpty(choice))
                {

                    if (choice.ToLower() == "да")
                    {
                        continadd = true;
                    }
                    if (choice.ToLower() == "нет")
                    {
                        continadd = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Не все поля заполнены. Не удалось добавить студента.");
            }
        }
    }

    public static void PrintTeachers()
    {
        if (teachers.Count > 0)
        {
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"{teacher.GetID()}, роль: {teacher.GetRole()}, имя: {teacher.GetName()}, фамилия: {teacher.GetSurname()}, дата рождения: {teacher.GetBirthday()},\n" +
                    $"город проживания: {teacher.GetCity()}, номер телефона: {teacher.GetPhone()}, стаж: {teacher.GetExp()}, зарплата: {teacher.GetSalary()}");

                // Показываем курсы преподавателя
                var teacherCourses = courses.Where(course => course.GetTeacher() == teacher.GetID()).ToList();
                if (teacherCourses.Any())
                {
                    Console.WriteLine("Ведет курсы:");
                    foreach (var course in teacherCourses)
                    {
                        Console.WriteLine($"  - {course.GetTitle()}");
                    }
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Нет учителей!");
        }
    }

    static public void AddCourses()
    {
        Console.WriteLine("===  Добавление курса  ===");
        bool adding = true;
        while (adding)
        {
            var Course = new University.Courses();
            while (true)
            {
                Console.WriteLine("Введите название курса:");
                string titlecourse = Console.ReadLine();
                if (!string.IsNullOrEmpty(titlecourse))
                {
                    Course.SetTitle(titlecourse);
                    break;
                }
                else
                {
                    Console.WriteLine("Название не может быть пустым!");
                }
            }
            while (true)
            {
                Console.WriteLine("Введите id учителя, ведущего курс:");
                if (int.TryParse(Console.ReadLine(), out int teacherID))
                {
                    var teacher = teachers.FirstOrDefault(t => t.GetID() == teacherID);
                    if (teacher == null)
                    {
                        Console.WriteLine("Преподаватель с таким ID не найден!");
                        continue;
                    }
                    else
                    {
                        Course.SetIDteacher(teacherID);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("ID должен быть числом!");
                }
            }
            bool addDescript = true;
            while (addDescript)
            {
                Console.WriteLine("Введите описание курса: ");
                string courseDescription = Console.ReadLine();
                if (string.IsNullOrEmpty(courseDescription))
                {
                    Console.WriteLine("Вы уверены, что хотите оставить описание курса пустым?");
                    string choice = Console.ReadLine();
                    if (choice.ToLower() == "да")
                    {
                        addDescript = false;
                        break;
                    }
                    else
                        continue;
                }
                else
                {
                    Course.SetDescription(courseDescription);
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("Введите количество часов изучения курса: ");
                if (int.TryParse(Console.ReadLine(), out int countH))
                {
                    if (countH > 0)
                    {
                        Course.SetHours(countH);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Количество часов не может быть отрицательным!");
                    }
                }
                else
                {
                    Console.WriteLine("Количество часов не может быть пустым!");
                }
            }

            if (Course != null)
            {
                courses.Add(Course);
                Console.WriteLine("Курс успешно добавлен! Желаете продолжить? (да/нет)");
                string choice = Console.ReadLine();
                if (!string.IsNullOrEmpty(choice))
                {

                    if (choice.ToLower() == "да")
                    {
                        adding = true;
                    }
                    if (choice.ToLower() == "нет")
                    {
                        adding = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Не все поля заполнены. Не удалось добавить курс.");
            }
        }
    }

    static public void PrintCourses()
    {
        if (courses.Count > 0)
        {
            Console.WriteLine("====    Курсы     ====");
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.GetID()}, название: {course.GetTitle()}, id преподавателя: {course.GetTeacher()}\n" +
                    $"количество часов: {course.GetCountHours()}");
                Console.WriteLine();
                if (!string.IsNullOrEmpty(course.GetDescription()))
                {
                    Console.WriteLine($"описание курса: {course.GetDescription()}");
                }
            }
        }
        else
        {
            Console.WriteLine("Нет курсов!");
        }
    }

    static public void EnrollmentCourses()
    {
        Console.WriteLine("=== Запись студента на курс ===");

        // Показываем всех студентов
        if (students.Count == 0)
        {
            Console.WriteLine("Нет студентов в системе!");
            return;
        }

        Console.WriteLine("Список студентов:");
        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.GetID()}, {student.GetName()} {student.GetSurname()}");
        }

        // Показываем все курсы
        if (courses.Count == 0)
        {
            Console.WriteLine("Нет курсов в системе!");
            return;
        }

        Console.WriteLine("\nСписок курсов:");
        foreach (var course in courses)
        {
            var teacher = teachers.FirstOrDefault(t => t.GetID() == course.GetTeacher());
            string teacherName = teacher != null ? $"{teacher.GetName()} {teacher.GetSurname()}" : "Не назначен";
            Console.WriteLine($"ID: {course.GetID()}, {course.GetTitle()} (Преподаватель: {teacherName})");
        }

        // Получаем ID студента
        Console.WriteLine("\nВведите ID студента, которого хотите записать на курс: ");
        if (int.TryParse(Console.ReadLine(), out int studID))
        {
            var student = students.FirstOrDefault(s => s.GetID() == studID);
            if (student == null)
            {
                Console.WriteLine("Студент с таким ID не найден!");
                return;
            }

            // Получаем ID курса
            Console.WriteLine("Введите ID курса, на который хотите записать студента:");
            if (int.TryParse(Console.ReadLine(), out int courseID))
            {
                var course = courses.FirstOrDefault(c => c.GetID() == courseID);
                if (course == null)
                {
                    Console.WriteLine("Курс с таким ID не найден!");
                    return;
                }

                // Записываем студента на курс
                EnrollStudentInCourse(studID, courseID);
            }
            else
            {
                Console.WriteLine("Неверный формат ID курса!");
            }
        }
        else
        {
            Console.WriteLine("Неверный формат ID студента!");
        }
    }

    // метод для записи студента на курс
    static public void EnrollStudentInCourse(int studentId, int courseId)
    {
        // Добавляем в словарь studentCourses
        if (!studentCourses.ContainsKey(studentId))
        {
            studentCourses[studentId] = new List<int>();
        }

        if (!studentCourses[studentId].Contains(courseId))
        {
            studentCourses[studentId].Add(courseId);
            Console.WriteLine($"Студент ID {studentId} успешно записан на курс ID {courseId}");
        }
        else
        {
            Console.WriteLine("Студент уже записан на этот курс!");
            return;
        }

        // Добавляем в словарь courseStudents
        if (!courseStudents.ContainsKey(courseId))
        {
            courseStudents[courseId] = new List<int>();
        }

        courseStudents[courseId].Add(studentId);
    }

    static public void ShowStudentCourses()
    {
        Console.WriteLine("Введите ID студента: ");
        if (int.TryParse(Console.ReadLine(), out int studentId))
        {
            var student = students.FirstOrDefault(s => s.GetID() == studentId);
            if (student == null)
            {
                Console.WriteLine("Студент не найден!");
                return;
            }

            Console.WriteLine($"\nКурсы студента {student.GetName()} {student.GetSurname()}:");

            if (studentCourses.ContainsKey(studentId) && studentCourses[studentId].Count > 0)
            {
                foreach (var courseId in studentCourses[studentId])
                {
                    var course = courses.FirstOrDefault(c => c.GetID() == courseId);
                    if (course != null)
                    {
                        var teacher = teachers.FirstOrDefault(t => t.GetID() == course.GetTeacher());
                        string teacherName = teacher != null ? $"{teacher.GetName()} {teacher.GetSurname()}" : "Не назначен";
                        Console.WriteLine($"- {course.GetTitle()} (Преподаватель: {teacherName})");
                    }
                }
            }
            else
            {
                Console.WriteLine("Студент не записан ни на один курс.");
            }
        }
        else
        {
            Console.WriteLine("Неверный формат ID!");
        }
    }

    // метод: Показать всех студентов на курсе
    static public void ShowCourseStudents()
    {
        Console.WriteLine("Введите ID курса: ");
        if (int.TryParse(Console.ReadLine(), out int courseId))
        {
            var course = courses.FirstOrDefault(c => c.GetID() == courseId);
            if (course == null)
            {
                Console.WriteLine("Курс не найден!");
                return;
            }

            Console.WriteLine($"\nСтуденты на курсе '{course.GetTitle()}':");

            if (courseStudents.ContainsKey(courseId) && courseStudents[courseId].Count > 0)
            {
                foreach (var studentId in courseStudents[courseId])
                {
                    var student = students.FirstOrDefault(s => s.GetID() == studentId);
                    if (student != null)
                    {
                        Console.WriteLine($"- {student.GetName()} {student.GetSurname()} (Группа: {student.GetGrouppa()})");
                    }
                }
            }
            else
            {
                Console.WriteLine("На курс не записан ни один студент.");
            }
        }
        else
        {
            Console.WriteLine("Неверный формат ID!");
        }
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== Университет - Главное меню ===");
            Console.WriteLine("1. Добавить студента");
            Console.WriteLine("2. Показать всех студентов");
            Console.WriteLine("3. Добавить учителя");
            Console.WriteLine("4. Показать всех учителей");
            Console.WriteLine("5. Добавить курс");
            Console.WriteLine("6. Показать все курсы");
            Console.WriteLine("7. Записать студента на курс"); 
            Console.WriteLine("8. Показать курсы студента");  
            Console.WriteLine("9. Показать студентов на курсе");
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
                    case 3:
                        ADDTeacher();
                        break;
                    case 4:
                        PrintTeachers();
                        break;
                    case 5:
                        AddCourses();
                        break;
                    case 6:
                        PrintCourses();
                        break;
                    case 7: 
                        EnrollmentCourses();
                        break;
                    case 8: 
                        ShowStudentCourses();
                        break;
                    case 9:
                        ShowCourseStudents();
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