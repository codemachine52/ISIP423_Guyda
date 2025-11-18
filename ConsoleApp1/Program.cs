using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool ShowMenu = true;
            while (ShowMenu)
            {
                Console.WriteLine("=========== Онлайн Магазин WOG ===========");
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Регистрация");
                Console.WriteLine("2. Вход в аккаунт");
                Console.WriteLine("0. Выход из магазина");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            CreateUser();
                            break;
                        case 2:
                            SignIn();
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
                        Console.WriteLine("Пароли не совпадают! Попробуйте снова!");
                    }
                }
            }
            user.Money = 0;
            if (user != null)
            {
                Console.WriteLine("Пользователь успешно создан!\n");
                Core.Context.User.Add(user);
                Core.Context.SaveChanges();
            }
            
        }
        // 4. Если все прошло успешно добавить пользователя и войти в аккаунт\вернутся в меню

        static public void SignIn()
        {
            User user = null;
            bool SignInAccount = true;
            while (SignInAccount)
            {
                Console.WriteLine("Введите логин: ");
                string login = Console.ReadLine();
                Console.WriteLine("Введите пароль: ");
                string password = Console.ReadLine();
                var LoginUser = Core.Context.User.Where(log => Core.Context.User.Contains(log)).FirstOrDefault();
                var LoginPassword = Core.Context.User.Where(pas => Core.Context.User.Contains(pas)).FirstOrDefault();
                if(LoginUser != null && LoginPassword != null)
                {
                    user = Core.Context.User.Where(us => us.Nickname == LoginUser.Nickname).FirstOrDefault();
                    Console.WriteLine("Успешный вход в аккаунт!\n");
                    SignInAccount = false;
                }
                else
                {
                    Console.WriteLine("Не удалось войти в аккаунт!");
                    if(LoginUser == null)
                    {
                        Console.WriteLine("Не найден пользователь с таким логином!");
                    }
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


    // Каталог товаров()
    // {
    // вывести список товаров из БД с указанием названия, цены.
    // после отображения списка всех товаров сделать отступ и дать возможность ввести пользователю ID товара для просмотра подробной инф. о товаре
    // при вводе ID товара показывается все данные о нем (карточка товара), при этом проверяется поле товара IsOver18, если истина, то у пользователя спрашивается его возраст и сохраняется в БД
    // если возраст меньше 18, то товар не покажется и пользователя снова вернет в каталог товаров. Иначе карточка товара откроется.
    // }


    // Добавление товара в корзину()
    // {
    // при просмотре товара после выбора его по ID пользователь имеет возможность добавить товар в корзину, при этом указав количество товара. 
    // после ввода кол-ва товара идет проверка, не пустая ли корзина пользователя. Если не пустая, в нее просто добавляется товар, иначе создается новая корзина и в нее добавляется товар.
    // }


    // Заказ товара напрямую из меню товаров()
    // {
    // пользователю необходимо в меню товаров выбрать конкретный товар, указав ID, чтобы перейти к карточке товара (не забываем про проверку возраста и поле IsOver18).
    // выбрать кнопку "заказать товар". После этого проверка корзины пользователя, если она пустая, то создать новую и сразу перебросить пользователя на страницу оплаты заказа и выбора ПВЗ 
    // или другого типа заказа (доставка на дом например)
    // иначе если НЕ пустая корзина, также создать новую и перебросить пользователя на ту же страницу, при этом после оплаты заказа вернуть пользователю его прошлую корзину (ID последней корзины - 1)
    // }


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


