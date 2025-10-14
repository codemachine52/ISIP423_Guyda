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
                if (HP < 0) HP = 0;
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
            int Damage { get; set; }

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
            protected string Name { get; set; } = "";
            protected int HP { get; set; }
            protected int Attack { get; set; }
            protected int Defense { get; set; }

            public Enemy(string name, int attack, int hp, int defense)
            {
                Name = name;
                HP = hp;
                Attack = attack;
                Defense = defense;
            }

            public virtual void AttackPlayer(Player player)
            {
                int damage = Attack;
                player.TakeDamage(damage);
                Console.WriteLine($"{Name} атакует и наносит {damage} урона!");
            }

            public bool IsAlive()
            {
                return HP > 0;
            }
            public void ShowStats()
            {
                Console.WriteLine($"=== {Name} ===");
                Console.WriteLine($"Здоровье: {HP}");
                Console.WriteLine($"Атака: {Attack}");
                Console.WriteLine($"Защита: {Defense}");
            }
        }

        class Goblin : Enemy
        {
            double critChance = 0.2;
            double critMnojitel = 2;

            public Goblin() : base("Гоблин", 8, 30, 3) { }

            public virtual void AttackPlayer(Player player)
            {
                Random random = new Random();
                double damage = Attack;

                if (random.NextDouble() < critChance)
                {
                    damage *= critMnojitel;
                    Console.WriteLine("Критический удар!");
                }

                player.TakeDamage((int)damage);
                Console.WriteLine($"{Name} атакует и наносит {damage} урона!");
            }
        }

        class Skeleton : Enemy
        {
            public Skeleton() : base("Скелет", 10, 25, 2) { }

            public override void AttackPlayer(Player player)
            {
                Random random = new Random();
                double damage = Attack;

                // Скелет игнорирует защиту игрока
                player.TakeDamage((int)damage);
                Console.WriteLine($"{Name} игнорирует защиту и наносит {damage} урона!");
            }
        }

        class Mage : Enemy
        {
            double freezeChance = 0.25;
            public bool FreezeApplied { get; private set; }

            public Mage() : base("Маг", 12, 20, 1)
            {
                FreezeApplied = false;
            }

            public override void AttackPlayer(Player player)
            {
                Random random = new Random();
                double damage = Attack;

                player.TakeDamage((int)damage);
                Console.WriteLine($"{Name} атакует и наносит {damage} урона!");

                if (random.NextDouble() < freezeChance)
                {
                    FreezeApplied = true;
                    Console.WriteLine($"{Name} накладывает заморозку! Вы пропустите следующий ход!");
                }
            }

            public void ResetFreeze()
            {
                FreezeApplied = false;
            }
        }

        class Boss : Enemy
        {
            public Boss(string name, int attack, int hp, int defense) : base(name, attack, hp, defense)
            {
            }
        }

        class VVG : Boss
        {

        }
    }
}