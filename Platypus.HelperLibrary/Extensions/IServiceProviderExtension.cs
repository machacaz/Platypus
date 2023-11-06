using Microsoft.Extensions.DependencyInjection;

namespace Platypus.HelperLibrary.Extensions;

public static class IServiceProviderExtension
{
    public static T? GetServicesExtended<T, TImplementation>(this IServiceProvider serviceProvider) where TImplementation : T
    {
        return serviceProvider.GetServices<T>().FirstOrDefault(sI => sI.GetType() == typeof(TImplementation));
    }

    public static IEnumerable<T> GetServicesExtended<T>(this IServiceProvider serviceProvider) 
    {
        return serviceProvider.GetServices<T>();
    }
}