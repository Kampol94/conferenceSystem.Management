using ManagementService.Domain.Contracts;

namespace ManagementService.Domain.ExhibitionProposals.Events;

public class ExhibitionProposalsAcceptedDomainEvent : DomainEventBase
{
    public ExhibitionProposalsAcceptedDomainEvent(ExhibitionProposalsId exhibitionProposalsId)
    {
        ExhibitionProposalsId = exhibitionProposalsId;
    }

    public ExhibitionProposalsId ExhibitionProposalsId { get; }
}