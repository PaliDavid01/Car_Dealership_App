using Car_Dealership_App.Models;
using Car_Dealership_App.Repository.BaseRepository;
using Car_Dealership_App.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Dealership_App.Repository.CustomRepos
{
    internal class CarRepository : Repository<Car>
    {
        public CarRepository(CarDbContext context) : base(context)
        {
        }

        public override Car Read(int id)
        {
            return ctx.Cars.First(ctx => ctx.Id == id);
        }

        public override void Update(Car entity)
        {
            var old = Read(entity.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(entity));
            }
            ctx.SaveChanges();
        }
    }
}
