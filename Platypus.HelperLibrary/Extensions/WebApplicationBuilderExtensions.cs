namespace Platypus.HelperLibrary.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json.Converters;
    using System.Reflection;

    public static class WebApplicationBuilderExtensions
    {
        public static void ShowEnumsInSwagger(this WebApplicationBuilder builder, bool showEnumsInSwagger = true)
        {
            if (showEnumsInSwagger)
            {
                builder.Services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.Converters.Add(new StringEnumConverter()));
            }
        }

        public static void RegisterTypes<I>(this IServiceCollection servicesCollections)
        {
            //https://stackoverflow.com/questions/41806168/register-all-implementation-of-type-t-interface-in-net-core
            //https://stackoverflow.com/questions/56143613/inject-generic-interface-in-net-core
            Assembly.GetExecutingAssembly()
                       .GetTypes()
                       .Where(item => item.GetInterfaces()
                       .Where(i => i.IsGenericType)
                       .Any(i => i.GetGenericTypeDefinition() == typeof(I)) && !item.IsAbstract && !item.IsInterface)
                       .ToList()
                       .ForEach(assignedTypes =>
                       {
                           var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(I));
                           servicesCollections.AddScoped(serviceType, assignedTypes);
                       });


        }
    
    }
}
