using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClimateControl
{
    public class Apartment
    {
        public delegate void ClimateControlDelegate(int temperature);
        public event ClimateControlDelegate climateControlEvent;

        private int airTemperature;

        public int AirTemperature
        {
            get
            {
                return airTemperature;
            }

            set
            {
                airTemperature = value;

                if (climateControlEvent != null)
                {
                    climateControlEvent.Invoke(airTemperature);
                }
            }
        }

    }
}
