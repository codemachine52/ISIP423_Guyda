using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ISIP423_GuydaANDMura.Model
{
    internal class Game
    {
        private Random random = new Random();
        private int turnCount = 0;
        private EnemyFactory enemyFactory = new EnemyFactory();

        public void StartGame()
        {
            Player player = new Player(100);
            Console.WriteLine("=== ТЕКСТОВЫЙ РОГАЛИК ===");

            while (player.HP > 0)
            {
                turnCount++;
                Console.WriteLine($"\n--- Ход {turnCount} ---");
                player.ShowStats();

                // Каждые 10 ходов - босс
                if (turnCount % 10 == 0)
                {
                    Enemy boss = enemyFactory.CreateRandomBoss();
                    StartBattle(player, boss);
                }
                else
                {
                    // 50/50 шанс сундука или врага
                    if (random.Next(2) == 0) // 0 - враг, 1 - сундук
                    {
                        Enemy enemy = enemyFactory.CreateRandomEnemy();
                        StartBattle(player, enemy);
                    }
                    else
                    {
                        Chest chest = new Chest();
                        chest.Open(player);
                    }
                }

                if (player.HP <= 0)
                {
                    Console.WriteLine("\n=== ИГРА ОКОНЧЕНА ===");
                    Console.WriteLine($"Вы продержались {turnCount} ходов!");
                    break;
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        public void StartBattle(Player player, Enemy enemy)
        {
            Console.WriteLine($"\n=== ВСТРЕЧА С {enemy.Name.ToUpper()} ===");
            enemy.ShowStats();

            bool playerFrozen = false;

            while (player.HP > 0 && enemy.IsAlive())
            {
                if (!playerFrozen)
                {
                    PlayerTurn(player, enemy);
                    if (!enemy.IsAlive()) break;
                }
                else
                {
                    Console.WriteLine("Вы заморожены и пропускаете ход!");
                    playerFrozen = false;
                }

                EnemyTurn(player, enemy);
                if (player.HP <= 0) break;

                // Проверяем заморозку
                if (enemy is Mage mage && mage.FreezeApplied)
                {
                    playerFrozen = true;
                    mage.ResetFreeze();
                }
                else if (enemy is ArchemagCPP archmage && archmage.FreezeApplied)
                {
                    playerFrozen = true;
                    archmage.ResetFreeze();
                }
                else if (enemy is Pestov pestov && pestov.FreezeApplied)
                {
                    playerFrozen = true;
                    pestov.ResetFreeze();
                }
            }

            if (player.HP > 0)
            {
                Console.WriteLine($"\nПобеда! {enemy.Name} повержен!");
            }
        }

        private void PlayerTurn(Player player, Enemy enemy)
        {
            Console.WriteLine("\n--- Ваш ход ---");
            Console.WriteLine("1 - Атаковать");
            Console.WriteLine("2 - Защищаться");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    int damage = player.Attack();
                    Console.WriteLine($"Вы атакуете и наносите {damage} урона!");
                    enemy.TakeDamage(damage);
                    break;
                case "2":
                    player.Defend();
                    break;
                default:
                    Console.WriteLine("Неверный выбор, пропускаете ход!");
                    break;
            }
        }

        private void EnemyTurn(Player player, Enemy enemy)
        {
            Console.WriteLine("\n--- Ход врага ---");
            enemy.AttackPlayer(player);
            Console.WriteLine($"Ваше здоровье: {player.HP}");
        }
    }
}

