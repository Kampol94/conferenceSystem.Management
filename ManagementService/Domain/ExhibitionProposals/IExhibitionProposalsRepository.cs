namespace ManagementService.Domain.ExhibitionProposals;

public interface IExhibitionProposalsRepository
{
    Task AddAsync(ExhibitionProposal exhibitionProposals);

    Task<ExhibitionProposal> GetByIdAsync(ExhibitionProposalsId exhibitionProposalsId);
}