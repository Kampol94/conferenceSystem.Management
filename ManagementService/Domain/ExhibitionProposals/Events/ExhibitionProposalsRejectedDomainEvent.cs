using ManagementService.Domain.Contracts;

namespace ManagementService.Domain.ExhibitionProposals.Events;

public class ExhibitionProposalsRejectedDomainEvent : DomainEventBase
{
    public ExhibitionProposalsRejectedDomainEvent(ExhibitionProposalsId exhibitionProposalsId)
    {
        ExhibitionProposalsId = exhibitionProposalsId;
    }

    public ExhibitionProposalsId ExhibitionProposalsId { get; }
}