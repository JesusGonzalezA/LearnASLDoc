// Create a profile
public class UserAutomapperProfile : Profile
{
    public UserAutomapperProfile()
    {
        CreateMap<BaseEntity, BaseDto>()
            .ReverseMap();

        CreateMap<UserEntity, UserDto>()
            .IncludeBase<BaseEntity, BaseDto>()
            .ReverseMap();
    }
}

// Set up
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

// Use 
UserDto userDto = _mapper.Map<UserDto>(userEntity);