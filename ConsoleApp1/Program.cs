using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        private static void InitializDB()
        {
            var parts = new[]
            {
                new Part { partID = 1, partName = "Двигатель", baseprice = 3000, workCost = 0.8m },
                new Part { partID = 2, partName = "Сцепление", baseprice = 1700, workCost = 0.6m },
                new Part { partID = 3, partName = "Маховик", baseprice = 600, workCost = 0.4m },
                new Part { partID = 4, partName = "Амортизатор подвески передний", baseprice = 500, workCost = 0.3m },
                new Part { partID = 5, partName = "Амортизатор подвески задний", baseprice = 500, workCost = 0.3m },
                new Part { partID = 6, partName = "Тормозной диск", baseprice = 450, workCost = 0.35m },
                new Part { partID = 7, partName = "Суппорт", baseprice = 550, workCost = 0.3m },
                new Part { partID = 8, partName = "Тормозная колодка", baseprice = 490, workCost = 0.35m }
            };
            foreach (var part in parts)
            {
                Core.Context.Parts.Add(part);
                
            }
        }
    }

    public class Player
    {
        public int Id = 1;
        decimal mymoney = 2000;
    }

    public class Part
    {
        public int partID;
        public string partName { get; set; } = "";
        public decimal baseprice;
        public decimal workCost { get; set; } = 0.3m;
    }
    public class Defect
    {
        public int Id = 0;
        public static int NextId = 1;
        public string defname { get; set; }
        public int partneedId { get; set; }

        public Defect()
        {
            Id = NextId++;
        }

    }

    public class Car
    {
        public int Id = 0;
        public static int NextId = 1;
        public string carname { get; set; }
        public int defectId { get; set; }

        public Car()
        {
            Id = NextId++;
        }
    }

    public class Inventory
    {
        public int idpart { get; set; }
        public int countParts { get; set; }
        public static int Idplayer = 1;
    }
    public class OrderParts
    {
        public int ID {  get; set; }
        public int PlayerID { get; set; }
        public int PartID { get; set; }
        public int Quantity { get; set; }
        public int CarsUntilDelivery { get; set; } = 2;
    }
}


