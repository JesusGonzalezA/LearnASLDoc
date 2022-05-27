// Creating the filter
public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(login => login.Email)
            .NotNull()
            .EmailAddress();

        RuleFor(login => login.Password)
            .NotNull()
            .Length(6, 15);

        RuleFor(login => login.Password)
            .Must(HasValidPassword)
            .WithMessage("'{PropertyName}' should have at least one digit, one symbol, a lowercase letter and an uppercase letter.");
    }

    private bool HasValidPassword(string pw)
    {
        Regex lowercase = new Regex("[a-z]+");
        Regex uppercase = new Regex("[A-Z]+");
        Regex digit = new Regex("(\\d)+");
        Regex symbol = new Regex("(\\W)+");

        return (lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw) && symbol.IsMatch(pw));
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

        services.AddTransient<IValidator<LoginDto>, LoginDtoValidator>();
        // ... rest of validators

        return services;
    }
}