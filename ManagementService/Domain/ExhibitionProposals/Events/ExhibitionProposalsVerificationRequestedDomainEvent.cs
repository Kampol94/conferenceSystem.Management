using ManagementService.Domain.Contracts;

namespace ManagementService.Domain.ExhibitionProposals.Events;

public class ExhibitionProposalsVerificationRequestedDomainEvent : DomainEventBase
{
    public ExhibitionProposalsVerificationRequestedDomainEvent(ExhibitionProposalsId exhibitionProposalsId)
    {
        ExhibitionProposalsId = exhibitionProposalsId;
    }

    public ExhibitionProposalsId ExhibitionProposalsId { get; }
}