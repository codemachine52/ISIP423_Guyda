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
        int[] glasnie = { 224, 229, 232, 238, 243, 251, 253, 254, 255 };
        int countg = 0;
        int countsog = 0;
        string[] words = WordsInText();
        for (int i = 0; i < words.Length; i++)
        {
            for(int j = 0; j < words[i].Length; j++)
            {
                if ((words[i][j] == 'а') || (words[i][j] == 'е') || (words[i][j] == 'и') || (words[i][j] == 'о') || (words[i][j] == 'ы') ||
                    (words[i][j] == 'у') || (words[i][j] == 'э') || (words[i][j] == 'я') || (words[i][j] == 'ю'))
                {
                    countg++;
                }
                else
                {
                    if ((words[i][j] != '.') || (words[i][j] != ',') || (words[i][j] != ' ') || (words[i][j] != '!') || (words[i][j] != '?'))
                    {
                        countsog++;
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
    }
}
