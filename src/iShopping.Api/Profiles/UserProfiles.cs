using AutoMapper;
using iShopping.Dto.Account;
using iShopping.Entities;

namespace iShopping.Api.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
        }
    }
}
