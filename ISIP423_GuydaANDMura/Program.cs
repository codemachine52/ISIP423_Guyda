using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

var users = new List<User>
{
    new User("Иванов Иван Иванович",  "ivanovii",   new DateTime(1990, 5, 18), new List<string> { "Чтение", "Путешествия", "Программирование" }),
    new User("Петров Петр Петрович",  "petrovpp",   new DateTime(1985, 10, 2), new List<string> { "Футбол", "Кулинария" }),
    new User("Сидорова Анна Михайловна","sidorovana", new DateTime(2000, 3, 15), new List<string> { "Рисование", "Программирование" }),
    new User("Смирнов Алексей Николаевич","smirnovan",new DateTime(1995, 7, 30), new List<string> { "Хоккей", "Фотография" }),
    new User("Кузнецова Ольга Валерьевна","kuznetsovao",new DateTime(1992, 12, 12), new List<string> { "Йога", "Путешествия" })
};

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

    public void overThirty(List<User> users) 
    {
        DateTime now = DateTime.Now;
        var olds = users.Where(users => ((now - users.DateOfBirth).TotalDays) / 365 > 30);
        foreach (var old in olds)
        {
            Console.WriteLine(old.FullName, old.DateOfBirth);
        }
    }
}
