using ManagementService.Application.Contracts.Queries;

namespace ManagementService.Application.ExhibitionProposals.GetExhibitionProposal;

public class GetExhibitionProposalsQuery : QueryBase<ExhibitionProposalDto>
{
    public GetExhibitionProposalsQuery(Guid exhibitionProposalsId)
    {
        ExhibitionProposalsId = exhibitionProposalsId;
    }

    public Guid ExhibitionProposalsId { get; }
}