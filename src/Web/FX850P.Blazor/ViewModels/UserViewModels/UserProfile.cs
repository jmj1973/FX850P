using AutoMapper;
using FX850P.Application.Users.Commands.CreateUser;
using FX850P.Application.Users.Commands.UpdateUser;
using FX850P.Application.Users.Commands.UpdateUserPassword;
using FX850P.Application.Users.Dtos;

namespace FX850P.Blazor.ViewModels.UserViewModels;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, UserDetailViewModel>().ReverseMap();
        CreateMap<UserViewModel, CreateUserCommand>();
        CreateMap<UserDto, UserViewModel>();
        CreateMap<UserViewModel, UpdateUserCommand>();
        CreateMap<UpdatePasswordViewModel, UpdateUserPasswordCommand>();
    }
}
