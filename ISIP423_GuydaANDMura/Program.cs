using System;
using System.ComponentModel.Design;
using System.Diagnostics;

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
        double price { get; set; }


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
                    if (!double.TryParse(Console.ReadLine(), out double bprice))
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

        static public void readyBooks(string name, string author, int type, int year, double price)
        {
            var book = new Books();
            book.id = nextID++;
            book.title = name;
            book.author = author;
            book.type = type;
            book.year = year;
            book.price = price;

            switch(book.type) {
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

            books.Add(book);
        }

        static public void CreateAllReadyBooks()
        {
            readyBooks("Преступление и наказание", "Федор Достоевский", 1, 1866, 500);
            readyBooks("Идиот", "Федор Достоевский", 1, 1866, 800);
            readyBooks("1984", "Джордж Оруэлл", 2, 1949, 450);
            readyBooks("Дракула", "Брэм Стокер", 3, 1897, 600);
            readyBooks("Шерлок Холмс", "Артур Конан Дойл", 1, 1887, 550);
            readyBooks("Марсианин", "Энди Вейер", 2, 2011, 700);

            Console.WriteLine("Все готовые книги добавлены!\n");
        }

        static public void PrintBooks()
        {
            if (books.Count > 0)
            {
                Console.WriteLine("\n=== КНИГИ ===\n");
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.id}, Книга: {book.title}, автор: {book.author}, жанр: {book.stype}, год издания: {book.year}," +
                        $" цена: {book.price}\n");
                }
            }
            else
            {
                Console.WriteLine("Нет книг!\n");
            }
        }

        static public void SearchBook()
        {
            if (books.Count > 0)
            {
                Console.WriteLine("\nвыберите вариант поиска книги:\n" +
                    "1 - по названию\n" +
                    "2 - по автору\n" +
                    "3 - по жанру\n" +
                    "4 - по ID");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine("Введите название книги: ");
                                string nazv = Console.ReadLine();
                                Console.WriteLine();
                                var foundbooks = books.Where(book => book.title.ToLower() == nazv.ToLower()).ToList();
                                if (foundbooks.Count > 0)
                                {
                                    foreach (var book in foundbooks)
                                    {
                                        Console.WriteLine($"{book.id}, Книга: {book.title}, автор: {book.author}, жанр: {book.stype}, год издания: {book.year}," +
                                $" цена: {book.price}\n");
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Книга не найдена!");
                                    break;
                                }
                            }
                        case 2:
                            {
                                Console.WriteLine("Введите автора книги: ");
                                string auth = Console.ReadLine();
                                Console.WriteLine();
                                var foundbooks = books.Where(book => book.author.ToLower() == auth.ToLower()).ToList();
                                if (foundbooks.Count > 0)
                                {
                                    foreach (var book in foundbooks)
                                    {
                                        Console.WriteLine($"{book.id}, Книга: {book.title}, автор: {book.author}, жанр: {book.stype}, год издания: {book.year}," +
                                $" цена: {book.price}\n");
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Книга(-и) не найдены!");
                                    break;
                                }
                            }
                        case 3:
                            {
                                Console.WriteLine("Введите жанр книги: ");
                                string janre = Console.ReadLine();
                                Console.WriteLine();
                                var foundbooks = books.Where(book => book.stype.ToLower() == janre.ToLower()).ToList();
                                if (foundbooks.Count > 0)
                                {
                                    foreach (var book in foundbooks)
                                    {
                                        Console.WriteLine($"{book.id}, Книга: {book.title}, автор: {book.author}, жанр: {book.stype}, год издания: {book.year}," +
                                $" цена: {book.price}\n");
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Книга(-и) не найдены!");
                                    break;
                                }
                            }
                        case 4:
                            {
                                Console.WriteLine("Введите ID книги: ");
                                if (int.TryParse(Console.ReadLine(), out int bookID))
                                {
                                    Console.WriteLine();
                                    var foundbooks = books.Where(book => book.id == bookID).ToList();
                                    if (foundbooks.Count > 0)
                                    {
                                        foreach (var book in foundbooks)
                                        {
                                            Console.WriteLine($"{book.id}, Книга: {book.title}, автор: {book.author}, жанр: {book.stype}, год издания: {book.year}," +
                                    $" цена: {book.price}\n");
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Книга не найдена!");
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("ID введен некорректно!");
                                    break;
                                }
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Введите корректное число для выбора варианта!");
                }
            }
            else
            {
                Console.WriteLine("Книг нет!\n");
            }
        }

        static public void SortBooks()
        {
            if (books.Count > 0)
            {
                Console.WriteLine("\n=== Сортировка книг ===");
                Console.WriteLine("Выберите вариант сортировки из списка ниже:\n" +
                    "1 - по названию (по алфавиту)\n" +
                    "2 - по году издания\n" +
                    "0 - я передумал");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("\nОтсортированные книги: \n");
                    switch (choice)
                    {
                        case 1:
                            {
                                var SortbyTitle = books.OrderBy(book => book.title).ToList();
                                foreach (var book in SortbyTitle)
                                {
                                    Console.WriteLine($"{book.id}, Книга: {book.title}, автор: {book.author}, жанр: {book.stype}, год издания: {book.year}," +
                                    $" цена: {book.price}\n");
                                }
                                break;
                            }
                        case 2:
                            {
                                var SortbyYear = books.OrderBy(book => book.year).ToList();
                                foreach (var book in SortbyYear)
                                {
                                    Console.WriteLine($"{book.id}, Книга: {book.title}, автор: {book.author}, жанр: {book.stype}, год издания: {book.year}," +
                                    $" цена: {book.price}\n");
                                }

                                break;
                            }
                        case 0:
                            {
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Некорректно выбран пункт!");
                }
            }
            else
            {
                Console.WriteLine("Книг нет!\n");
            }
        }

        static public void CheapestExpensive()
        {
            if (books.Count > 0)
            {
                Console.WriteLine("\n=== Поиск ===\n");
                Console.WriteLine("Выберите, что хотите найти:\n" +
                    "1 - самую дорогую книгу\n" +
                    "2 - самую дешевую книгу\n" +
                    "0 - отмена");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    var sortedBooks = books.OrderByDescending(book => book.price).ToList();
                    var expensiveBook = sortedBooks.First();
                    var cheapestBook = sortedBooks.Last();
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine($"{expensiveBook.id}, Книга: {expensiveBook.title}, автор: {expensiveBook.author}, жанр: {expensiveBook.stype}, год издания: {expensiveBook.year}," +
                                    $" цена: {expensiveBook.price}\n");
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine($"{cheapestBook.id}, Книга: {cheapestBook.title}, автор: {cheapestBook.author}, жанр: {cheapestBook.stype}, год издания: {cheapestBook.year}," +
                                   $" цена: {cheapestBook.price}\n");
                                break;
                            }
                        case 0:
                            {
                                break;
                            }
                    }
                }
            }
            else
            {
                Console.WriteLine("Книг нет!\n");
            }
        }

        static public void DeleteBook()
        {
            if (books.Count > 0)
            {
                Console.WriteLine("Введите ID книги, которую хотите удалить: ");
                if (int.TryParse(Console.ReadLine(), out int bid))
                {
                    int removedbook = books.RemoveAll(b => b.id == bid);
                    if (removedbook > 0)
                    {
                        Console.WriteLine($"Книга с id {bid} успешно удалена.\n");
                    }
                    else
                    {
                        Console.WriteLine("Не удалось найти книгу с таким id!\n");
                    }
                }
                else
                {
                    Console.WriteLine("Неправильно введен ID!\n");
                }
            }
            else
            {
                Console.WriteLine("Книг нет!\n");
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("=== БИБЛИОТЕКА ===");

        while (true)
        {
            Console.WriteLine("Введите действие: \n" +
            "1 - ввести данные о книге(-ах) вручную\n" +
            "2 - работать с готовыми данными\n" +
            "3 - вывести данные о книге(-ах)\n" +
            "4 - удалить книгу по ID\n" +
            "5 - найти книгу\n" +
            "6 - отсортировать книги\n" +
            "7 - поиск самой дорогой и самой дешевой книги\n" +
            "8 - сгруппировать книги по авторам\n" +
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
                            Books.CreateAllReadyBooks();
                            break;
                        }
                    case 3:
                        {
                            Books.PrintBooks();
                            break;
                        }
                    case 4:
                        {
                            Books.DeleteBook(); 
                            break;
                        }
                    case 5:
                        {
                            Books.SearchBook();
                            break;
                        }
                    case 6:
                        {
                            Books.SortBooks(); 
                            break;
                        }
                    case 7:
                        {
                            Books.CheapestExpensive();
                            break;
                        }
                    case 0:
                        {
                            return;
                        }

                    default:
                        {
                            Console.WriteLine("Введите корректное число!\n");
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("Введите корректное число!\n");
            }
        }
    }
}