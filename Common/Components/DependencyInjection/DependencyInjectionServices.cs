using System.Reflection;
using System.Runtime.InteropServices;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionServices
    {
        public static IServiceCollection AddAutoServices(this IServiceCollection services,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes().Where(cls => cls.Name.EndsWith("Service")&&cls.Namespace=="ChatApi.Service").ToArray();

            foreach (var type in types)
            {
                switch (lifetime)
                {
                    case ServiceLifetime.Transient:
                        services.AddTransient(type);
                        break;
                    case ServiceLifetime.Scoped:
                        services.AddScoped(type);
                        break;
                    case ServiceLifetime.Singleton:
                        services.AddSingleton(type);
                        break;
                    default:
                        services.AddTransient(type);
                        break;

                }
            }

            return services;
        }
    }
}
