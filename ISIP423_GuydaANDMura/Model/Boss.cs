using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP423_GuydaANDMura.Model
{
    internal class Boss : Enemy
    {
        public Boss(string name, int attack, int hp, int defense) : base(name, attack, hp, defense)
        {
        }
    }
}
