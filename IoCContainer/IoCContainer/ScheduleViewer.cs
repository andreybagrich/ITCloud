using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCContainer
{
    public class ScheduleViewer
    {
        ISchedule _scheduleManager;

        public ScheduleViewer(ISchedule scheduleManager)
        {
            _scheduleManager = scheduleManager;
        }
      
        public string RenderSchedule()
        {
            return "<" + _scheduleManager.GetSchedule() + ">";
        }
    }
}
