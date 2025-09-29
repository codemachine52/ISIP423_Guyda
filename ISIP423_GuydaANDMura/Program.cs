using System;
using System.Diagnostics.Metrics;

class Program
{
    static List<string> texts = new List<string>();
    static List<string> history = new List<string>();
    static void GetText()
    {
        texts.Clear();
        Console.WriteLine("Введите текст. Когда закончите, напишите ВЫХОД.");
        while (true)
        {
            string text = Console.ReadLine();
            string cleanedText = text?.Trim(); // Убираем пробелы

            // Выход если команда ВЫХОД (в любом регистре)
            if (!string.IsNullOrEmpty(cleanedText) && cleanedText.Equals("ВЫХОД", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            if (!string.IsNullOrWhiteSpace(text)) // Проверяем, не пустой ли текст и что он больше 100 симв.
            {
                texts.Add(text);
            }
            else
            {
                Console.WriteLine("Текст не может быть пустым или слишком коротким!");
                break;
            }
        }
    }

    static string[] WordsInText()
    {
        List<string> allwords = new List<string>();
        foreach (string text in texts)
        {
            if (!string.IsNullOrWhiteSpace(text)) //проверяем текст на пустоту
            {
                // Убираем знаки препинания и разделяем
                string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?', ';', ':', '\t', '\n' },
                StringSplitOptions.RemoveEmptyEntries);
                allwords.AddRange(words);
            }
        }
        return allwords.ToArray();
    }

    static (string shword, int wlenght) theShortest()
    {
        string[] words = WordsInText();
        if (words.Length == 0)
        {
            Console.WriteLine("Нет слов для анализа!");
        }
        int min = words[0].Length;
        string word = words[0];
        for (int i = 1; i < words.Length; i++)
        {
                if (words[i].Length < min && words[i].Length > 1)
                {
                    min = words[i].Length;
                    word = words[i];
                }
        }
        return (word, min);
    }

    static (string lgword, int wlenght) Longest()
    {
        string[] words = WordsInText();
        if (words.Length == 0)
        {
            Console.WriteLine("Нет слов для анализа!");
        }
        int max = words[0].Length;
        string word = words[0];
        for (int i = 1; i < words.Length; i++)
        {
            if (words[i].Length > max && words[i].Length > 1)
            {
                max = words[i].Length;
                word = words[i];
            }
        }
        return (word, max);
    }

    static int SentensesCount()
    {
        int count = 0;
        foreach (string text in texts)
        {
            string[] sentenses = text.Split(new char[] { '.', '!', '?', '\n' }, 
            StringSplitOptions.RemoveEmptyEntries);
            count += sentenses.Length;
        }
        return count;
    }

    static (int glasn, int sogl) glasnSogl()
    {
        char[] glasnie = {'а', 'е', 'ы', 'э', 'о', 'у', 'я', 'ю', 'и', 'ё'};
        int countg = 0;
        int countsog = 0;
        string[] words = WordsInText();
        foreach (string word in words) {
        {
                foreach (char i in word.ToLower())
                {
                    if (glasnie.Contains(i))
                    {
                        countg++;
                    }
                    else
                    {
                        if ((i != '.') && (i != ',') && (i != ' ') && (i != '!') && (i != '?') && char.IsLetter(i))
                        {
                            countsog++;
                        }
                    }
                }
            }
        }
        return(countg, countsog);
    }

    static int counterTexts = 0;

    static void Statistics()
    {
        Console.WriteLine();
        Console.WriteLine("=== СТАТИСТИКА ===");
        int countwords = WordsInText().Length;
        (int glasn, int sogl) = glasnSogl();
        int count = SentensesCount();
        (string shortest, int wlenght) = theShortest();
        (string longest, int wlonglenght) = Longest();
        counterTexts++;

        Console.WriteLine($"кол-во слов в тексте: {countwords}");
        Console.WriteLine($"кол-во гласных: {glasn}, количество согласных: {sogl}");
        Console.WriteLine($"Количество предложений в тексте: {count}");
        Console.WriteLine($"самое короткое слово: {shortest} : {wlenght} символов");
        Console.WriteLine($"самое длинное слово: {longest} : {wlonglenght} символов");
        Console.WriteLine();
        string stats = $"Слов: {countwords}, Предложений: {count}, Гласных: {glasn}, Согласных: {sogl}\n" +
            $" Самое короткое слово: {shortest} : {wlenght} символов, Самое длинное слово: {longest} : {wlonglenght} символов\n";

        history.Add($"Статистика для текста {counterTexts}: \n{stats}");
    }

    static void historystats()
    {
        if (history.Count == 0)
        {
            Console.WriteLine("Нет статистик.");
        }
        else { 
        foreach (string line in history)
        {
            Console.WriteLine(line);
        }
        }
    }

    static void Main()
    {
        Console.WriteLine("=== МЕНЮ ===");
        string input;
        while (true)
        {
            Console.WriteLine("Выберите действие:\n " +
                "1 - ВВЕСТИ ТЕКСТ \n" +
                " 2 - Вывести статистику по тексту\n" +
                " 3 - Вывести все историю статистик по текстам. \n" +
                " 0 - Выход.");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        {
                            GetText();
                            break;
                        }
                    case 2:
                        {
                            Statistics();
                            break;
                        }
                    case 3:
                         {
                            Console.WriteLine();
                            historystats();
                            break;
                         }
                        case 0:
                        {
                            break;
                        }
                }
                if (choice == 0)
                {
                    break;
                }
            }
        }
        
        Console.WriteLine();
        
    }
}
