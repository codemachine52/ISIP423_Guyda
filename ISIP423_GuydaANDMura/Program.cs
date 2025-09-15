using System;

class Program
{
    
    static void Main()
    {
        vvod();
        int menu = Convert.ToInt32(Console.ReadLine());
        switch (menu)
        {
            case 0:
                break;
            case 1: vivod(tovari);
                break;

        }
    }

    static void vvod()
    {
        string[] tovari = new string[90];
        string[] nazv = new string[40];
        double[] price = new double[40];
        Console.WriteLine("Введите количество операций: (от 2 до 40) ");
        int kolvo = Convert.ToInt32(Console.ReadLine());
        while (kolvo <= 40)
        {
            for (int i = 0; i < nazv.Length; i++)
            {
                nazv[i] = Console.ReadLine();
                price[i] = Convert.ToDouble(Console.ReadLine());
                tovari[i] = nazv[i] + ";" + price[i].ToString();
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
}