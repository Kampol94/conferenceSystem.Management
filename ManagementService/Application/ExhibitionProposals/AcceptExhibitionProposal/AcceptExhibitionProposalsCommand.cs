using ManagementService.Application.Contracts.Commands;

namespace ManagementService.Application.ExhibitionProposals.AcceptExhibitionProposal;

public class AcceptExhibitionProposalsCommand : CommandBase
{
    public AcceptExhibitionProposalsCommand(Guid exhibitionProposalsId)
    {
        ExhibitionProposalsId = exhibitionProposalsId;
    }

    public Guid ExhibitionProposalsId { get; }
}