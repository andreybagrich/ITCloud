using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateControl
{
    class Program
    {
        static void Main(string[] args)
        {
            Apartment apartment = new Apartment();
            AC ac = new AC();
            Heater heater = new Heater();

            apartment.climateControlEvent += ac.SwitchOn;
            apartment.climateControlEvent += ac.SwitchOff;
            apartment.climateControlEvent += heater.SwitchOn;
            apartment.climateControlEvent += heater.SwitchOff;

            apartment.AirTemperature = 5;

            Console.ReadLine();

        }
    }
}
