using ManagementService.Application.Contracts;
using ManagementService.Application.IntegrationEvents.EventHandlings;
using ManagementService.Application.IntegrationEvents.Events;
using ManagementService.Infrastructure.Services;
using MediatR;

namespace ManagementService.API;

public static class EventsBusStartup
{
    public static void Initialize(IEventBus eventBus, IMediator mediator)
    {
        eventBus.Subscribe<NewUserRegisteredIntegrationEvent>(new NewUserRegisteredIntegrationEventHandler(mediator));
        eventBus.Subscribe(new ExhibitionProposedIntegrationEventHandler(mediator));
    }
}
