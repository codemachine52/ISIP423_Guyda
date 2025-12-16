using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISIP423_GuydaANDMura.Model
{
    internal class Kovalski : Boss
    {
        public Kovalski() : base("Ковальски", (int)(1.3 * 10), (int)(2.5 * 25), (int)(1.4 * 2)) { }

        public override void AttackPlayer(Player player)
        {
            // Игнорирует защиту как скелет
            player.TakeDamage(Attack, true);
            Console.WriteLine($"{Name} игнорирует защиту и наносит {Attack} урона!");
        }
    }
}
