using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISIP423_GuydaANDMura
{
    class Slime : Enemy
    {
        public Slime() : base("Слизень", 7, 35, 0) { }

        public override void TakeDamage(int damage)
        {
            // Уменьшаем входящий урон на 2 единицы
            int reducedDamage = damage - 2;
            if (reducedDamage < 1) reducedDamage = 1; // Минимум 1 урона

            HP -= reducedDamage;
            if (HP < 0) HP = 0;

            Console.WriteLine($"{Name} поглощает часть урона! Получает {reducedDamage} урона вместо {damage}! Осталось HP: {HP}");
        }
    }
}
