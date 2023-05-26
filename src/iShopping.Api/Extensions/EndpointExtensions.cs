using iShopping.Api.Infrastructure;
using System.Reflection;

namespace iShopping.Api.Extensions
{
    public static class EndpointExtensions
    {
        public static IServiceCollection AddMinimalApiDefinition(this IServiceCollection services, IConfiguration configuration, params Type[] markers)
        {
            List<IEndpointDefinition> endpointDefinitions = new();

            foreach(var marker in markers)
            {
                var endpoints = marker.Assembly.GetExportedTypes().Where(x => typeof(IEndpointDefinition).IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface)
                                .Select(Activator.CreateInstance).Cast<IEndpointDefinition>();

                endpointDefinitions.AddRange(endpoints);
            }            
            services.AddSingleton<IReadOnlyCollection<IEndpointDefinition>>(endpointDefinitions);

            foreach(var endpointDefinition in endpointDefinitions)
            {
                endpointDefinition.DefineServices(services, configuration);
            }

            return services;
        }


        public static WebApplication UseMinimalApiApplication(this WebApplication app)
        {
            IReadOnlyCollection<IEndpointDefinition> endpointDefinitions = app.Services.GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();

            if (endpointDefinitions != null)
            {
                foreach (var endpointDefinition in endpointDefinitions)
                {
                    endpointDefinition.DefineEndpoints(app);
                }
            }

            return app;
        }
    }
}
