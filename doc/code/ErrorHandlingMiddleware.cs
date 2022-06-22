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
