using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClimateControl
{
    //well done
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
                //тут можно поставить проверку на работу бизнес логики
                // если температура не изменилась  - можно делегат не вызывать
                // prevTemp = airTemperature
                airTemperature = value;

                //if prevTemp != airTemperature
                if (climateControlEvent != null)
                {
                    climateControlEvent.Invoke(airTemperature);
                }
            }
        }

    }
}
