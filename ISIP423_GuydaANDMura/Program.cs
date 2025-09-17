using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static string[] tovari;
    static string[] nazv = new string[40];
    static double[] price = new double[40];

    static void vvod()
    {

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
            tovari[i] = nazv[i] + " " + price[i].ToString() + "руб.";
        }
    }
    static void Main()
    {
        bool flag = true;
        vvod();
        Console.WriteLine("Введите число: 1 - вывести всю инф, 2 - статистика покупок, 0 - выход.");
        int menu = Convert.ToInt32(Console.ReadLine());
        {
            switch (menu)
            {
                case 0:
                    break;
                case 1:
                    {
                        vivod(tovari);
                        break;
                    }
                case 2:
                    {
                        statistika(price);
                        break;
                    }
            }
        }
    }
    static void vivod(string[] tovari)
    {
        foreach (string tovar in tovari)
        {
            Console.WriteLine(tovar);
        }
    }
    static void statistika(double [] price)
    {
        double min, max, avg, sum=0;
        min = price[0];
        max = price[price.Length - 1];
        
        for (int i = 0; i < price.Length; i++)
        {
            if (price[i] < min) { min = price[i]; }
            if (price[i] > max) { max = price[i]; }
            sum += price[i];
        }
        
        int kolvo = price.Length;
        avg = sum/ kolvo;
        Console.WriteLine($"Максимальная сумма: {max}");
    }
}