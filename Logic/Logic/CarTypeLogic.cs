using Car_Dealership_App.Models;
using Car_Dealership_App.Repository.Interfaces;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class CarTypeLogic : ICarTypeLogic
    {
        IRepository<CarType> repo;

        public CarTypeLogic(IRepository<CarType> repo)
        {
            this.repo = repo;
        }

        public int Count()
        {
            return this.repo.ReadAll().Count();            
        }

        public void Create(CarType entity)
        {
            this.repo.Create(entity);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public CarType Read(int id)
        {
            var carType = this.repo.Read(id);
            if(carType == null)
            {
                throw new ArgumentException("CarType not exists");
            }
            return carType;
        }

        public IEnumerable<CarType> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(CarType entity)
        {
            this.repo.Update(entity);
        }
    }
}
