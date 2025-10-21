using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<cars> cars = Core.Context.cars.ToList();
            player NewPlayer = new player
            {
                id = 1,
                MyMoney = 2000
            };

        }
    }
}
