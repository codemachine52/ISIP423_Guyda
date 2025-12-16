using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP423_GuydaANDMura.Model
{
    internal class Enemy
    {
        public string Name { get; set; } = "";
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        public Enemy(string name, int attack, int hp, int defense)
        {
            Name = name;
            HP = hp;
            Attack = attack;
            Defense = defense;
        }

        public virtual void AttackPlayer(Player player)
        {
            int damage = Attack;
            player.TakeDamage(damage);
            Console.WriteLine($"{Name} атакует и наносит {damage} урона!");
        }

        public virtual void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP < 0) HP = 0;
            Console.WriteLine($"{Name} получает {damage} урона! Осталось HP: {HP}");
        }

        public bool IsAlive()
        {
            return HP > 0;
        }

        public void ShowStats()
        {
            Console.WriteLine($"=== {Name} ===");
            Console.WriteLine($"Здоровье: {HP}");
            Console.WriteLine($"Атака: {Attack}");
            Console.WriteLine($"Защита: {Defense}");
        }
    }
}
