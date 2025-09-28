using System;

class Program
{
    static List<string> texts = new List<string>();
    static bool GetText()
    {
        Console.WriteLine("Введите текст: ");
        string text = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(text)) // Проверяем, не пустой ли текст
        {
            texts.Add(text);
            return true;
        }
        else
        {
            Console.WriteLine("Текст не может быть пустым!");
            return false;
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

    static void theShortest()
    {
        string[] words = WordsInText();
        if (words.Length == 0)
        {
            Console.WriteLine("Нет слов для анализа!");
            return;
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
        Console.WriteLine($"Самое короткое слово в тексте: {word}, состоит из {min} символов");
    }

    static void Longest()
    {
        string[] words = WordsInText();
        if (words.Length == 0)
        {
            Console.WriteLine("Нет слов для анализа!");
            return;
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
        Console.WriteLine($"Самое длинное слово в тексте: {word}, состоит из {max} символов");
    }

    static void SentensesCount()
    {
        int count = 0;
        foreach (string text in texts)
        {
            string[] sentenses = text.Split(new char[] { '.', '!', '?' });
            count = sentenses.Length-1;
        }
        Console.WriteLine($"Количество предложений в тексте: {count}");
    }

    static void glasnSogl()
    {
        char[] glasnie = {'а', 'е', 'ы', 'э', 'о', 'у', 'я', 'ю', 'и'};
        int countg = 0;
        int countsog = 0;
        string[] words = WordsInText();
        foreach (string word in words) {
        {
                foreach (char i in word)
                {
                    if (glasnie.Contains(i))
                    {
                        countg++;
                    }
                    else
                    {
                        if ((i != '.') || (i != ',') || (i != ' ') || (i != '!') || (i != '?') && char.IsLetter(i))
                        {
                            countsog++;
                        }
                    }
                }
            }
        }
        Console.WriteLine($"кол-во гласных: {countg}, количество согласных: {countsog}");
    }


    static void Main()
    {
        GetText();
        int countwords = WordsInText().Length;
        Console.WriteLine($"Количество слов в тексте: {countwords}");
        theShortest();
        SentensesCount();
        glasnSogl();
        Longest();
    }
}
