using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCContainer
{
    public class SimpleIocContainer
    {
        private readonly IDictionary<Type, RegisteredObject> _bindingObjects = new Dictionary<Type, RegisteredObject>();

        public void Bind<TInterface, TClass>() where TClass : class
        {
            Register(typeof(TInterface), typeof(TClass), false);
        }

        public void BindSingleton<TInterface, TClass>() where TClass : class
        {
            Register(typeof(TInterface), typeof(TClass), true);
        }

        public void Bind(Type TInterface, Type TClass)
        {
            Register(TInterface, TClass, false);
        }

        public void BindSingleton(Type TInterface, Type TClass)
        {
            Register(TInterface, TClass, true);
        }

        public void BindInstance<TInterface, TClass>(TClass instance) where TClass : class
        {
            CheckObjects(typeof(TInterface), typeof(TClass));

            _bindingObjects.Add(typeof(TInterface), new RegisteredObject(typeof(TClass), instance));
        }
       
        public TTypeToResolve Get<TTypeToResolve>()
        {
            return (TTypeToResolve)ResolveObject(typeof(TTypeToResolve));
        }

        private void Register(Type TInterface, Type TClass, bool isSingleton)
        {
            CheckObjects(TInterface, TClass);

            _bindingObjects.Add(TInterface, new RegisteredObject(TClass, isSingleton));
        }

        private object ResolveObject(Type type)
        {
            var registeredObject = _bindingObjects[type];

            if (registeredObject == null)
            {
                throw new ArgumentOutOfRangeException(string.Format("The type {0} has not been registered", type.Name));
            }

            object instance = registeredObject.SingletonInstance;

            if (instance == null)
            {
                var parameters = ResolveConstructorParameters(registeredObject);
                instance = registeredObject.CreateInstance(parameters.ToArray());
            }

            return instance;
        }

        private IEnumerable<object> ResolveConstructorParameters(RegisteredObject registeredObject)
        {
            var constructorInfo = registeredObject.Type
                .GetConstructors()
                .First();

            return constructorInfo.GetParameters()
                .Select(parameter => ResolveObject(parameter.ParameterType));
        }

        private void CheckObjects(Type TInterface, Type TClass)
        {
            if (TInterface.IsClass)
            {
                throw new InvalidOperationException($"'{TInterface.Name}' not interface");
            }

            if (!TClass.IsClass)
            {
                throw new InvalidOperationException($"'{TInterface.Name}' not not class");
            }


            if (_bindingObjects.ContainsKey(TInterface))
            {
                throw new InvalidOperationException($"'{TInterface.Name}' is registered");
            }
        }
    }
}
