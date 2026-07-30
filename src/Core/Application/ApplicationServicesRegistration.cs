using Application.Common.Dtos;
using Application.Common.Dtos;
using Application.Mediator;
using Application.Mediator.Contracts;
using Application.Roles.Commands.CreateRole;
using Application.Roles.Commands.DeleteRole;
using Application.Roles.Commands.UpdateRole;
using Application.Roles.Queries.GetRoleDetails;
using Application.Roles.Queries.GetRoleList;
using Application.Users.Commands.AddRoleToUser;
using Application.Users.Commands.AddRoleUser;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.LockUser;
using Application.Users.Commands.UnlockUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Commands.UpdateUserPassword;
using Application.Users.Dtos;
using Application.Users.Queries.GetUserDetails;
using Application.Users.Queries.GetUserList;
using Microsoft.Extensions.DependencyInjection;


namespace Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        //Appliction Mediator
        services.AddSingleton<IApplicationMediator, ApplicationMediator>();

        //Application Behaviors
        // User        
        services.AddTransient<IApplicationRequestHandler<CreateUserCommand, UserDto>, CreateUserCommandHandler>();
        services.AddTransient<IApplicationRequestHandler<UpdateUserCommand, UserDto>, UpdateUserCommandHandler>();
        services.AddTransient<IApplicationRequestHandler<DeleteUserCommand, UserDto>, DeleteUserCommandHandler>();
        services.AddTransient<IApplicationRequestHandler<AddRoleToUserCommand, UserDto>, AddRoleToUserCommandHandler>();
        services.AddTransient<IApplicationRequestHandler<LockUserCommand, UserDto>, LockUserCommandHandler>();
        services.AddTransient<IApplicationRequestHandler<UnlockUserCommand, UserDto>, UnlockUserCommandHandler>();
        services.AddTransient<IApplicationRequestHandler<UpdateUserPasswordCommand, UserDto>, UpdateUserPasswordCommandHandler>();

        services.AddTransient<IApplicationRequestHandler<GetUserDetailsQuery, UserDto>, GetUserDetailsQueryHandler>();
        services.AddTransient<IApplicationRequestHandler<GetUserListQuery, QueryResultDto<UserDto>>, GetUserListQueryHandler>();

        // Roles
        services.AddTransient<IApplicationRequestHandler<CreateRoleCommand, KeyValuePairDto<string>>, CreateRoleCommandHandler>();
        services.AddTransient<IApplicationRequestHandler<UpdateRoleCommand, KeyValuePairDto<string>>, UpdateRoleCommandHandler>();
        services.AddTransient<IApplicationRequestHandler<DeleteRoleCommand, KeyValuePairDto<string>>, DeleteRoleCommandHandler>();

        services.AddTransient<IApplicationRequestHandler<GetRoleDetailsQuery, KeyValuePairDto<string>>, GetRoleDetailsQueryHandler>();
        services.AddTransient<IApplicationRequestHandler<GetRoleListQuery, QueryResultDto<KeyValuePairDto<string>>>, GetRoleListQueryHandler>();

        return services;
    }
}
