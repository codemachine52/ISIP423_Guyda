using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintMenu();
        }

        static public void PrintMenu()
        {
            bool ShowMenu = true;
            while (ShowMenu)
            {
                Console.WriteLine("=========== Онлайн Магазин WOG ===========");
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Регистрация");
                Console.WriteLine("2. Вход в аккаунт");
                Console.WriteLine("3. Каталог товаров");
                Console.WriteLine("4. Корзина товаров");
                Console.WriteLine("0. Выход из магазина");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            CreateUser();
                            break;
                        case 2:
                            Console.Clear();
                            SignIn();
                            break;
                        case 3:
                            Console.Clear();
                            Catalogue();
                            break;
                        case 4:
                            Console.Clear();
                            ShowBasket();
                            break;
                        case 0:
                            ShowMenu = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Введите число-указатель пункта меню.");
                }
            }
        }


        static public void CreateUser()
        {
            User user = new User();
            bool AddNickname = true;

            while (AddNickname)
            {
                Console.WriteLine("Введите никнейм:");
                string nickname = Console.ReadLine();
                if (!String.IsNullOrEmpty(nickname))
                {
                    var IsUserAlreadyExist = Core.Context.User.FirstOrDefault(x => x.Nickname == nickname);
                    if (IsUserAlreadyExist == null)
                    {
                        user.Nickname = nickname;
                        AddNickname = false;
                    }
                    else
                    {
                        Console.WriteLine("Пользователь с таким никнеймом уже существует");
                    }
                }
                else
                {
                    Console.WriteLine("Никнейм не может быть пустым!");
                }
            }
            bool AddingPassword = true;

            while (AddingPassword)
            {
                string password;
                while (true)
                {
                    Console.WriteLine("Введите пароль:");
                    password = Console.ReadLine();
                    if (String.IsNullOrEmpty(password) && password.Length < 6)
                    {
                        Console.WriteLine("Пароль не может быть пустым и его длина должна быть больше 6 символов!");
                    }
                    else break;
                }

                while (true)
                {
                    Console.WriteLine("Повторите введенный пароль: ");
                    string passwordAgain = Console.ReadLine();
                    if (!String.IsNullOrEmpty(password) && password.Length >= 6 && passwordAgain == password)
                    {
                        user.Password = password;
                        AddingPassword = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Пароли не совпадают! Попробуйте снова!\n");
                    }
                }
            }
            user.Money = 0;
            if (user != null)
            {
                Console.WriteLine("Пользователь успешно создан!\n");
                Core.Context.User.Add(user);
                Core.Context.SaveChanges();
                Console.Clear();
            }

        }
        // 4. Если все прошло успешно добавить пользователя и войти в аккаунт\вернутся в меню

        public static User user = null;
        static public void SignIn()
        {
            
            bool SignInAccount = true;
            while (SignInAccount)
            {
                Console.WriteLine("Введите логин: ");
                string login = Console.ReadLine();
                Console.WriteLine("Введите пароль: ");
                string password = Console.ReadLine();
                var LoginUser = Core.Context.User.Where(log => log.Nickname == login).FirstOrDefault();
                if (LoginUser != null)
                {
                    Console.Clear();
                    if(LoginUser.Nickname == login && password == LoginUser.Password)
                    {
                        Console.WriteLine("Успешный вход в аккаунт!");
                        user = LoginUser;
                        SignInAccount = false;
                    }
                    if(password != LoginUser.Password)
                    {
                        Console.WriteLine("Неверный пароль!");
                    }
                }
                else
                {
                    Console.WriteLine("Не удалось войти в аккаунт!");
                    if (LoginUser == null)
                    {
                        Console.WriteLine("Не найден пользователь с таким логином!");
                    }
                }
            }
        }
        // Вход()
        // {
        // 1. попросить ввести пользователя логин и пароль
        // 2. обратиться к БД и найти пользователя, если успешно, то проверить введенный пароль, иначе вывести "Пользователь не найден."
        // 3. если пароль верный, войти в аккаунт, иначе вывести "Введен неверный пароль".
        // }

        static public void Catalogue()
        {
            List<Product> products = Core.Context.Product.ToList();
            bool ShowCatalogue = true;
            while (ShowCatalogue)
            {
                if (Core.Context.Product.Any())
                {
                    Console.WriteLine("====== КАТАЛОГ ТОВАРОВ ======");
                    foreach (var prod in products)
                    {
                        Console.WriteLine($"ID: {prod.ID}, название: {prod.Name}, цена: {prod.Price}");
                    }
                    Console.WriteLine();

                    Console.WriteLine("Хотите выбрать конкретный товар? (Да/нет)");
                    string choice = Console.ReadLine().ToLower();
                    bool ChoiceProd = true;
                    while (ChoiceProd)
                    {
                        switch (choice.ToLower())
                        {
                            case "да":
                                Console.WriteLine("Введите ID товара: ");
                                if (int.TryParse(Console.ReadLine(), out int id))
                                {
                                    var IdProd = Core.Context.Product.FirstOrDefault(prod => prod.ID == id);
                                    if (IdProd != null)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"ID: {IdProd.ID}, название: {IdProd.Name}, цена: {IdProd.Price}, вес (объем): {IdProd.Size}, для совершеннолетних: {IdProd.IsOver18}");
                                        Console.WriteLine("Желаете продолжить? (Да/нет)");
                                        string answer = Console.ReadLine();
                                        switch (answer.ToLower())
                                        {
                                            case "да":
                                                Console.Clear();
                                                Console.WriteLine("Выберите пункт меню:\n" +
                                            "1. Добавить товар в корзину\n" +
                                            "2. Посмотреть каталог");
                                                string vibor = Console.ReadLine();
                                                if (vibor == "2")
                                                {
                                                    Catalogue();
                                                    ChoiceProd = false;
                                                }
                                                if(vibor == "1")
                                                {
                                                    if(user != null)
                                                    {
                                                        AddProductInBasket(user.ID, IdProd.ID);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Необходимо войти в аккаунт!");
                                                        SignIn();
                                                    }
                                                }
                                                break;
                                            case "нет":
                                                Console.Clear();
                                                ShowCatalogue = false;
                                                ChoiceProd = false;
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Товар с таким ID не найден");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Введите корректный ID!");
                                }
                                break;
                            case "нет":
                                Console.Clear();
                                ChoiceProd = false;
                                ShowCatalogue = false;
                                PrintMenu();
                                break;
                        }
                        break;
                    }
                }
                else
                {
                    AddProducts();
                }
                
            }
        }

        //функция для заполнения БД товарами
        static private void AddProducts()
        {
            Core.Context.Product.Add(new Product { Name = "Колбаса", Price = 540, Size = "50x56", IsOver18 = false });
            Core.Context.Product.Add(new Product { Name = "Хлеб", Price = 45, Size = "30x15", IsOver18 = false });
            Core.Context.Product.Add(new Product { Name = "Молоко", Price = 85, Size = "1л", IsOver18 = false });
            Core.Context.Product.Add(new Product { Name = "Пиво", Price = 120, Size = "0.5л", IsOver18 = true });
            Core.Context.Product.Add(new Product { Name = "Сигареты", Price = 180, Size = "20шт", IsOver18 = true });
            Core.Context.Product.Add(new Product { Name = "Сыр", Price = 320, Size = "200г", IsOver18 = false });
            Core.Context.Product.Add(new Product { Name = "Водка", Price = 450, Size = "0.5л", IsOver18 = true });
            Core.Context.Product.Add(new Product { Name = "Чипсы", Price = 95, Size = "100г", IsOver18 = false });
            Core.Context.Product.Add(new Product { Name = "Шоколад", Price = 65, Size = "90г", IsOver18 = false });
            Core.Context.Product.Add(new Product { Name = "Вино", Price = 750, Size = "0.75л", IsOver18 = true });

            Core.Context.SaveChanges();
        }
        // Каталог товаров()
        // {
        // вывести список товаров из БД с указанием названия, цены.
        // после отображения списка всех товаров сделать отступ и дать возможность ввести пользователю ID товара для просмотра подробной инф. о товаре
        // при вводе ID товара показывается все данные о нем (карточка товара), при этом проверяется поле товара IsOver18, если истина, то у пользователя спрашивается его возраст и сохраняется в БД
        // если возраст меньше 18, то товар не покажется и пользователя снова вернет в каталог товаров. Иначе карточка товара откроется.
        // }


        static public void AddProductInBasket(int UsID, int IdProd)
        {
            Console.WriteLine("Введите количество товара, который хотите добавить в корзину");
            if (int.TryParse(Console.ReadLine(), out int countProd))
            {
                var UserBasket = Core.Context.basket.Where(basket => basket.UserID == user.ID).FirstOrDefault();
                if (UserBasket != null)
                {
                    var product = Core.Context.Product.Where(p => p.ID == IdProd).FirstOrDefault();
                    Core.Context.Basket_Products.Add(new Basket_Products { IDBasket = UserBasket.ID, IDProduct = product.ID, CountProd = countProd });
                    Core.Context.SaveChanges();

                }
                else
                {
                    //var user = Core.Context.User.Where(User => User.ID == UsID).FirstOrDefault();
                    Core.Context.basket.Add(new basket { UserID = user.ID });
                    Core.Context.SaveChanges();
                    var BaskID = Core.Context.basket.Where(usid => usid.UserID == UsID).FirstOrDefault();
                    Core.Context.Basket_Products.Add(new Basket_Products { IDBasket = BaskID.ID });
                    Core.Context.SaveChanges();
                    var product = Core.Context.Product.Where(p => p.ID == IdProd).FirstOrDefault();
                    Core.Context.Basket_Products.Add(new Basket_Products { IDBasket = UserBasket.ID, IDProduct = product.ID, CountProd = countProd });
                    Core.Context.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("Введите число!");
            }
        }
        // Добавление товара в корзину()
        // {
        // при просмотре товара после выбора его по ID пользователь имеет возможность добавить товар в корзину, при этом указав количество товара. 
        // после ввода кол-ва товара идет проверка, не пустая ли корзина пользователя. Если не пустая, в нее просто добавляется товар, иначе создается новая корзина и в нее добавляется товар.
        // }


        public static void ShowBasket()
        {
            if (user != null)
            {
                var idbasketUser = Core.Context.basket.Where(usID => usID.UserID == user.ID).FirstOrDefault();
                if (idbasketUser != null)
                {
                    var basketUser = Core.Context.Basket_Products.Where(idBasket => idBasket.IDBasket == idbasketUser.ID).ToList();
                    decimal summa = 0;
                    foreach (var product in basketUser)
                    {
                        var prods = Core.Context.Product.Where(prodID => product.IDProduct == prodID.ID).ToList(); ;
                        foreach(var prod in prods)
                        {
                            decimal price = 0;
                            Console.WriteLine($"ID: {prod.ID}, название: {prod.Name}, цена: {prod.Price}, количество: {product.CountProd}, стоимость: {price = prod.Price * product.CountProd} руб.");
                            summa += price;
                        }
                    }
                    Console.WriteLine($"Итоговая стоимость корзины: {summa}");
                }
                else
                {
                    Console.WriteLine("Корзина пустая! Добавьте товары!");
                    Catalogue();
                }
            }

            else
            {
                Console.WriteLine("Войдите в аккаунт!");
                SignIn();
            }
        }
        //просмотр корзины()


        // Заказ товара напрямую из меню товаров()
        // {
        // пользователю необходимо в меню товаров выбрать конкретный товар, указав ID, чтобы перейти к карточке товара (не забываем про проверку возраста и поле IsOver18).
        // выбрать кнопку "заказать товар". После этого проверка корзины пользователя, если она пустая, то создать новую и сразу перебросить пользователя на страницу оплаты заказа и выбора ПВЗ 
        // или другого типа заказа (доставка на дом например)
        // иначе если НЕ пустая корзина, также создать новую и перебросить пользователя на ту же страницу, при этом после оплаты заказа вернуть пользователю его прошлую корзину (ID последней корзины - 1)
        // }

        static public void OrderFromBasket()
        {
            var Products = Core.Context.Basket_Products.ToList();
            var PVZ = Core.Context.PVZ.ToList();
            Console.WriteLine("Заказ товаров");
            var idbasketUser = Core.Context.basket.Where(usID => usID.UserID == user.ID).FirstOrDefault();
            if (idbasketUser != null)
            {
                bool zakaz = true;
                while (zakaz) {
                    Console.WriteLine("Желаете заказать все товары из корзины? (да/нет)");
                    string choice = Console.ReadLine().ToLower();
                    switch (choice)
                    {
                        case "да":
                            Console.WriteLine("Введите тип доставки: (курьером/постамат/пвз)");
                            string typeDel = Console.ReadLine().ToLower();
                            if (typeDel == "пвз")
                            {
                                Console.WriteLine("Выберите id ПВЗ:");
                                foreach (var pvz in PVZ)
                                {
                                    Console.WriteLine($"id: {pvz.ID}, Адрес: {pvz.Address}");
                                }
                                if (int.TryParse(Console.ReadLine(), out int IDpvz))
                                {
                                    //
                                }
                                else
                                {
                                    Console.WriteLine("Введите ID пвз!");
                                }

                                Core.Context.Delivery.Add(new Delivery { IdPVZ = IDpvz, OrderDate = DateTime.Now, TypeDelivery = typeDel, UserID = user.ID});
                                Core.Context.SaveChanges();
                            }
                            break;
                    }
                }
            }
        }
        // Заказ товара(-ов) из корзины()
        // {
        // пользователь после добавления всех нужных товаров возвращается в главное меню, оттуда переходит в свою корзину. 
        // в корзине считается итоговая сумма товаров. Пользователь должен пополнить свой счет, если на нем не достаточно денег для заказа. При получении оплаты нет)
        // если денег достаточно, пользователь может перейти на страницу заказа (выбор пвз и оплата - списание со счета именно)
        // на странице заказа выбираем ПВЗ, подтверждаем заказ вводом слова "Да" и деньги списываются со счёта.
        // }



        // Просмотр истории покупок()
        // {
        // пользователь должен быть залогинен
        // в главном меню сделать кнопку выбора "Просмотр истории товаров"
        // при нажатии данной кнопки идет запрос к БД, ID пользователя через linq ищется в таблице истории покупок (basket_products) показывается таблица Basket_Products
        // в конце будет кнопка заменить ID на название, при нажатии вместо ID товара будет показываться полное название для пользователя.
        // 
        // }
    }
}


