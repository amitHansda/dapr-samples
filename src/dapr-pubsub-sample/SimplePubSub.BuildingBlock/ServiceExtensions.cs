using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace SimplePubSub.BuildingBlock
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomDaprClient(this IServiceCollection services) {
            services.AddDaprClient(config => {
                config.UseJsonSerializationOptions(new System.Text.Json.JsonSerializerOptions { 
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            });
            return services;
        }
    }
}
