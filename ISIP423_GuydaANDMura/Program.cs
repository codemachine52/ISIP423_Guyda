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
            public string Name { get; set; } = "";
            public int Damage { get; set; }

            public Weapon(string name, int damage)
            {
                Name = name;
                Damage = damage;
            }
        }

        class Armor
        {
           public string Name { get; set; } = "";
           public int Defense { get; set; }

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
            protected double critChance = 0.2;
            protected double critMnojitel = 2;

            public Goblin() : base("Гоблин", 8, 30, 3) { }

            public override void AttackPlayer(Player player)
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
            double critchance = 0.3;
            double critmnojitel = 2;
            public VVG() : base("ВВГ", (int)(1.5*8), (int)(2*30), (int)(1.2 * 3))
            {
                
            }

            public override void AttackPlayer(Player player)
            {
                Random random = new Random();
                double damage = Attack;

                if (random.NextDouble() < critchance)
                {
                    damage *= critmnojitel;
                    Console.WriteLine("Критический удар!");
                }

                player.TakeDamage((int)damage);
                Console.WriteLine($"{Name} атакует и наносит {damage} урона!");
            }
        }

        class Kovalski  : Boss
        {
            public Kovalski() : base("Ковальски", (int)(1.3 * 10), (int)(2.5 * 25), (int)(1.4 * 2)) { }

            public override void AttackPlayer(Player player)
            {
                // Игнорирует защиту как скелет
                player.TakeDamage(Attack);
                Console.WriteLine($"{Name} игнорирует защиту и наносит {Attack} урона!");
            }
        }

        class ArchmageCPP : Boss
        {
            double freezeChance = 0.35;
            public bool FreezeApplied { get; private set; }

            public ArchmageCPP() : base("Архимаг C++", (int)(12 * 1.6), (int)(20 * 1.8), (int)(1 * 1.1))
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

        class Pestov : Boss
        {
            double freezeChance = 0.4;
            public bool FreezeApplied { get; private set; }

            public Pestov() : base("Пестов С--", (int)(10 * 1.8), (int)(25 * 1.3), (int)(2 * 0.6))
            {
                FreezeApplied = false;
            }

            public override void AttackPlayer(Player player)
            {
                Random random = new Random();
                double damage = Attack;

                // Игнорирует защиту как скелет + шанс заморозки
                player.TakeDamage(Attack);
                Console.WriteLine($"{Name} игнорирует защиту и наносит {Attack} урона!");

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

    }
}