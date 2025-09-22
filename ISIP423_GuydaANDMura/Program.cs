using System;
using System.Collections.Generic;

class Program
{
    enum Categories
    {
        food = 1,
        groceries,
        careProducts
    }

    class Product
    {
        static int nextId = 1;
        public int Id { get; private set; }
        public string Name { get; set; } = "";
        public double Price { get; set; }
        public int CountProd { get; set; }
        public bool IsProd { get; set; }
        public int ProdCateg { get; set; }

        public bool GetProduct()
        {
            Console.WriteLine("Введите название товара (или 'Выход' для завершения): ");
            while (true)
            {
                Name = Console.ReadLine();
                if (string.IsNullOrEmpty(Name))
                {
                    Console.WriteLine("Введите название товара еще раз!");
                }
                else break;
            }

            if (Name.ToLower() == "выход")
                return false; // Возвращаем false для выхода

            Id = nextId++;

            Console.WriteLine("Введите цену товара: ");
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double priceInput) && priceInput > 0)
                {
                    Price = priceInput;
                    break;
                }
                else
                {
                    Console.WriteLine("Неправильно введена цена! Попробуйте снова!");
                }
            }

            Console.WriteLine("Введите количество товара: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int countInput) && countInput > 0)
                {
                    CountProd = countInput;
                    break;
                }
                else
                {
                    Console.WriteLine("Неправильно введено количество! Попробуйте снова!");
                }
            }

            IsProd = CountProd > 0;

            Console.WriteLine("Введите категорию товара от 1 до 3: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int categInput) &&
                    categInput >= 1 && categInput <= 3)
                {
                    ProdCateg = categInput;
                    break;
                }
                else
                {
                    Console.WriteLine("Неправильно введена категория! Попробуйте снова!");
                }
            }

            return true; // Возвращаем true - товар добавлен
        }

        public void PrintProduct()
        {
            Categories selectedCategory = (Categories)ProdCateg;
            string categoryName = selectedCategory switch
            {
                Categories.food => "еда",
                Categories.groceries => "бакалея",
                Categories.careProducts => "товары для ухода",
                _ => "неизвестно"
            };

            Console.WriteLine($"{Id}, {Name}, {CountProd}, {IsProd}, Категория: {categoryName}");
        }
    }

    // Статический список товаров
    static List<Product> products = new List<Product>();

    static void AddProduct()
    {
        Product newProduct = new Product();
        bool productAdded = newProduct.GetProduct();

        if (productAdded)
        {
            products.Add(newProduct);
            Console.WriteLine("Товар успешно добавлен!");
        }
        else
        {
            Console.WriteLine("Добавление товаров завершено.");
        }
    }

    static void RemoveProduct()
    {
        Console.Write("Введите ID товара для удаления: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Product productToRemove = products.Find(p => p.Id == id);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                Console.WriteLine("Товар успешно удален!");
            }
            else
            {
                Console.WriteLine("Товар с таким ID не найден!");
            }
        }
        else
        {
            Console.WriteLine("Неверный формат ID!");
        }
    }

    static void ShowAllProducts()
    {
        Console.WriteLine("\n=== ВСЕ ТОВАРЫ ===");
        if (products.Count == 0)
        {
            Console.WriteLine("Товаров нет!");
            return;
        }

        foreach (var product in products)
        {
            product.PrintProduct();
        }
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n=== МЕНЮ ===");
            Console.WriteLine("1. Добавить товар");
            Console.WriteLine("2. Удалить товар");
            Console.WriteLine("3. Заказать поставку товара");
            Console.WriteLine("4. Продать товар");
            Console.WriteLine("5. Поиск товаров");
            Console.WriteLine("6. Показать все товары");
            Console.WriteLine("7. Выход");
            Console.Write("Выберите действие: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        AddProduct();
                        break;
                    case 2:
                        RemoveProduct();
                        break;
                    case 3:
                        Console.WriteLine("Функция поставки товара пока не реализована");
                        break;
                    case 4:
                        Console.WriteLine("Функция продажи товара пока не реализована");
                        break;
                    case 5:
                        Console.WriteLine("Функция поиска товаров пока не реализована");
                        break;
                    case 6:
                        ShowAllProducts();
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Неверный формат ввода!");
            }
        }
    }
}