using System.Reflection;
using FX850P.Application.Common.Dtos;
using FX850P.Application.Mediator;
using FX850P.Application.Mediator.Contracts;
using FX850P.Application.Roles.Commands.CreateRole;
using FX850P.Application.Roles.Commands.DeleteRole;
using FX850P.Application.Roles.Commands.UpdateRole;
using FX850P.Application.Roles.Queries.GetRoleDetails;
using FX850P.Application.Roles.Queries.GetRoleList;
using FX850P.Application.Users.Commands.AddRoleToUser;
using FX850P.Application.Users.Commands.AddRoleUser;
using FX850P.Application.Users.Commands.CreateUser;
using FX850P.Application.Users.Commands.DeleteUser;
using FX850P.Application.Users.Commands.LockUser;
using FX850P.Application.Users.Commands.UnlockUser;
using FX850P.Application.Users.Commands.UpdateUser;
using FX850P.Application.Users.Commands.UpdateUserPassword;
using FX850P.Application.Users.Dtos;
using FX850P.Application.Users.Queries.GetUserDetails;
using FX850P.Application.Users.Queries.GetUserList;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace FX850P.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
