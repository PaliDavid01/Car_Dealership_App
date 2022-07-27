using Car_Dealership_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ICarTypeLogic
    {
        void Create(CarType entity);
        void Delete(int id);
        void Update(CarType entity);
        CarType Read(int id);
        IEnumerable<CarType> ReadAll();

        int Count();

    }
}
