using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    class Program
    {
        public delegate void ControlFuel(ClassCar car);

        static void Main(string[] args)
        {
            ClassCar car1 = new ClassCar();
            car1.FuelTank = 80;
            car1.Level = 10;

            ControlFuel controlFuel;
            controlFuel = FuelController.Warning;
            controlFuel.Invoke(car1);

            Console.ReadLine();
        }
    }
}
    

