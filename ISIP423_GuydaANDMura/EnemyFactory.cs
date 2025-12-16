using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ISIP423_GuydaANDMura
{
    internal class EnemyFactory
    {
        private Random random = new Random();

        public Enemy CreateRandomEnemy()
        {
            int enemyType = random.Next(4); // Теперь 4 типа из-за добавления слизня
            return enemyType switch
            {
                0 => new Goblin(),
                1 => new Skeleton(),
                2 => new Mage(),
                3 => new Slime(), // Новый монстр
                _ => new Goblin()
            };
        }

        public Enemy CreateRandomBoss()
        {
            int bossType = random.Next(4);
            return bossType switch
            {
                0 => new VVG(),
                1 => new Kovalski(),
                2 => new ArchmageCPP(),
                3 => new Pestov(),
                _ => new VVG()
            };
        }
    }
}
