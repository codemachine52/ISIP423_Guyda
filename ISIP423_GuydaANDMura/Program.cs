using System;
using System.ComponentModel.Design;

class Program
{

    static List<Books> books = new List<Books>();
    class Books
    {
        int id = 0;
        static int nextID = 1;
        string title { get; set; } = "";
        string author { get; set; } = "";
        int type { get; set; }
        string stype { get; set; } = "";
        int year { get; set; }
        int price { get; set; }


        static public void GetBooks()
        {
            bool flag = true;
            while (flag)
            {
                var book = new Books();


                while (true)
                {
                    Console.WriteLine("Введите название книги: ");
                    string title = Console.ReadLine();
                    if (String.IsNullOrEmpty(title))
                    {
                        Console.WriteLine("Введите название книги еще раз!");

                    }
                    else if (title.ToLower() == "выход")
                    {
                        flag = false;
                        break;
                    }
                    else
                    {
                        book.title = title;
                        break;
                    }
                }
                if (!flag) break;

                while (true)
                {

                    Console.WriteLine("Введите автора книги: ");
                    string author = Console.ReadLine();
                    if (String.IsNullOrEmpty(author))
                    {
                        Console.WriteLine("Введите автора книги еще раз!");
                    }
                    else
                    {
                        book.author = author;
                        break;
                    }
                }
                while (true)
                {
                    Console.WriteLine("Введите жанр книги от 1 до 3, где:\n" +
                        "1 - детектив\n" +
                        "2 - фантастика\n" +
                        "3 - ужасы ");
                    if (!int.TryParse(Console.ReadLine(), out int btype))
                    {
                        Console.WriteLine("Неправильно введен жанр! Попробуйте еще раз!");
                    }
                    else
                    {
                        book.type = btype;
                        break;
                    }
                }
                while (true)
                {
                    Console.WriteLine("Введите год издания книги: ");
                    if (!int.TryParse(Console.ReadLine(), out int byear))
                    {
                        Console.WriteLine("Неправильно введен год! Попробуйте снова!");
                    }
                    else
                    {
                        book.year = byear;
                        break;
                    }
                }

                while (true)
                {
                    Console.WriteLine("Введите цену книги: ");
                    if (!int.TryParse(Console.ReadLine(), out int bprice))
                    {
                        Console.WriteLine("Неправильно введена цена! Попробуйте снова!");
                    }
                    else
                    {
                        book.price = bprice;
                        break;
                    }
                }
                int btype1 = book.type;
                switch (btype1)
                {
                    case 1:
                        {
                            book.stype = "Детектив";
                            break;
                        }
                    case 2:
                        {
                            book.stype = "Фантастика";
                            break;
                        }
                    case 3:
                        {
                            book.stype = "Ужасы";
                            break;
                        }
                }

                if (!(book == null))
                {
                    book.id = nextID++;
                    books.Add(book);
                    Console.WriteLine("Книга успешно добавлена!\n");
                }
            }

        }

        static public void PrintBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{book.id}, Книга: {book.title}, автор: {book.author}, жанр: {book.stype}, год издания: {book.year}," +
                    $" цена: {book.price}\n");
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("=== БИБЛИОТЕКА ===");

        while (true)
        {
            Console.WriteLine("Введите действие: \n" +
            "1 - ввести данные о книге(-ах)\n" +
            "2 - вывести данные о книге(-ах)\n" +
            "0 - Выход");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Введите информацию о книге: (если захотите закончить, напишите ВЫХОД вместо названия.)");
                            Books.GetBooks();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("=== КНИГИ ===\n");
                            Books.PrintBooks();
                            break;
                        }
                    case 0:
                        break;

                    default:
                        {
                            Console.WriteLine("Введите корректное число!");
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("Введите корректное число!");
            }
        }
    }
}