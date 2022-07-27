using Car_Dealership_App.Models;
using Car_Dealership_App.Repository.Interfaces;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logics
{
    public class CarLogic : ICarLogic
    {
        IRepository<Car> repo;
        public CarLogic(IRepository<Car> repo)
        {
            this.repo = repo;
        }

        public int AllCount()
        {
            return this.repo.ReadAll().Count();
        }

        public void Create(Car entity)
        {
            this.repo.Create(entity);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Car Read(int id)
        {
            var car = this.repo.Read(id);
            if (car == null)
            {
                throw new ArgumentException("Car not exists");
            }
            return car;
        }

        public IEnumerable<Car> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Car entity)
        {
            this.repo.Update(entity);
        }
    }
}
