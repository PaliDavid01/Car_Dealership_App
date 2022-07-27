
using Car_Dealership_App.Models;

namespace Logic.Interfaces
{
    public interface ICarDealerLogic
    {
        void Create(CarDealer entity);
        void Delete(int id);
        void Update(CarDealer entity);
        CarDealer Read(int id);
        IEnumerable<CarDealer> ReadAll();

        int Count();

        int SumPrice();

    }
}