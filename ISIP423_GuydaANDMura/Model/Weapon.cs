using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP423_GuydaANDMura.Model
{
    internal class Weapon
    {
        public string Name { get; set; } = "";
        public int Damage { get; set; }

        public Weapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        public override string ToString()
        {
            return $"{Name} (Урон: {Damage})";
        }
    }
}
