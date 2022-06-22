// Configuration
namespace Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        // ...
        public static IServiceCollection 
        ConfigureOptions
        (
            this IServiceCollection services, 
            IConfiguration configuration
        )
        {
            services.Configure<PaginationOptions>(
                options => 
                configuration
                    .GetSection("Pagination")
                    .Bind(options)
            );
            // ...
        }
    }
}