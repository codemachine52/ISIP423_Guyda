using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISIP423_GuydaANDMura.Model
{
    internal class Goblin : Enemy
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
}
