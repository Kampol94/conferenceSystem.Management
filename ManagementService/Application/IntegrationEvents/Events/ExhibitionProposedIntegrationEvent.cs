using ManagementService.Application.Contracts;

namespace ManagementService.Application.IntegrationEvents.Events;

public class ExhibitionProposedIntegrationEvent : IntegrationEvent
{
    public Guid ExhibitionProposalId { get; }

    public string Name { get; }

    public string Description { get; }

    public Guid ProposalUserId { get; }

    public DateTime ProposalDate { get; }

    public ExhibitionProposedIntegrationEvent(
        Guid id,
        DateTime occurredOn,
        Guid exhibitionProposalId,
        string name,
        string description,
        Guid proposalUserId,
        DateTime proposalDate)
        : base(id, occurredOn)
    {
        ExhibitionProposalId = exhibitionProposalId;
        Name = name;
        Description = description;
        ProposalUserId = proposalUserId;
        ProposalDate = proposalDate;
    }
}