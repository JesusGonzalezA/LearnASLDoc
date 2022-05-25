public class Startup {
    // ...
    public void ConfigureServices
    (
        IServiceCollection services
    )
    {
        services.AddSingleton<IUriService>(provider =>
        {
            return new UriService(
                // Custom arguments
            );
        });
     
        services
            .AddScoped<IEmailService, EmailService>();
     
        services
            .AddTransient<IUnitOfWork, UnitOfWork>();

        // ...
    }
}