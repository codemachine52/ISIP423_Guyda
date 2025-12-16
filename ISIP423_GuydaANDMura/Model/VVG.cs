using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISIP423_GuydaANDMura.Model
{
    internal class VVG : Boss
    {
        double critchance = 0.3;
        double critmnojitel = 2;
        public VVG() : base("ВВГ", (int)(1.5 * 8), (int)(2 * 30), (int)(1.2 * 3))
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
}
