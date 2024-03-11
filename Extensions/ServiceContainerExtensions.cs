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
                var interfaceType = serviceType.GetInterface($"I{serviceType.Name}");
                if(interfaceType is null)
                {
                    services.AddScoped(serviceType);
                    continue;
                }
                services.AddScoped(interfaceType, serviceType);
            }

            return services;
        }
    }
}
