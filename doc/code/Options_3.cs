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