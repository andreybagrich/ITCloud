using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCContainer
{
    internal class RegisteredObject
    {
        public Type Type { get; private set; }

        public object SingletonInstance { get; private set; }

        private readonly bool _isSinglton;

        public RegisteredObject(Type type, object instance)
        {
            Type = type;
            _isSinglton = true;
            SingletonInstance = instance;
        }

        public RegisteredObject(Type type, bool isSingleton)
        {
            Type = type;
            _isSinglton = isSingleton;
        }

        public object CreateInstance(params object[] args)
        {
            object instance = Activator.CreateInstance(Type, args);

            if (_isSinglton)
            {
                SingletonInstance = instance; 
            }

            return instance;
        }
    }
}
