// Creating the filter
public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            List<string> errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                .SelectMany(v => v.Errors)
                .Select(v => v.ErrorMessage)
                .ToList();
            context.Result = new BadRequestObjectResult(
                new ErrorApiResponse<List<string> >(errors)
            );
            return;
        }

        await next();
    }
}

// Setting up the filter
public static class ServiceCollectionExtensions {
    public static IServiceCollection ConfigureValidators(this IServiceCollection services)
    {
        services.AddMvc(options =>
        {
            options.Filters.Add<ValidationFilter>();
        }).AddFluentValidation();

        // ...

        return services;
    }
}