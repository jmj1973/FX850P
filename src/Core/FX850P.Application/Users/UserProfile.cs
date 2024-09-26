using AutoMapper;
using FX850P.Application.Users.Commands.CreateUser;
using FX850P.Application.Users.Commands.UpdateUser;
using FX850P.Application.Users.Dtos;
using FX850P.Application.Users.Queries.GetUserList;
using FX850P.Domain.Entities.Identity;
using FX850P.Domain.Resources;

namespace FX850P.Application.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<GetUserListQuery, UserQuery>();
        CreateMap<CreateUserCommand, ApplicationUser>();
        CreateMap<UpdateUserCommand, ApplicationUser>();
        CreateMap<ApplicationUser, UserDto>();
    }
}
