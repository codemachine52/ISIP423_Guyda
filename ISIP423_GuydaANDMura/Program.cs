using System;

class Program
{
    enum categories
    {
        food = 1,
        groceries,
        careProducts
    }
    class Product
    {
        int Id = 0;
        string Name = "";
        double price = 0;
        int countProd = 0;
        bool IsProd;
        int ProdCateg;
        public void GetProduct()
        {
            Id += 1;
            Console.WriteLine("Введите название товара: ");
            while (true)
            {
                Name = Console.ReadLine();
                if (Name == null)
                {
                    Console.WriteLine("введите название товара еще раз!");
                }
                else break;
            }
            Console.WriteLine("Введите цену товара: ");
            while (true)
            {
                price = Convert.ToDouble(Console.ReadLine());
                if ((price == null) || (price <= 0))
                {
                    Console.WriteLine("Неправильно введена цена! попробуйте снова!");
                }
                else break;
            }
            Console.WriteLine("Введите количество товара: ");
            while (true)
            {
                countProd = Convert.ToInt32(Console.ReadLine());
                if ((countProd == null) || (countProd <= 0))
                {
                    Console.WriteLine("Неправильно введено количество! попробуйте снова!");
                }
                else break;
            }
            if (countProd > 0)
            {
                IsProd = true;
            }
            else IsProd = false;
            Console.WriteLine("Введите категорию товара от 1 до 3: ");
            while (true)
            {
                ProdCateg = Convert.ToInt32(Console.ReadLine());
                if ((ProdCateg == null) || (ProdCateg < 1) || (ProdCateg > 3))
                {
                    Console.WriteLine("Неправильно введена категория! попробуйте снова!");
                }
                else break;
            }
            categories selectedCategory = (categories)ProdCateg;
            switch (selectedCategory)
            {
                case categories.food:
                    {
                        Console.WriteLine("Категория: еда");
                        break;
                    }
                case categories.groceries:
                    {
                        Console.WriteLine("Категория: бакалея");
                        break;
                    }
                case categories.careProducts:
                    {
                        Console.WriteLine("Категория: товары для ухода");
                        break;
                    }
            }
        }
        public void PrintProduct(Product p)
        {
            Console.WriteLine($"{p.Id}, {p.Name}, {p.countProd}, {p.IsProd}, {p.ProdCateg}");
        }
    }
}
