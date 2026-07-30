using Application.Users.Commands.UpdateUser;
using Application.Users.Dtos;
using Application.Users.Queries.GetUserList;
using Domain.Entities.Identity;
using Domain.Resources;

namespace Application.Users;

public static class UserMapper
{
    public static UserDto ToDto(this ApplicationUser user) =>
        new UserDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Fullname = user.FirstName + " " + user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            LockoutEnabled = user.LockoutEnabled,
        };


    public static UserDto ToDto(this ApplicationUser user, string role) => 
        new UserDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Fullname = user.FirstName + " " + user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            LockoutEnabled = user.LockoutEnabled,
            Role = role
        };

    public static ApplicationUser ToEntity(this UpdateUserCommand command) =>
        new ApplicationUser
        {
            Id = command.Id,
            UserName = command.UserName,
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            PhoneNumber = command.PhoneNumber
        };  

    public static ApplicationUser ToEntity(this UpdateUserCommand command, ApplicationUser entity)
    {
        entity.Id = command.Id;
        entity.UserName = command.UserName;
        entity.Email = command.Email;
        entity.FirstName = command.FirstName;
        entity.LastName = command.LastName; 
        entity.PhoneNumber = command.PhoneNumber;

        return entity;
    }

    public static UserQuery ToEntity(this GetUserListQuery query) =>
        new UserQuery
        {
            SearchString = query.SearchString,
            SortBy = query.SortBy,
            IsSortAscending = query.IsSortAscending,
            Page = query.Page,
            PageSize = query.PageSize,
        };


}
