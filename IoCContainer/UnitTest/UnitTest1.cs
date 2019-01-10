using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoCContainer;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Get_NewObject()
        {
            var c = new SimpleIocContainer();
            c.Bind<ISchedule, ScheduleManager1>();
            var scheduleManager = c.Get<ISchedule>();

            Assert.IsNotNull(scheduleManager);
        }

        [TestMethod]
        public void Bind_isRegistered()
        {
            try
            {
                var c = new SimpleIocContainer();
                c.Bind<ISchedule, ScheduleManager1>();
                c.Bind<ISchedule, ScheduleManager1>();

                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is InvalidOperationException);
            }
        }

        [TestMethod]
        public void Bind_notInterface()
        {
            try
            {
                var c = new SimpleIocContainer();
                c.Bind<ScheduleManager1, ScheduleManager1>();
              
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is InvalidOperationException);
            }
        }

        [TestMethod]
        public void Bind_notClass()
        {
            try
            {
                var c = new SimpleIocContainer();
                c.Bind<ISchedule, ISchedule>();

                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is InvalidOperationException);
            }
        }

        [TestMethod]
        public void Bind_isSinglton()
        {
            var c = new SimpleIocContainer();
            c.BindSingleton<ISchedule, ScheduleManager1>();
            var scheduleManager1 = c.Get<ISchedule>();
            var scheduleManager2 = c.Get<ISchedule>();

            Assert.AreEqual(scheduleManager1, scheduleManager2);
        }

        [TestMethod]
        public void Bind_notSinglton()
        {
            var c = new SimpleIocContainer();
            c.Bind<ISchedule, ScheduleManager1>();
            var scheduleManager1 = c.Get<ISchedule>();
            var scheduleManager2 = c.Get<ISchedule>();

            Assert.AreNotEqual(scheduleManager1, scheduleManager2);
        }

        [TestMethod]
        public void BindInstance()
        {
            var c = new SimpleIocContainer();
            var scheduleManager1 = new ScheduleManager1();
            c.BindInstance<ISchedule, ScheduleManager1>(scheduleManager1);
            var scheduleManager2 = c.Get<ISchedule>();

            Assert.AreEqual(scheduleManager1, scheduleManager2);
        }


    }
}
