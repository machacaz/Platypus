namespace Platypus.AspNetCore.HelperLibrary.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json.Converters;

    public static class SwaggerExtensions
    {
        public static void ShowEnumsInSwagger(this WebApplicationBuilder builder, bool showEnumsInSwagger = true)
        {
            if (showEnumsInSwagger)
            {
                builder.Services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.Converters.Add(new StringEnumConverter()));
            }
        }
    }
}