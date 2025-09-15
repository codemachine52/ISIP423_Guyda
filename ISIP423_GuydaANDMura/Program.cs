using System;

class Program
{
    static string[] tovari;
    static void Main()
    {
        vvod();
        Console.WriteLine("Введите число: 1 - вывести всю инф, 0 - выход.");
        int menu = Convert.ToInt32(Console.ReadLine());
        switch (menu)
        {
            case 0:
                break;
            case 1: vivod(tovari);
                break;
            case 2:

        }
    }

    static void vvod()
    {
        string[] nazv = new string[40];
        double[] price = new double[40];
        Console.WriteLine("Введите количество операций: (от 2 до 40) ");
        int kolvo = Convert.ToInt32(Console.ReadLine());
        while (kolvo < 2 || kolvo > 40)
        {
            Console.WriteLine("Неверно! Введите другое количество!");
            kolvo = Convert.ToInt32(Console.ReadLine());
        }
        tovari = new string[kolvo];
        for (int i = 0; i < kolvo; i++)
        {
            Console.WriteLine("Введите название: ");
            nazv[i] = Console.ReadLine();
            Console.WriteLine("Введите цену: ");
            price[i] = Convert.ToDouble(Console.ReadLine());
            tovari[i] = nazv[i] + ";" + price[i].ToString();
        }
    }
    static void vivod(string[] tovari)
    {
        foreach (string tovar in tovari)
        {
            Console.WriteLine(tovar);
        }
    }
}