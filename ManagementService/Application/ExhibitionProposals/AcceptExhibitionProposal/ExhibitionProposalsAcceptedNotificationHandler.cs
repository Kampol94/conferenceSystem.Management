using ManagementService.Application.Contracts;
using ManagementService.Domain.ExhibitionProposals.Events;
using MediatR;
using System.ComponentModel.Design;

namespace ManagementService.Application.ExhibitionProposals.AcceptExhibitionProposal;

public class ExhibitionProposalsAcceptedNotificationHandler : INotificationHandler<ExhibitionProposalsAcceptedDomainEvent>
{
    private readonly IEventService _eventService;

    public ExhibitionProposalsAcceptedNotificationHandler()
    {
        //_eventService = eventService;
    }

    public Task Handle(ExhibitionProposalsAcceptedDomainEvent notification, CancellationToken cancellationToken)
    {
        //_eventService.Publish(new ExhibitionProposalsAcceptedIntegrationEvent(
        //    notification.Id,
        //    notification.OccurredOn,
        //    notification.ExhibitionProposalsId.Value));

        return Task.CompletedTask;
    }
}