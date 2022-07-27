using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car_Dealership_App.Repository;
namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarDbContext ctx = new CarDbContext();
            var car = ctx.Cars.First();
            Console.WriteLine(car.Color);
            var q = from x in ctx.CarDealers join y in ctx.Cars on x.DealerID equals y.DealerID select new { x, y };
            foreach (var item in ctx.CarDealers)
            {
                Console.WriteLine(item.DealershipName);
                foreach (var item2 in item.Cars)
                {
                    Console.WriteLine("\t"+item2.Color+" "+item2.Price );
                }
            }
        }
    }
}