using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateControl
{
    public class Heater
    {
        public void SwitchOn(int temperature)
        {
            if (temperature < 14)
            {
                Console.WriteLine("Heater switched on");
            }
        }

        public void SwitchOff(int temperature)
        {
            if (temperature > 18)
            {
                Console.WriteLine("Heater switched off");
            }
        }
    }
}
