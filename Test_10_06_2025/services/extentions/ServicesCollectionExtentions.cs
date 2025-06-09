using Test_10_06_2025.services.abstractions;

namespace Test_10_06_2025.services.extentions;

public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<Iservice, service>();
        return services;
    }
}