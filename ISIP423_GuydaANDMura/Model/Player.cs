using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP423_GuydaANDMura.Model
{
    internal class Player
    {
        public int HP { get; set; }
        public Weapon CurrentWeapon { get; set; }
        public Armor CurrentArmor { get; set; }
        public bool IsDefending { get; private set; }

        public Player(int StartHP)
        {
            HP = StartHP;
            CurrentWeapon = new Weapon("Кулаки", 5);
            CurrentArmor = new Armor("Легкая рубашка", 3);
            IsDefending = false;
        }

        public void TakeDamage(int damage, bool ignoreDefense = false)
        {
            int finalDamage = damage;

            if (!ignoreDefense)
            {
                // Если игрок защищается, проверяем уклонение
                if (IsDefending)
                {
                    Random rand = new Random();
                    if (rand.NextDouble() < 0.4) // 40% шанс уклониться
                    {
                        Console.WriteLine("Вы увернулись от атаки!");
                        IsDefending = false;
                        return; // Выходим из метода - урон не проходит
                    }
                    else
                    {
                        // Блокирование урона (70-100% от защиты)
                        double blockPercent = 0.7 + rand.NextDouble() * 0.3;
                        int blockedDamage = (int)(CurrentArmor.Defense * blockPercent);
                        finalDamage -= blockedDamage;
                        Console.WriteLine($"Вы блокируете {blockedDamage} урона!");
                    }
                }
                else
                {
                    // Обычная защита - вычитаем защиту доспехов
                    finalDamage -= CurrentArmor.Defense;
                }

                // Проверяем чтобы урон не стал отрицательным
                if (finalDamage < 0) finalDamage = 0;
            }

            // Применяем урон
            HP -= finalDamage;
            if (HP < 0) HP = 0;

            Console.WriteLine($"Получено урона: {finalDamage}");
            IsDefending = false;
        }

        public int Attack()
        {
            return CurrentWeapon.Damage;
        }

        public void Defend()
        {
            IsDefending = true;
            Console.WriteLine("Вы готовитесь к защите на следующую атаку!");
        }

        public void Heal(int amonth)
        {
            HP += amonth;
        }

        public void NewWeapon(Weapon newWeapon)
        {
            CurrentWeapon = newWeapon;
        }

        public void NewArmor(Armor newArmor)
        {
            CurrentArmor = newArmor;
        }

        public void ShowStats()
        {
            Console.WriteLine("======          СТАТИСТИКА ИГРОКА          ======");
            Console.WriteLine($"Здоровье: {HP}");
            Console.WriteLine($"Оружие: {CurrentWeapon}");
            Console.WriteLine($"Броня: {CurrentArmor}");
            Console.WriteLine("==============================\n");
        }
    }
}
