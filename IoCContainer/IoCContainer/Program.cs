using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            //IKernel kernel = new StandardKernel();
            //kernel.Bind<ISchedule>().To<ScheduleManager1>();

            //var scheduleManager = kernel.Get<ISchedule>();
            //Console.WriteLine(scheduleManager.GetSchedule());

            var c = new SimpleIocContainer();
            c.Bind<ISchedule, ScheduleManager2>();
            //c.Bind<ISchedule, ScheduleManager1>();

            var scheduleManager1 = c.Get<ISchedule>();
            Console.WriteLine(scheduleManager1.GetSchedule());

            var scheduleViewer = new ScheduleViewer(scheduleManager1);
            Console.WriteLine(scheduleViewer.RenderSchedule());

            Console.ReadLine();
        }
    }
}
