using System;

class Program
{
    class University
    {
        class People
        {
            string name { get; set; } = "";
            string surname { get; set; } = "";
            int age { get; set; }
            string phone { get; set; } = "";
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
            public Student()
            {
                role = "Student";
            }

            public string GetRole() => role;
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