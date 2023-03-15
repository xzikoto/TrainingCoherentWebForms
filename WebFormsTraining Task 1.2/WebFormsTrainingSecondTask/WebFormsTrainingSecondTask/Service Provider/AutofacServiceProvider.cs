using Autofac;
using System;
using System.Reflection;

namespace WebFormsTrainingSecondTask.Service
{
    public class AutofacServiceProvider : IServiceProvider
    {
        private readonly ILifetimeScope _rootContainer;

        public AutofacServiceProvider(ILifetimeScope rootContainer)
        {
            _rootContainer = rootContainer;
        }

        public object GetService(Type serviceType)
        {
            if (_rootContainer.IsRegistered(serviceType))
            {
                return _rootContainer.Resolve(serviceType);
            }

            return Activator.CreateInstance(serviceType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance, null, null, null);
        }
    }
}
