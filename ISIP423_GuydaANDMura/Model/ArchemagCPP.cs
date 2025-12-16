using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP423_GuydaANDMura.Model
{
    internal class ArchemagCPP : Boss
    {
        double freezeChance = 0.35;
        public bool FreezeApplied { get; private set; }

        public ArchemagCPP() : base("Архимаг C++", (int)(12 * 1.6), (int)(20 * 1.8), (int)(1 * 1.1))
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
}
