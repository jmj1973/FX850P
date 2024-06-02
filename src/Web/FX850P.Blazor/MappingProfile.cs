using AutoMapper;
using FX850P.Application.Common.Dtos;
using FX850P.Application.Roles.Commands.CreateRole;
using FX850P.Application.Roles.Commands.UpdateRole;
using FX850P.Application.Users.Commands.CreateUser;
using FX850P.Application.Users.Commands.UpdateUser;
using FX850P.Application.Users.Commands.UpdateUserPassword;
using FX850P.Application.Users.Dtos;
using FX850P.Blazor.ViewModels.CommonViewModels;
using FX850P.Blazor.ViewModels.UserViewModels;

namespace FX850P.Blazor
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // Users
            CreateMap<UserDto, UserDetailViewModel>().ReverseMap();
            CreateMap<UserViewModel, CreateUserCommand>();
            CreateMap<UserDto, UserViewModel>();
            CreateMap<UserDto, UserListViewModel>();
            CreateMap<UserViewModel, UpdateUserCommand>();
            CreateMap<UpdatePasswordViewModel,UpdateUserPasswordCommand> ();

            //Roles
            CreateMap<KeyValuePairDto<string>, KeyValuePairViewModel<string>>().ReverseMap();
            CreateMap<KeyValuePairViewModel<string>, CreateRoleCommand>();
            CreateMap<KeyValuePairViewModel<string>, UpdateRoleCommand>();



        }

    }
}
