using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static string[] tovari;
    static string[] nazv;
    static double[] price;
    static int actualCount;
    static void Main()
    {
        
        bool flag = true;
        Vvod();
        while (flag)
        {
            Console.WriteLine("Введите число: 1 - вывести всю инф, 2 - статистика покупок, 3 - cортировка по возр. по цене 0 - выход.");
            int menu = Convert.ToInt32(Console.ReadLine());
            if (menu == 0)
            {
                flag = false;
            }
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
                        statistika(price, actualCount);
                        break;
                    }
                case 3:
                    {
                        sortirov(tovari);
                        break;
                    }
            }
        }
    }
    static void Vvod()
    {

        Console.WriteLine("Введите количество операций: (от 2 до 40) ");
        int kolvo = Convert.ToInt32(Console.ReadLine());
        while (kolvo < 2 || kolvo > 40)
        {
            Console.WriteLine("Неверно! Введите другое количество!");
            kolvo = Convert.ToInt32(Console.ReadLine());
        }
        actualCount = kolvo;
        tovari = new string[kolvo];
        nazv = new string[kolvo];
        price = new double[kolvo]; ;
        for (int i = 0; i < kolvo; i++)
        {
            Console.WriteLine("Введите название: ");
            nazv[i] = Console.ReadLine();
            Console.WriteLine("Введите цену: ");
            price[i] = Convert.ToDouble(Console.ReadLine());
            tovari[i] = nazv[i] + " " + price[i].ToString() + "руб.";
        }
    }
    static void vivod(string[] tovari)
    {
        foreach (string tovar in tovari)
        {
            Console.WriteLine(tovar);
        }
    }
    static void statistika(double[] price, int count)
    {
        if (count == 0)
        {
            Console.WriteLine("Нет данных для статистики!");
            return;
        }
        double min = price[0];
        double max = price[0];
        double sum = 0;

        for (int i = 0; i < price.Length; i++)
        {
            if (price[i] < min)
            {
                min = price[i];
            }
            if (price[i] > max)
            {
                max = price[i];
            }
            sum += price[i];
        }

        double avg = sum / price.Length;
        Console.WriteLine($"Максимальная сумма покупки: {max}");
        Console.WriteLine($"Минимальная сумма покупки: {min}");
        Console.WriteLine($"Средняя сумма покупок: {avg}");
        Console.WriteLine($"Общая сумма покупок: {sum}");
    }

    static void sortirov(string[] tovari)
    {
        // Сортируем параллельно массивы nazv и price
        for (int i = 0; i < price.Length - 1; i++)
        {
            for (int j = 0; j < price.Length - 1 - i; j++)
            {
                if (price[j] > price[j + 1])
                {
                    // Меняем местами цены
                    double tempPrice = price[j];
                    price[j] = price[j + 1];
                    price[j + 1] = tempPrice;

                    // Меняем местами названия
                    string tempNazv = nazv[j];
                    nazv[j] = nazv[j + 1];
                    nazv[j + 1] = tempNazv;
                }
            }
        }

        // Обновляем массив tovari после сортировки
        for (int i = 0; i < tovari.Length; i++)
        {
            tovari[i] = nazv[i] + " " + price[i].ToString() + "руб.";
        }
        for(int i = 0; i < tovari.Length; i++)
        {
            Console.WriteLine(tovari[i]);
        }
    }
}