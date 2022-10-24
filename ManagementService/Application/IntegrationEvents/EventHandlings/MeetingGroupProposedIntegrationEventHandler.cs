using ManagementService.Application.Contracts;
using MediatR;
using ManagementService.Application.IntegrationEvents.Events;
using ManagementService.Application.ExhibitionProposals.RequestExhibitionProposalVerification;

namespace ManagementService.Application.IntegrationEvents.EventHandlings;

public class ExhibitionProposedIntegrationEventHandler : IIntegrationEventHandler<ExhibitionProposedIntegrationEvent>
{
    private readonly IMediator _mediator;

    public ExhibitionProposedIntegrationEventHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(ExhibitionProposedIntegrationEvent @event)
    {
        var command = new RequestExhibitionProposalsVerificationCommand(
            Guid.NewGuid(),
            @event.ExhibitionProposalId,
            @event.Name,
            @event.Description,
            @event.ProposalUserId,
            @event.ProposalDate);
        await _mediator.Send(command);
    }
}