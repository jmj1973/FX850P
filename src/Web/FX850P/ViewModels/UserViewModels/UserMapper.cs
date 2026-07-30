using Application.Users.Commands.CreateUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Commands.UpdateUserPassword;
using Application.Users.Dtos;

namespace FX850P.ViewModels.UserViewModels;

public static class UserMapper
{
    public static UserViewModel ToViewModel(this UserDto dto) => 
        new UserViewModel
        {
            Id = dto.Id,
            UserName = dto.UserName,
            FirstName = "",
            LastName = "",
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            LockoutEnabled = dto.LockoutEnabled
        };

    public static CreateUserCommand ToCreateCommand(this UserViewModel vm) =>
        new CreateUserCommand
        {
            FirstName = vm.FirstName,
            LastName = vm.LastName,
            Email = vm.Email,
            UserName = vm.UserName,
            Password = "",
            Role = vm.Role
        };

    public static UpdateUserCommand ToUpdateCommand(this UserViewModel vm) =>
        new UpdateUserCommand
        {
            Id = vm.Id,
            UserName = vm.UserName,
            Email = vm.Email,
            FirstName = vm.FirstName,
            LastName = vm.LastName,
            PhoneNumber = vm.PhoneNumber,
            Role = vm.Role
        };

    public static UpdateUserPasswordCommand ToUpdatePasswordCommand(this UpdatePasswordViewModel vm) =>
        new UpdateUserPasswordCommand
        {
            Id = vm.Id,
            OldPassword = vm.OldPassword,
            NewPassword = vm.NewPassword,
            ConfirmPassword = vm.ConfirmPassword
        };

}
