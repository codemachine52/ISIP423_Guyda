using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP423_GuydaANDMura.Model
{
    internal class Chest
    {
        private Random random = new Random();

        public void Open(Player player)
        {
            Console.WriteLine("\n=== ВЫ НАШЛИ СУНДУК! ===");

            int chestType = random.Next(1, 4); // 1-3

            switch (chestType)
            {
                case 1:
                    GiveHealingPotion(player);
                    break;
                case 2:
                    GiveWeapon(player);
                    break;
                case 3:
                    GiveArmor(player);
                    break;
            }
        }

        private void GiveHealingPotion(Player player)
        {
            Console.WriteLine("Вы нашли лечебное зелье!");
            int healAmount = player.HP; // Полное лечение
            player.Heal(healAmount);
            Console.WriteLine($"Ваше здоровье полностью восстановлено! HP: {player.HP}");
        }

        private void GiveWeapon(Player player)
        {
            string[] weaponNames = { "Стальной меч", "Острый топор", "Магический посох", "Лук охотника" };
            int[] weaponDamages = { 12, 15, 18, 10 };

            int index = random.Next(weaponNames.Length);
            Weapon newWeapon = new Weapon(weaponNames[index], weaponDamages[index]);

            Console.WriteLine($"Вы нашли новое оружие: {newWeapon}");
            Console.WriteLine($"Ваше текущее оружие: {player.CurrentWeapon}");

            Console.Write("Хотите взять новое оружие? (1 - да, 2 - нет): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                player.NewWeapon(newWeapon);
                Console.WriteLine("Вы экипировали новое оружие!");
            }
            else
            {
                Console.WriteLine("Вы оставили оружие в сундуке.");
            }
        }

        private void GiveArmor(Player player)
        {
            string[] armorNames = { "Кожаный доспех", "Кольчуга", "Латные доспехи", "Магическая мантия" };
            int[] armorDefenses = { 5, 8, 12, 6 };

            int index = random.Next(armorNames.Length);
            Armor newArmor = new Armor(armorNames[index], armorDefenses[index]);

            Console.WriteLine($"Вы нашли новые доспехи: {newArmor}");
            Console.WriteLine($"Ваши текущие доспехи: {player.CurrentArmor}");

            Console.Write("Хотите взять новые доспехи? (1 - да, 2 - нет): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                player.NewArmor(newArmor);
                Console.WriteLine("Вы экипировали новые доспехи!");
            }
            else
            {
                Console.WriteLine("Вы оставили доспехи в сундуке.");
            }
        }
    }
}
