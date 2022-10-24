using ManagementService.Application.Contracts;
using ManagementService.Application.IntegrationEvents.Events;
using ManagementService.Application.Members.CreateMember;
using MediatR;

namespace ManagementService.Application.IntegrationEvents.EventHandlings;
public class NewUserRegisteredIntegrationEventHandler : IIntegrationEventHandler<NewUserRegisteredIntegrationEvent>
{
    private readonly IMediator _mediator;

    public NewUserRegisteredIntegrationEventHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(NewUserRegisteredIntegrationEvent @event)
    {
        var command = new CreateMemberCommand(
            Guid.NewGuid(),
            @event.UserId,
            @event.Login,
            @event.Email,
            @event.FirstName,
            @event.LastName,
            @event.Name);
        await _mediator.Send(command);
    }
}
