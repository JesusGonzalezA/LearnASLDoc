// Definition
namespace Core.Options
{
    public class PaginationOptions
    {
        public int DefaultPageSize { get; set; }
        public int DefaultPageNumber { get; set; }
        public int MaximumPageSize { get; set; }
    }
}

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

// Usage
namespace Core.Services
{
    public class TestService : ITestService
    {
        // ...
        private readonly 
            PaginationOptions _paginationOptions;

        public TestService
        (
            IOptions<PaginationOptions> 
            paginationOptions
        )
        {
            _paginationOptions = 
                paginationOptions.Value;
        }
    }
}