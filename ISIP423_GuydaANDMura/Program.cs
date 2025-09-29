using System;
using System.Collections;
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
        var yearGroups = users.GroupBy(user => user.DateOfBirth.Year).OrderBy(group => group.Key).ToList();
        foreach (var user in yearGroups)
        {
            Console.WriteLine($"Год: {user.Key} -> {user.Count()} человек");
        }
    }

    public static void CreateDictionary(List<User> users)
    {
        var diction = users.ToDictionary(user => user.Login, user => user.FullName);
        foreach(var user in diction)
        {
            Console.WriteLine($"логин: {user.Key}, ФИО: {user.Value}");
        }
    }

    public static void theOldestandYoungest(List<User> users)
    {

        int now = DateTime.Now.Year;
        var sortedyear = users.OrderBy(user => (now - user.DateOfBirth.Year)).ToList();

        var theOldest = sortedyear.LastOrDefault();
        var theYoungest = sortedyear.FirstOrDefault();
        Console.WriteLine($"самый молодой: {theYoungest.FullName} ({now - theYoungest.DateOfBirth.Year} лет)\n" +
            $"самый старший: {theOldest.FullName} ({now - theOldest.DateOfBirth.Year} лет)");
    }

    public static void UniqueHobbies(List<User> users)
    {

    var uniqueHobbies = users.SelectMany(u => u.Hobbies)
     // С SelectMany - получаем один плоский список:
    // ["Чтение", "Путешествия", "Программирование", "Футбол", "Кулинария", "Рисование", "Программирование"]
                              .GroupBy(h => h)
                              .Where(g => g.Count() == 1)
                              .Select(g => g.Key);

        Console.WriteLine("Уникальные хобби (с одним участником):");
        foreach (var hobby in uniqueHobbies)
        {
            Console.WriteLine($"{hobby}");
        }
    }

    public static void travellers(List<User> users)
    {
        var travellers = users.Where(user => user.Hobbies.Contains("Путешествия")).ToList();
        Console.WriteLine("ПУТЕШЕСТВЕННИКИ:");
        foreach (var traveller in travellers)
        {
            Console.WriteLine($"ФИО: {traveller.FullName}");
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
        CreateDictionary(users);
        Console.WriteLine();
        theOldestandYoungest(users);
        Console.WriteLine();
        UniqueHobbies(users);
        Console.WriteLine();
        travellers(users);
        Console.WriteLine();
    }
}
