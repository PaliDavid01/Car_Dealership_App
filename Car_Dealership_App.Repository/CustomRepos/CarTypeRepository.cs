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
    public class CarTypeRepository : Repository<CarType>
    {
        public CarTypeRepository(CarDbContext context) : base(context)
        {
        }

        public override CarType Read(int id)
        {
            return ctx.CarTypes.First(t => t.CTID == id);
        }

        public override void Update(CarType entity)
        {
            var old = Read(entity.CTID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(entity));
            }
            ctx.SaveChanges();
        }
    }
}
