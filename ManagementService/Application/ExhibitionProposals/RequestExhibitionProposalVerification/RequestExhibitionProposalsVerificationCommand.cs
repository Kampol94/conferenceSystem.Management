using ManagementService.Application.Contracts.Commands;

namespace ManagementService.Application.ExhibitionProposals.RequestExhibitionProposalVerification;

public class RequestExhibitionProposalsVerificationCommand : CommandBase<Guid>
{
    public RequestExhibitionProposalsVerificationCommand(
        Guid id,
        Guid exhibitionProposalsId,
        string name,
        string description,
        Guid proposalUserId,
        DateTime proposalDate)
        : base(id)
    {
        ExhibitionProposalsId = exhibitionProposalsId;
        Name = name;
        Description = description;
        ProposalUserId = proposalUserId;
        ProposalDate = proposalDate;
    }

    public Guid ExhibitionProposalsId { get; }

    public string Name { get; }

    public string Description { get; }

    public Guid ProposalUserId { get; }

    public DateTime ProposalDate { get; }
}