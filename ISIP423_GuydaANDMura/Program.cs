using System;

class Program
{
    class Game
    {
        class Player
        {
            int HP { get; set; }
            public Weapon CurrentWeapon { get; set; }
            public Armor CurrentArmor { get; set; }

            public Player(int StartHP)
            {
                HP = StartHP;
                CurrentWeapon = new Weapon("Кулаки", 5);
                CurrentArmor = new Armor("Легкая рубашка", 3);
            }

            public void TakeDamage(int damage)
            {
                HP -= damage;
                if(HP < 0) HP = 0;
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

        class Weapon
        {
            string Name { get; set; } = "";
            int Damage {  get; set; }

            public Weapon(string name, int damage)
            {
                Name = name;
                Damage = damage;
            }
        }

        class Armor
        {
            string Name { get; set; } = "";
            int Defense { get; set; }

            public Armor(string name, int defense)
            {
                Name = name;
                Defense = defense;
            }
        }

        class Enemy
        {
            string Name { get; set; } = "";
            int HP { get; set; }
            int Attack { get; set; }
            int Defense { get; set;}

            public Enemy(string name, int attack, int hp, int defense)
            {
                Name = name;
                HP = hp;
                Attack = attack;
                Defense = defense;
            }

            public void AttackPlayer(Player player)
            {

            }
        }
    }
}