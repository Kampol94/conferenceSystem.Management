using ManagementService.Domain.Members;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ManagementService.Domain.Users;
using UserService.Application.Contracts.Commands;
using ManagementService.Application.IntegrationEvents.EventHandlings;
using ManagementService.Application.Contracts;
using ManagementService.Application.IntegrationEvents.Events;

namespace ManagementService.Application;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient<IUserContext, UserContext>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CommitBehavior<,>));
        services.AddTransient<IIntegrationEventHandler<NewUserRegisteredIntegrationEvent>, NewUserRegisteredIntegrationEventHandler>();
        services.AddTransient<IIntegrationEventHandler<ExhibitionProposedIntegrationEvent>, ExhibitionProposedIntegrationEventHandler>();

        return services;
    }
}
