using AutoMapper;
using Tech_sell_user.Application.DTOs.Request;
using Tech_sell_user.Domain.Entities;

namespace Tech_sell_user.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequest, User>().ReverseMap();
            CreateMap<UserPutRequest, User>().ReverseMap();
        }
    }
}