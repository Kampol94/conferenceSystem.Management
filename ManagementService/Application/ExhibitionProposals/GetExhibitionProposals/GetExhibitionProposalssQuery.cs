using ManagementService.Application.Contracts.Queries;
using ManagementService.Application.ExhibitionProposals.GetExhibitionProposal;

namespace ManagementService.Application.ExhibitionProposals.GetExhibitionProposals;

public class GetExhibitionProposalssQuery : QueryBase<List<ExhibitionProposalsDto>>
{
    public GetExhibitionProposalssQuery()
    {
    }
}