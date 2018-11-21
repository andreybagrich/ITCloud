using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    public static class FuelController
    {
        public static  void Warning(ClassCar car1)
        {
            if (car1.Level < (car1.FuelTank / 100 * 15))
            {
                Console.WriteLine($"Fuel level is at {(car1.FuelTank / 100 * car1.Level).ToString("N2")}%. Please refill");
            }    
        }
    }
}
