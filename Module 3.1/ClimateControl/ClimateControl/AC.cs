using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateControl
{
    public class AC
    {
        public void SwitchOn(int temperature)
        {
            if (temperature > 25)
            {
                Console.WriteLine("Air conditioner switched on");
            } 
        }

        public void SwitchOff(int temperature)
        {
            if (temperature < 24)
            {
                Console.WriteLine("Air conditioner switched off");
            }
        }
    }
}
