using Autofac.Builder;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace WebFormsTrainingSecondTask.Service_Provider
{
    public class WebFormRegistrationSource : IRegistrationSource
    {
        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<ServiceRegistration>> registrationAccessor)
        {
            if (service is IServiceWithType serviceWithType && serviceWithType.ServiceType.Namespace.StartsWith("ASP", true, CultureInfo.InvariantCulture))
            {
                return new[]
                {
                    RegistrationBuilder.ForType(serviceWithType.ServiceType).CreateRegistration()
                };
            }

            return Enumerable.Empty<IComponentRegistration>();
        }

        public bool IsAdapterForIndividualComponents => true;
    }
}