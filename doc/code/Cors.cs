public static class ServiceCollectionExtensions {
    public static IServiceCollection ConfigureCors(this IServiceCollection services, IConfiguration configuration, string corsName)
    {
        services
            .AddCors(o =>
            {
                o.AddPolicy(name: corsName, builder =>
                {
                    string origin
                        = configuration
                            .GetSection("Frontend")
                            .GetSection("Origin")
                            .Value;

                    builder
                        .SetIsOriginAllowed(or => new Uri(or).Host == origin)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithExposedHeaders("X-Pagination");
                });
            });

        return services;
    }
}