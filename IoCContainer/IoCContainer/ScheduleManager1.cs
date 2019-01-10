using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCContainer
{
    public class ScheduleManager1 : ISchedule
    {
        public String GetSchedule()
        {
            return "1,2,3";
        }
    }
}
