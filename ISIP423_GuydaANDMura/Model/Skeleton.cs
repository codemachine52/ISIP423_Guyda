using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISIP423_GuydaANDMura.Model
{
    internal class Skeleton : Enemy
    {
        public Skeleton() : base("Скелет", 10, 25, 2) { }

        public override void AttackPlayer(Player player)
        {
            Random random = new Random();
            double damage = Attack;

            // Скелет игнорирует защиту игрока
            player.TakeDamage(Attack, true);
            Console.WriteLine($"{Name} игнорирует защиту и наносит {damage} урона!");
        }
    }
}
