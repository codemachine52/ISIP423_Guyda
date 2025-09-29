using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

public class User
{
    public string FullName { get; set; }
    public string Login { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<string> Hobbies { get; set; }

    public User(string fullName, string login, DateTime dateOfBirth, List<string> hobbies)
    {
        FullName = fullName;
        Login = login;
        DateOfBirth = dateOfBirth;
        Hobbies = hobbies;
    }
}

class Program
{
    public static void overThirty(List<User> users)
    {
        int now = DateTime.Now.Year;
        var olds = users.Where(user => (now - user.DateOfBirth.Year) > 30).ToList();
        foreach (var old in olds)
        {
            Console.WriteLine($"ФИО: {old.FullName}, возраст: {now - old.DateOfBirth.Year}");
        }
    }

    public static void Logins(List<User> users)
    {
        var logins = users.OrderBy(user => user.Login).ToList();
        foreach (var user in logins)
        {
            Console.WriteLine(user.Login);
        }
    }

    public static void Programists(List<User> users)
    {
        var programists = users.Where(user => (user.Hobbies.Contains("Программирование"))).ToList();
        Console.WriteLine("Люди - программисты: ");
        foreach (var user in programists)
        {
            Console.WriteLine($"{user.Login}, ФИО: {user.FullName}");
        }
    }

    public static void BirthYear(List<User> users)
    {
        var yearGroups = users.GroupBy(user => user.DateOfBirth.Year).OrderBy(group => group.Key);

        foreach (var user in yearGroups)
        {
            Console.WriteLine($"Год: {user.Key} -> {user.Count()} человек");
        }
    }



    static void Main()
    {
        var users = new List<User>
{
    new User("Иванов Иван Иванович",  "ivanovii",   new DateTime(1990, 5, 18), new List<string> { "Чтение", "Путешествия", "Программирование" }),
    new User("Петров Петр Петрович",  "petrovpp",   new DateTime(1985, 10, 2), new List<string> { "Футбол", "Кулинария" }),
    new User("Сидорова Анна Михайловна","sidorovana", new DateTime(2000, 3, 15), new List<string> { "Рисование", "Программирование" }),
    new User("Смирнов Алексей Николаевич","smirnovan",new DateTime(1995, 7, 30), new List<string> { "Хоккей", "Фотография" }),
    new User("Кузнецова Ольга Валерьевна","kuznetsovao",new DateTime(1992, 12, 12), new List<string> { "Йога", "Путешествия" })
};

        Console.WriteLine("старше 30: ");
        overThirty(users);
        Console.WriteLine();
        Console.WriteLine("логины по алфавиту:");
        Logins(users);
        Console.WriteLine();
        Programists(users);
        Console.WriteLine();
        BirthYear(users);
        Console.WriteLine();
    }
}
