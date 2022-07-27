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
            ;
        }
    }
}