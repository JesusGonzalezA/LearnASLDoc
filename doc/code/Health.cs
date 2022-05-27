public static class IServiceCollectionExtensions
{
    public static IServiceCollection ConfigureHealthChecks(this IServiceCollection services)
    {
        services
            .AddHealthChecks()
            .AddDbContextCheck<DatabaseContext>();

        return services;
    }
}