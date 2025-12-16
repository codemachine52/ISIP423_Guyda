using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP423_GuydaANDMura.Model
{
    internal class Pestov : Boss
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
            player.TakeDamage(Attack, true);
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
