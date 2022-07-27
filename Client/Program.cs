using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car_Dealership_App.Repository.DbContextFolder;
using ConsoleTools;
using Logic.Logics;
using Car_Dealership_App.Repository.CustomRepos;

namespace Client
{
    internal class Program
    {
        static DealerLogic dealerlogic;
        static CarTypeLogic carTypeLogic;
        static CarLogic carLogic;
        static void Create(string entity)
        {
            Console.WriteLine(entity + " create");
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "Cars")
            {
                var items = dealerlogic.ReadAll();
                foreach (var item in items)
                {
                    Console.WriteLine(item.DealershipName + "\t" + item.City);
                    foreach (var car in item.Cars)
                    {
                        Console.WriteLine("\t" + car.CarType.Brand + "\t" + car.CarType.Type + "\t" + car.Price + " EUR");
                    }
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            Console.WriteLine(entity + " update");
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            CarDbContext ctx = new CarDbContext();
            var carsRepo = new CarRepository(ctx);
            var carTypeRepo = new CarTypeRepository(ctx);
            var carDealerRepo = new CarDealerRepository(ctx);

            carLogic = new CarLogic(carsRepo);
            carTypeLogic = new CarTypeLogic(carTypeRepo);
            dealerlogic = new DealerLogic(carDealerRepo);

            var cardealerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Info", () => List("Info"))
                .Add("Add", () => Create("Dealer"))
                .Add("Delete", () => Delete("Actor"))
                .Add("Update", () => Update("Actor"))
                .Add("Cars", () => List("Cars"))
                .Add("Exit", ConsoleMenu.Close);

            var carTypeSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Actor"))
                .Add("Create", () => Create("Actor"))
                .Add("Delete", () => Delete("Actor"))
                .Add("Update", () => Update("Actor"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("CarDealers", () => cardealerSubMenu.Show())
                .Add("CarTypes", () => carTypeSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
            //var car = ctx.Cars.First();
            //Console.WriteLine(car.Color);
            //var q = from x in ctx.CarDealers join y in ctx.Cars on x.DealerID equals y.DealerID select new {  };
            //foreach (var item in ctx.CarDealers)
            //{
            //    Console.WriteLine(item.DealershipName);
            //    foreach (var item2 in item.Cars)
            //    {
            //        Console.WriteLine("\t"+item2.Color+" "+item2.Price+" "+ item2.CarType.Brand + " " + item2.CarType.Type );
            //    }
            //}
            //Console.WriteLine("Hello GitHub!");

        }
    }
}