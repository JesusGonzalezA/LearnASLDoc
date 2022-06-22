public static class ServiceCollectionExtensions {

    public static IServiceCollection ConfigureValidators(this IServiceCollection services)
    {
        services.AddMvc(options =>
        {
            options.Filters.Add<ValidationFilter>();
        }).AddFluentValidation();

        services.AddTransient<IValidator<LoginDto>, LoginDtoValidator>();
        // ... rest of validators

        return services;
    }
}