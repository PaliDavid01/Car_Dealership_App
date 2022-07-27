using Car_Dealership_App.Models;
using Car_Dealership_App.Repository.BaseRepository;
using Car_Dealership_App.Repository.DbContextFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Dealership_App.Repository.CustomRepos
{
    public class CarDealerRepository : Repository<CarDealer>
    {
        public CarDealerRepository(CarDbContext context) : base(context)
        {
        }

        public override CarDealer Read(int id)
        {
            return this.ctx.CarDealers.First(t => t.DealerID == id);
        }

        public override void Update(CarDealer entity)
        {
            var old = Read(entity.DealerID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(entity));
            }
            ctx.SaveChanges();
        }


    }
}
