using System.Reflection;
using VerticalSliceArchitecture.Attributes;

namespace VerticalSliceArchitecture.Extensions
{
    public static class ServiceContainerExtensions
    {
        public static IServiceCollection AddServicesFromAssemby(this IServiceCollection services, Assembly assembly) {

            var serviceTypes = assembly.GetTypes().Where(t => t.GetCustomAttributes<ServiceMarkerAttribute>(true).Any()).ToList();

            foreach (var serviceType in serviceTypes)
            {
                var attribute = serviceType.GetCustomAttribute<ServiceMarkerAttribute>();

                if(attribute.InterfaceType is null)
                {
                    services.AddScoped(serviceType);
                    continue;
                }
                if (!attribute.InterfaceType.IsAssignableFrom(serviceType))
                    throw new Exception($"The type {serviceType.Name} does not provide an implementation for the service {attribute.InterfaceType.Name}.");

                services.AddScoped(attribute.InterfaceType, serviceType);
            }

            return services;
        }
    }
}
