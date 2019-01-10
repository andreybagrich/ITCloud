using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCContainer
{
    class ScheduleManager2 : ISchedule
    {
        public String GetSchedule()
        {
            return "5,6,7";
        }
    }
}
