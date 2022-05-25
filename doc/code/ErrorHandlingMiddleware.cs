public class Startup {
    // ...
    public void Configure
    (
        IApplicationBuilder app, 
        IWebHostEnvironment env
    )
    {
        // ...
        app.UseMiddleware<ErrorHandlingMiddleware>();
    }
}

public class ErrorHandlingMiddleware
{
    // ...
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Exception ex) when ( 
            ex is BusinessException 
            || ex is ControllerException
        )
        {
            await HandleBusinessExceptionAsyn
            (
                context, 
                ex
            );
        }
        catch (Exception ex)
        {
            await LogErrorExceptionWithRequestBody
            (
                context, 
                ex
            );
            await HandleUnhandledExceptionAsync
            (
                context, 
                ex
            );
        }
    }
    // ...
}