public static class ServiceCollectionExtensions {
    public static IServiceCollection ConfigureDI
    (
        this IServiceCollection services, 
        IConfiguration configuration
    )
    {
        services
            .AddScoped<IEmailService, EmailService>();
        services
            .AddScoped<IAIService, AIService>();
        services
            .AddScoped<ITokenService, TokenService>();
        services
            .AddScoped<IStoreService, StoreService>();
        services
            .AddTransient<IUnitOfWork, UnitOfWork>();
        
        // ...

        return services;
    }
}
