using Car_Dealership_App.Models;
using Car_Dealership_App.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;

namespace Logic.Logics
{
    public class DealerLogic: CarDealerLogic
    {
        IRepository<CarDealer> repo;
        public DealerLogic(IRepository<CarDealer> repo)
        {
            this.repo = repo;
        }

        public int Count()
        {
            return repo.ReadAll().Count();
        }

        public void Create(CarDealer entity)
        {
            repo.Create(entity);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public CarDealer Read(int id)
        {
            var dealer = repo.Read(id);
            if (dealer == null)
            {
                throw new ArgumentException("Dealer not exists");
            }
            return dealer;
        }

        public IEnumerable<CarDealer> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public int SumPrice()
        {
            int sum = 0;
            foreach (var item in repo.ReadAll())
            {
                foreach(var car in item.Cars)
                {
                    sum += car.Price;
                }
            }
            return sum;
        }

        public void Update(CarDealer entity)
        {
            this.repo.Update(entity);
        }
    }
}
