public class Startup {
    public IConfiguration Configuration { get; }

    public Startup
    (
        IConfiguration configuration
    )
    {
        Configuration = configuration;
    }

    public void ConfigureServices
    (
        IServiceCollection services
    )
    {
        ConfigureSwagger(services);

        services
            .ConfigureDI(Configuration)
            .ConfigureLogger()
            .ConfigureAutomapper()
            .ConfigureOptions(Configuration)
            .ConfigureDatabase(Configuration)
            .ConfigureAuthentication(Configuration)
            .ConfigureValidators()
            .ConfigureHealthChecks()
            .ConfigureCors(Configuration, _corsName)
            .ConfigureHttpClients();
    }  
}