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