public static class ServiceCollectionExtensions {
    public static IServiceCollection ConfigureAutomapper(this IServiceCollection services)
    {
        MapperConfiguration mapperConfig = new MapperConfiguration(m =>
        {
            m.AddProfile(new UserAutomapperProfile());
            m.AddProfile(new TestAutomapperProfile());
            m.AddProfile(new StatsAutomapperProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}