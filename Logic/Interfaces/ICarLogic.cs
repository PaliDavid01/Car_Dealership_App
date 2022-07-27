using Car_Dealership_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ICarLogic
    {
        void Create(Car entity);
        void Delete(int id);
        void Update(Car entity);
        Car Read(int id);
        IEnumerable<Car> ReadAll();

        int AllCount();




        
    }
}
