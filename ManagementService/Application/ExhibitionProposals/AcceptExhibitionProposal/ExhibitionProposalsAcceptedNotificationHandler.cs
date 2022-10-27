using ManagementService.Application.Contracts;
using ManagementService.Application.IntegrationEvents.Events;
using ManagementService.Domain.ExhibitionProposals.Events;
using ManagementService.Infrastructure.Services;
using MediatR;
using System.ComponentModel.Design;

namespace ManagementService.Application.ExhibitionProposals.AcceptExhibitionProposal;

public class ExhibitionProposalsAcceptedNotificationHandler : INotificationHandler<ExhibitionProposalsAcceptedDomainEvent>
{
    private readonly IEventBus _eventService;

    public ExhibitionProposalsAcceptedNotificationHandler(IEventBus eventService)
    {
        _eventService = eventService;
    }

    public Task Handle(ExhibitionProposalsAcceptedDomainEvent notification, CancellationToken cancellationToken)
    {
        _eventService.Publish(new ExhibitionProposalAcceptedIntegrationEvent(
            notification.Id,
            notification.When,
            notification.ExhibitionProposalsId.Value));

        return Task.CompletedTask;
    }
}